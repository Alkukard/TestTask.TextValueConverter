using FluentAssertions;
using NUnit.Framework;
using System;
using TestTask.TextValueConverter.Converters;
using TestTask.TextValueConverter.Exceptions;

namespace TestTask.TextValueConverterTests.Converters
{
    public class BaseConverterTests
    {
        [Test]
        public void Invoke_ZeroInputs_SameZeroOutput()
        {
            // Arrange
            var converter = new BaseConverterStub();

            foreach (var prefix in BaseConverterStub.SiPrefixes)
            {
                var text = $"0 {prefix}meter";

                // Act
                var result = converter.Invoke(text);

                // Assert
                result.Should().Be("0 feet");
            }
        }

        [Test]
        public void Invoke_ValueNotSpecified_ShoulThrowException()
        {
            // Arrange
            var converter = new BaseConverterStub();
            var text = " kilometer ";

            // Act
            var act = new Action(() => converter.Invoke(text));

            // Assert
            act.Should().Throw<WrongInputTextFormatException>();
        }

        [Test]
        public void Invoke_MetricNotSpecified_ShoulThrowException()
        {
            // Arrange
            var converter = new BaseConverterStub();
            var text = "123 ";

            // Act
            var act = new Action(() => converter.Invoke(text));

            // Assert
            act.Should().Throw<WrongInputTextFormatException>();
        }

        [Test]
        public void Invoke_UnsupportedMetric_ShoulThrowException()
        {
            // Arrange
            var converter = new BaseConverterStub();
            var text = "12 feet ";

            // Act
            var act = new Action(() => converter.Invoke(text));

            // Assert
            act.Should().Throw<WrongInputTextFormatException>();
        }

        [Test]
        public void Invoke_ValueInNotNumber_ShoulThrowException()
        {
            // Arrange
            var converter = new BaseConverterStub();
            var text = "-8hg9 kilometer ";

            // Act
            var act = new Action(() => converter.Invoke(text));

            // Assert
            act.Should().Throw<WrongInputTextFormatException>();
        }

        [Test]
        public void Invoke_UnknownSiPrefix_ShoulThrowException()
        {
            // Arrange
            var converter = new BaseConverterStub();
            var text = "89 somethingmeters ";

            // Act
            var act = new Action(() => converter.Invoke(text));

            // Assert
            act.Should().Throw<UnknownSiPrefixException>();
        }

        [Test]
        public void Invoke_UnsupportedSiPrefix_ShoulThrowException()
        {
            // Arrange
            var converter = new ShortPrefixSuppoertListConverterStub();
            var text = "91 petameters ";

            // Act
            var act = new Action(() => converter.Invoke(text));

            // Assert
            act.Should().Throw<UnsupportedSiPrefixException>();
        }

        [Test]
        public void Invoke_CorrectInputs_Success()
        {
            // Arrange
            var converter = new BaseConverterStub();
            var kilometersText = "91 kilometers ";
            var millimetersText = "14 millimeters";

            // Act
            var kilometersResult = converter.Invoke(kilometersText);
            var millimetersResult = converter.Invoke(millimetersText);

            // Assert
            kilometersResult.Should().Be("273 kilofeet");
            millimetersResult.Should().Be("0.42 decifeet");
        }
    }

    internal class BaseConverterStub : BaseConverter
    {
        public static string[] SiPrefixes = new string[]
        { "peta", "tera", "giga", "mega", "kilo", "hecto", "deca", "deci", "centi", "milli", "micro", "nano", "pico", "femto" };

        public const int Multiplier = 3;

        public override string[] InputSufixes => new string[] { "meter", "meters" };

        public override string OutputSufix => "feet";

        public override string[] SupportedSiPrefixes => SiPrefixes;

        public BaseConverterStub() : base() { }

        public override double Convert(double cleanValue)
        {
            return cleanValue * Multiplier;
        }
    }

    internal class ShortPrefixSuppoertListConverterStub : BaseConverterStub
    {
        public static string[] SiPrefixesShortList = new string[] { "kilo", "hecto", "deca", "deci", };

        public override string[] SupportedSiPrefixes => SiPrefixesShortList;
    }
}
