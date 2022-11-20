using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.NUnit3;

namespace TestTask.TextValueConverterTests
{
    public class AutoMoqDataAttribute : AutoDataAttribute
    {
        internal AutoMoqDataAttribute() : base(FixtureGenerator.Create()) { }
    }

    internal static class FixtureGenerator
    {
        public static IFixture Create()
        {
            var fixture = new Fixture();

            fixture.Customize(new AutoMoqCustomization());

            return fixture;
        }
    }
}
