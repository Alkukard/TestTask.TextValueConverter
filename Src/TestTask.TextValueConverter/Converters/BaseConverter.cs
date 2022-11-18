using System;
using System.Collections.Generic;
using System.Linq;
using TestTask.TextValueConverter.Converters.Exceptions;
using TestTask.TextValueConverter.Converters.Interfaces;

namespace TestTask.TextValueConverter.Converters
{
    public abstract class BaseConverter : IConverter
    {
        private readonly Dictionary<string, long> SiPrefixesValues = new Dictionary<string, long>
        {
            { "peta", 1000000000000000 },
            { "tera", 1000000000000 },
            { "giga", 1000000000 },
            { "mega", 1000000 },
            { "kilo", 1000 },
            { "hecto", 100 },
            { "deca", 100 },
            { "deci", -100 },
            { "centi", -100 },
            { "milli", -1000 },
            { "micro", -1000000 },
            { "nano", -1000000000 },
            { "pico", -1000000000000 },
            { "femto", -1000000000000000 },
        };

        private readonly Dictionary<string, Func<double, double>> SupportedSiPrefixesValues;

        /// <inheritdoc />
        public abstract string[] InputSufixes { get; }

        /// <inheritdoc />
        public abstract string OutputSufix { get; }

        /// <inheritdoc />
        public abstract string[] SupportedSiPrefixes { get; }

        public BaseConverter()
        {
            SupportedSiPrefixesValues = SiPrefixesValues
                .Where(x => SupportedSiPrefixes.Contains(x.Key))
                .ToDictionary(
                    kvp => kvp.Key,
                    kvp => kvp.Value > 0
                        ? new Func<double, double>((x) => x * kvp.Value)
                        : new Func<double, double>((x) => x / (-1 * kvp.Value)));
        }

        /// <inheritdoc />
        public string Invoke(string input)
        {
            string result;
            double convertedValue = 0;
            var parcedInput = Parce(input);
            var cleanValue = RecalculateToCleanValue(parcedInput.Value, parcedInput.SiPrefix);

            try
            {
                convertedValue = Convert(cleanValue);
            }
            catch (OverflowException ex)
            {
                throw new ValueCalculationException(
                    $"Overflow during clean value converting '{input}'",
                    ex);
            }

            result = ConstructResultText(convertedValue);

            return result;
        }

        public abstract double Convert(double cleanValue);

        private string ConstructResultText(double convertedValue)
        {
            string siPrefix = string.Empty;
            double result = 0;

            Func<double, long, bool> upperPrefixCheck = (double cv, long spv) => cv > 0 && spv > 0 && (long)cv / spv > 0;
            Func<double, long, bool> loverPrefixCheck = (double cv, long spv) => cv > 0 && spv < 0 && cv * (-1 * spv) > 0;

            if (convertedValue != 0)
            {
                foreach (var knownSiPrefix in SiPrefixesValues)
                {
                    if (upperPrefixCheck(convertedValue, knownSiPrefix.Value))
                    {
                        siPrefix = knownSiPrefix.Key;
                        result = convertedValue / knownSiPrefix.Value;

                        break;
                    }
                    else
                    {
                        if (loverPrefixCheck(convertedValue, knownSiPrefix.Value))
                        {
                            siPrefix = knownSiPrefix.Key;
                            result = convertedValue * (-1 * knownSiPrefix.Value);

                            break;
                        }
                    }
                }
            }

            return $"{result} {siPrefix}{OutputSufix}";
        }

        private double RecalculateToCleanValue(double value, string siPrefix)
        {
            var result = value;

            if (!string.IsNullOrWhiteSpace(siPrefix))
            {
                if (!SiPrefixesValues.ContainsKey(siPrefix))
                {
                    throw new UnknownSiPrefixException("Provided SI prefix does not supported by the converter framework.");
                }

                if (!SupportedSiPrefixes.Contains(siPrefix))
                {
                    throw new UnsupportedSiPrefixException($"Provided SI prefix does not supported by this converter ({this.GetType().FullName})");
                }

                var siPrefixQuantifier = SupportedSiPrefixesValues[siPrefix];

                try
                {
                    result = siPrefixQuantifier(result);
                }
                catch (OverflowException ex)
                {
                    throw new ValueCalculationException(
                        $"Overflow during clean value calculation for '{value} {siPrefix}'",
                        ex);
                }
            }

            return result;
        }

        private (double Value, string SiPrefix) Parce(string input)
        {
            double value;
            var inputWords = input.Trim().Split(' ');

            if (inputWords.Length != 2 ||
                !InputSufixes.Any(x => inputWords[1].EndsWith(x)) ||
                !double.TryParse(inputWords[0], out value))
            {
                throw new WrongInputTextFormatException($"Text input '{input}' does not match expected format '[Value] [SI prefix][Type sufix]'.");
            }

            string sufix = InputSufixes.FirstOrDefault(x => inputWords[1].EndsWith(x));
            string siPrefix = inputWords[1].Replace(sufix, string.Empty);

            return (value, siPrefix);
        }
    }
}
