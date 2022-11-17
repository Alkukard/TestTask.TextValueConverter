using System;

namespace TestTask.TextValueConverter.Converters.Exceptions
{
    public class ValueCalculationException : Exception
    {
        public ValueCalculationException() : base() { }

        public ValueCalculationException(string message) : base(message) { }

        public ValueCalculationException(string message, Exception innerException) : base(message, innerException) { }
    }
}
