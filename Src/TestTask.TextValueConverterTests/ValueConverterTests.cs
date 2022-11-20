using AutoFixture.NUnit3;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;
using TestTask.TextValueConverter;
using TestTask.TextValueConverter.Converters.Interfaces;
using TestTask.TextValueConverter.Exceptions;

namespace TestTask.TextValueConverterTests
{
    public class ValueConverterTests
    {
        public static string[] SiPrefixes = new string[]
        { "peta", "tera", "giga", "mega", "kilo", "hecto", "deca", "deci", "centi", "milli", "micro", "nano", "pico", "femto" };

        [Test]
        [AutoMoqData]
        public void RegisterConverterInstance_CorrectInput_Success(
            [Frozen]Mock<IConverter> converterMock,
            string inputType,
            string outputType,
            ValueConverter valueConverter)
        {
            // Arrange
            converterMock.SetupGet(cm => cm.InputSufixes).Returns(new string[] { inputType.ToLowerInvariant() });
            converterMock.SetupGet(cm => cm.OutputSufix).Returns(outputType.ToLowerInvariant());

            // Act
            valueConverter.RegisterConverterInstance(converterMock.Object);

            // Assert
            converterMock.VerifyGet(cm => cm.InputSufixes, Times.Once);
            converterMock.VerifyGet(cm => cm.OutputSufix, Times.Exactly(2));
        }

        [Test]
        [AutoMoqData]
        public void Convert_InputTypeDoesNotRegistered_ShouldThrowException(
            string inputType,
            string outputType,
            ValueConverter valueConverter)
        {
            // Arrange
            var inputText = $"5 kilo{inputType}";
            var outputText = $"10 mili{outputType}";

            valueConverter.DefaultInitialization();

            // Act
            var act = new Action(() => valueConverter.Convert(inputText, outputType));

            // Assert
            act.Should().Throw<ConvertorForTypesPairAlreadyRegisteredException>();
        }

        [Test]
        [AutoMoqData]
        public void Convert_OutputTypeDoesNotRegistered_ShouldThrowException(
            [Frozen]Mock<IConverter> converterMock,
            string inputType,
            string outputType,
            string wrongOutputType,
            ValueConverter valueConverter)
        {
            // Arrange
            var inputText = $"5 kilo{inputType}";
            var outputText = $"10 mili{outputType}";

            converterMock.SetupGet(cm => cm.InputSufixes).Returns(new string[] { inputType.ToLowerInvariant() });
            converterMock.SetupGet(cm => cm.OutputSufix).Returns(wrongOutputType.ToLowerInvariant());
            converterMock.Setup(cm => cm.Invoke(It.IsAny<string>())).Returns(outputText);

            valueConverter.DefaultInitialization();
            valueConverter.RegisterConverterInstance(converterMock.Object);

            // Act
            var act = new Action(() => valueConverter.Convert(inputText, outputType));

            // Assert
            act.Should().Throw<ConvertorForTypesPairAlreadyRegisteredException>();
        }

        [Test]
        [AutoMoqData]
        public void RegisterConverterInstance_SuchConverterAlreadyRegistered_ShouldThrowException(
            [Frozen]Mock<IConverter> converterMock,
            string inputType,
            string outputType,
            ValueConverter valueConverter)
        {
            // Arrange
            converterMock.SetupGet(cm => cm.InputSufixes).Returns(new string[] { inputType.ToLowerInvariant() });
            converterMock.SetupGet(cm => cm.OutputSufix).Returns(outputType.ToLowerInvariant());

            valueConverter.RegisterConverterInstance(converterMock.Object);

            // Act
            var act = new Action(() => valueConverter.RegisterConverterInstance(converterMock.Object));

            // Assert
            act.Should().Throw<ConvertorForTypesPairAlreadyRegisteredException>();
        }

        [Test]
        [AutoMoqData]
        public void Convert_CorrectInput_Success(
            [Frozen]Mock<IConverter> converterMock,
            string inputType,
            string outputType,
            ValueConverter valueConverter)
        {
            // Arrange
            var inputText = $"5 kilo{inputType}";
            var outputText = $"10 mili{outputType}";

            converterMock.SetupGet(cm => cm.InputSufixes).Returns(new string[] { inputType.ToLowerInvariant() });
            converterMock.SetupGet(cm => cm.OutputSufix).Returns(outputType.ToLowerInvariant());
            converterMock.Setup(cm => cm.Invoke(It.IsAny<string>())).Returns(outputText);

            valueConverter.DefaultInitialization();
            valueConverter.RegisterConverterInstance(converterMock.Object);

            // Act
            var result = valueConverter.Convert(inputText, outputType);

            // Assert
            result.Should().Be(outputText);
            converterMock.Verify(cm => cm.Invoke(It.Is<string>(x => x == inputText)), Times.Once);
        }
    }
}
