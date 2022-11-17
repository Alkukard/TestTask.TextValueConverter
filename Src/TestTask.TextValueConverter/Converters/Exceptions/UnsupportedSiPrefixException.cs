﻿using System;

namespace TestTask.TextValueConverter.Converters.Exceptions
{
    public class UnsupportedSiPrefixException : TextValueConvertorException
    {
        public UnsupportedSiPrefixException() : base() { }

        public UnsupportedSiPrefixException(string message) : base(message) { }

        public UnsupportedSiPrefixException(string message, Exception innerException) : base(message, innerException) { }
    }
}
