namespace TestTask.TextValueConverter.Converters
{
    internal class InchesToFeetConverter : InchesBaseConverter
    {
        protected override double Multiplier => 3.280839895;

        /// <inheritdoc />
        public override string OutputSufix => "feet";

        public InchesToFeetConverter() : base() { }

        /// <inheritdoc />
        public override double Convert(double cleanValue)
        {
            return cleanValue / Multiplier;
        }
    }
}
