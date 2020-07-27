using System;

namespace Logger.Exceptions
{
    public class InvalidLevelTypeException : Exception
    {
        private const string EXC_MESSAGE = "Invalid Level Type!";

        public InvalidLevelTypeException()
        {
        }

        public InvalidLevelTypeException(string message) 
            : base(EXC_MESSAGE)
        {

        }
    }
}
