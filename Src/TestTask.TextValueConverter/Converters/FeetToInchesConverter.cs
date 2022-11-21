namespace TestTask.TextValueConverter.Converters
{
    internal class FeetToInchesConverter : FeetBaseConverter
    {
        protected override double Multiplier => 12;

        /// <inheritdoc />
        public override string OutputSufix => "inches";

        public FeetToInchesConverter() : base() { }
    }
}
