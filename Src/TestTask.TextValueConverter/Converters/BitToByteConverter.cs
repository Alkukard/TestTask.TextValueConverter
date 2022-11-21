namespace TestTask.TextValueConverter.Converters
{
    internal class BitToByteConverter : BaseConverter
    {
        /// <inheritdoc />
        public override string[] InputSufixes => new string[] { "bit", "bits" };

        /// <inheritdoc />
        public override string OutputSufix => "byte";

        /// <inheritdoc />
        public override string[] SupportedSiPrefixes => new string[]
        { "peta", "tera", "giga", "mega", "kilo", "hecto", "deca", "deci", "centi", "milli", "micro", "nano", "pico", "femto" };

        public BitToByteConverter() : base() { }

        /// <inheritdoc />
        public override double Convert(double cleanValue)
        {
            var normalizedClearValue = (long)cleanValue;

            return normalizedClearValue % 8 == 0
                ? normalizedClearValue / 8
                : normalizedClearValue / 8 + 1;
        }
    }
}
