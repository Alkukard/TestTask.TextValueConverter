using TestTask.TextValueConverter.Converters;

namespace TestTask.Example
{
    internal class CustomConverter : BaseConverter
    {
        public override string[] InputSufixes => new string[] { "gram", "grams" };

        public override string OutputSufix => "pound";

        public override string[] SupportedSiPrefixes => new string[] { "kilo", "deci", "centi", "milli", "micro" };

        public override double Convert(double cleanValue)
        {
            return cleanValue / 453.59237;
        }
    }
}
