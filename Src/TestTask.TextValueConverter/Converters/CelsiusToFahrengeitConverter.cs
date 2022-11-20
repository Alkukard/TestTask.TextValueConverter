namespace TestTask.TextValueConverter.Converters
{
    internal class CelsiusToFahrengeitConverter : BaseConverter
    {
        /// <inheritdoc />
        public override string[] InputSufixes => new string[] { "celsius" };

        /// <inheritdoc />
        public override string OutputSufix => "fahrenheit";

        /// <inheritdoc />
        public override string[] SupportedSiPrefixes => new string[]
        { "peta", "tera", "giga", "mega", "kilo", "hecto", "deca", "deci", "centi", "milli", "micro", "nano", "pico", "femto" };

        public CelsiusToFahrengeitConverter() : base() { }

        /// <inheritdoc />
        public override double Convert(double cleanValue)
        {
            return cleanValue * 1.8 + 32;
        }
    }
}
