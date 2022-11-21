namespace TestTask.TextValueConverter.Converters
{
    internal class InchesToMeterConverter : InchesBaseConverter
    {
        protected override double Multiplier => 0.0254;

        /// <inheritdoc />
        public override string OutputSufix => "meter";

        public InchesToMeterConverter() : base() { }
    }
}
