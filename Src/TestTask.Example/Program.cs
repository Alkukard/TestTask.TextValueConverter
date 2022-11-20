using System;
using TestTask.TextValueConverter;

namespace TestTask.Example
{
    class Program
    {
        static void Main(string[] args)
        {
            var valueConverter = new ValueConverter();

            Console.WriteLine("== Text value covertor usage example ==");
            valueConverter.DefaultInitialization();

            // Convert meters into inches
            var lengthInput = "10 kilometers";
            var lengthOutputType = "inches";

            ConvertAndLog("- Length convertion example -", lengthInput, lengthOutputType, valueConverter);

            // Convert celsius into fahrenheit
            var temperatureInput = "2 celsius";
            var temperatureOutputType = "fahrenheit";

            ConvertAndLog("- Temperature convertion example -", temperatureInput, temperatureOutputType, valueConverter);

            Console.ReadKey();
        }

        private static void ConvertAndLog(
            string summary,
            string input,
            string outputType,
            ValueConverter valueConverter)
        {
            var result = valueConverter.Convert(input, outputType);

            Console.WriteLine();
            Console.WriteLine(summary);
            Console.WriteLine($"{input} to {outputType} - {result}");
        }
    }
}
