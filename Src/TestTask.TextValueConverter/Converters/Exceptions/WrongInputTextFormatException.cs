using System;

namespace TestTask.TextValueConverter.Converters.Exceptions
{
    public class WrongInputTextFormatException : TextValueConvertorException
    {
        public WrongInputTextFormatException() : base() { }

        public WrongInputTextFormatException(string message) : base(message) { }

        public WrongInputTextFormatException(string message, Exception innerException) : base(message, innerException) { }
    }
}
