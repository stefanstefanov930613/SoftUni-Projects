﻿using Logger.Models.Errors;
using Logger.Models.Contracts;
using Logger.Models.Enumerations;
using System;
using Logger.Exceptions;
using System.Globalization;

namespace Logger.Factories
{
    public class ErrorFactory
    {
        private const string dateFormat = "M/dd/yyyy h:mm:ss tt";

        public IError GetError(string dateString,
              string levelString, string message)
        {
            Level level;

            bool hasParsed = Enum.TryParse<Level>(levelString, out level);

            if (!hasParsed)
            {
                throw new InvalidLevelTypeException();
            }

            DateTime dateTime;

            try
            {
                dateTime = DateTime.ParseExact(dateString, dateFormat
                    , CultureInfo.InvariantCulture);
            }
            catch (Exception e)
            {

                throw new InvalidDateFormatException();
            }

            return new Error(dateTime, message, level);
        }
    }
}
