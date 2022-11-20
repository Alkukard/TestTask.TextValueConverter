using System;

namespace TestTask.TextValueConverter.Exceptions
{
    public class UnknownSiPrefixException : TextValueConvertorException
    {
        public UnknownSiPrefixException() : base() { }

        public UnknownSiPrefixException(string message) : base(message) { }

        public UnknownSiPrefixException(string message, Exception innerException) : base(message, innerException) { }
    }
}
