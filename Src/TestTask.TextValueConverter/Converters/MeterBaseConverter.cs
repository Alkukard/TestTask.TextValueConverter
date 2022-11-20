namespace TestTask.TextValueConverter.Converters
{
    internal abstract class MeterBaseConverter : BaseConverter
    {
        protected abstract double Multiplier { get; }

        /// <inheritdoc />
        public override string[] InputSufixes => new string[] { "meter", "meters" };

        /// <inheritdoc />
        public override string[] SupportedSiPrefixes => new string[] { "tera", "giga", "mega", "kilo", "deci", "centi", "milli", "micro", "nano", "pico" };

        public MeterBaseConverter() : base() { }

        /// <inheritdoc />
        public override double Convert(double cleanValue)
        {
            return cleanValue * Multiplier;
        }
    }
}
