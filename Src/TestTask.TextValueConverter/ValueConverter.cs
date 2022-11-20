using System;
using System.Collections.Generic;
using System.Linq;
using TestTask.TextValueConverter.Converters;
using TestTask.TextValueConverter.Converters.Interfaces;
using TestTask.TextValueConverter.Exceptions;

namespace TestTask.TextValueConverter
{
    public class ValueConverter : IValueConverter
    {
        private readonly Dictionary<string, Dictionary<string, IConverter>> ConvertersMapping =
            new Dictionary<string, Dictionary<string, IConverter>>();

        /// <summary>
        /// Register all default converters
        /// </summary>
        public void DefaultInitialization()
        {
            // Length convertors
            RegisterConverterInstance(new MeterToFeetConverter());
            RegisterConverterInstance(new MeterToInchesConverter());

            // Temperature convertors
            RegisterConverterInstance(new CelsiusToFahrengeitConverter());
        }

        /// <summary>
        /// Register new converter instance to support
        /// </summary>
        /// <param name="instance">New converter instance</param>
        public void RegisterConverterInstance(IConverter instance)
        {
            foreach(var inputTypeKey in instance.InputSufixes)
            {
                if (!ConvertersMapping.ContainsKey(inputTypeKey))
                {
                    ConvertersMapping.Add(inputTypeKey, new Dictionary<string, IConverter>());
                }

                var inputTypeCollection = ConvertersMapping[inputTypeKey];

                if (inputTypeCollection.ContainsKey(instance.OutputSufix))
                {
                    throw new ConvertorForTypesPairAlreadyRegisteredException(
                        $"Convertor for types pair from '{inputTypeKey}' to '{instance.OutputSufix}' already registered.");
                }

                inputTypeCollection.Add(instance.OutputSufix, instance);
            }
        }

        /// <inheritdoc />
        public string Convert(string inputText, string type)
        {
            IConverter instance;
            var normalizedInput = inputText.Trim().ToLowerInvariant();
            var normalizedType = type.ToLowerInvariant();

            try
            {
                var inputTypeCollection = ConvertersMapping
                    .First(kvp => normalizedInput.EndsWith(kvp.Key));

                instance = inputTypeCollection.Value[normalizedType];
            }
            catch (InvalidOperationException ioex)
            {
                throw new ConvertorForTypesPairAlreadyRegisteredException(
                    $"Input type collection was not found for '{normalizedInput}'",
                    ioex);
            }
            catch (KeyNotFoundException knfex)
            {
                throw new ConvertorForTypesPairAlreadyRegisteredException(
                    $"Convertor instance was not found for convertion '{normalizedInput} to {normalizedType}'.",
                    knfex);
            }

            return instance.Invoke(inputText);
        }
    }
}
