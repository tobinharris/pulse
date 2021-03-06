﻿using System;
using System.Runtime.Serialization;

namespace Pulse.Domain.Exceptions
{
    public class InvalidMeasurementException : ApplicationException
    {
        public InvalidMeasurementException()
        {
        }

        public InvalidMeasurementException(string message) : base(message)
        {
        }

        protected InvalidMeasurementException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public InvalidMeasurementException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}