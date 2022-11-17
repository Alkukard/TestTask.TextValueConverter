using System;

namespace TestTask.TextValueConverter.Converters.Exceptions
{
    public class TextValueConvertorException : Exception
    {
        public TextValueConvertorException() : base() { }

        public TextValueConvertorException(string message) : base(message) {}

        public TextValueConvertorException(string message, Exception innerException) : base(message, innerException) { }
    }
}
