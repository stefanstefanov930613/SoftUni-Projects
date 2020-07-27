using System;

namespace Logger.Exceptions
{
    public class InvalidDateFormatException : Exception
    {

        private const string EXC_MESSAGE = "Invalid DateTime Format!";

        public InvalidDateFormatException()
        {

        }

        public InvalidDateFormatException(string message)
            : base(EXC_MESSAGE)
        {

        }

        public InvalidDateFormatException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}
