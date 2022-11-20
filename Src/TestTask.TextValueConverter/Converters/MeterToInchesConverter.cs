namespace TestTask.TextValueConverter.Converters
{
    internal class MeterToInchesConverter : MeterBaseConverter
    {
        protected override double Multiplier => 39.37007874;

        /// <inheritdoc />
        public override string OutputSufix => "inches";

        public MeterToInchesConverter() : base() { }
    }
}
