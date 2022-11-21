namespace TestTask.TextValueConverter.Converters
{
    internal abstract class FeetBaseConverter : BaseConverter
    {
        protected abstract double Multiplier { get; }

        /// <inheritdoc />
        public override string[] InputSufixes => new string[] { "feet", "feets" };

        /// <inheritdoc />
        public override string[] SupportedSiPrefixes => new string[] { "tera", "giga", "mega", "kilo", "deci", "centi", "milli", "micro", "nano", "pico" };

        public FeetBaseConverter() : base() { }

        /// <inheritdoc />
        public override double Convert(double cleanValue)
        {
            return cleanValue * Multiplier;
        }
    }
}
