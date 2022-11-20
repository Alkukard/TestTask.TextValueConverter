using System;

namespace TestTask.TextValueConverter.Exceptions
{
    public class ConvertorForTypesPairAlreadyRegisteredException : TextValueConvertorException
    {
        public ConvertorForTypesPairAlreadyRegisteredException() : base() { }

        public ConvertorForTypesPairAlreadyRegisteredException(string message) : base(message) { }

        public ConvertorForTypesPairAlreadyRegisteredException(string message, Exception innerException) : base(message, innerException) { }
    }
}
