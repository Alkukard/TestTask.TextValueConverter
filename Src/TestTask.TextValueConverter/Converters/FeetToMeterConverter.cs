namespace TestTask.TextValueConverter.Converters
{
    internal class FeetToMeterConverter : FeetBaseConverter
    {
        protected override double Multiplier => 0.3048;

        /// <inheritdoc />
        public override string OutputSufix => "meter";

        public FeetToMeterConverter() : base() { }
    }
}
