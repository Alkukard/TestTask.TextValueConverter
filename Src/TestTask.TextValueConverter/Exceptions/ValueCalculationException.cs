using System;

namespace TestTask.TextValueConverter.Exceptions
{
    public class ValueCalculationException : TextValueConvertorException
    {
        public ValueCalculationException() : base() { }

        public ValueCalculationException(string message) : base(message) { }

        public ValueCalculationException(string message, Exception innerException) : base(message, innerException) { }
    }
}
