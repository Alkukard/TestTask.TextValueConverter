using System;

namespace TestTask.TextValueConverter.Exceptions
{
    public class CorespondingConvertorWasNotRegisteredException : TextValueConvertorException
    {
        public CorespondingConvertorWasNotRegisteredException() : base() { }

        public CorespondingConvertorWasNotRegisteredException(string message) : base(message) { }

        public CorespondingConvertorWasNotRegisteredException(string message, Exception innerException) : base(message, innerException) { }
    }
}
