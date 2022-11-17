namespace TestTask.TextValueConverter.Converters
{
    internal class MeterToFeetConverter : BaseConverter
    {
        private const double Multiplier = 3.280839895;

        /// <inheritdoc />
        public override string[] InputSufixes => new string[] { "meter", "meters" };

        /// <inheritdoc />
        public override string OutputSufix => "feet";

        /// <inheritdoc />
        public override string[] SupportedSiPrefixes => new string[] { "tera", "giga", "mega", "kilo", "deci", "centi", "milli", "micro", "nano", "pico" };

        public MeterToFeetConverter() : base() { }

        public override double Convert(double cleanValue)
        {
            return cleanValue * Multiplier;
        }
    }
}
