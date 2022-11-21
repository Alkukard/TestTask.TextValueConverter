namespace TestTask.TextValueConverter.Converters
{
    internal class FahrengeitToCelsiusConverter : BaseConverter
    {
        /// <inheritdoc />
        public override string[] InputSufixes => new string[] { "fahrenheit" };

        /// <inheritdoc />
        public override string OutputSufix => "celsius";

        /// <inheritdoc />
        public override string[] SupportedSiPrefixes => new string[]
        { "peta", "tera", "giga", "mega", "kilo", "hecto", "deca", "deci", "centi", "milli", "micro", "nano", "pico", "femto" };

        public FahrengeitToCelsiusConverter() : base() { }

        /// <inheritdoc />
        public override double Convert(double cleanValue)
        {
            return (cleanValue - 32) / 1.8;
        }
    }
}
