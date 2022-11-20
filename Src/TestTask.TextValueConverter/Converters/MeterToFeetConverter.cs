namespace TestTask.TextValueConverter.Converters
{
    internal class MeterToFeetConverter : MeterBaseConverter
    {
        protected override double Multiplier => 3.280839895;

        /// <inheritdoc />
        public override string OutputSufix => "feet";

        public MeterToFeetConverter() : base() { }
    }
}
