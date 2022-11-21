namespace TestTask.TextValueConverter.Converters
{
    internal class ByteToBitConverter : BaseConverter
    {
        /// <inheritdoc />
        public override string[] InputSufixes => new string[] { "byte", "bytes" };

        /// <inheritdoc />
        public override string OutputSufix => "bit";

        /// <inheritdoc />
        public override string[] SupportedSiPrefixes => new string[]
        { "peta", "tera", "giga", "mega", "kilo", "hecto", "deca", "deci", "centi", "milli", "micro", "nano", "pico", "femto" };

        public ByteToBitConverter() : base() { }

        /// <inheritdoc />
        public override double Convert(double cleanValue)
        {
            return cleanValue * 8;
        }
    }
}
