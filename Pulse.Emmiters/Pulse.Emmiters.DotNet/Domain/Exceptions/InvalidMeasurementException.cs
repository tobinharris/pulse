using System;
using System.Runtime.Serialization;

namespace Pulse.Emmiters.DotNet.Domain.Exceptions
{
    public class InvalidMeasurementException : ApplicationException
    {
        public InvalidMeasurementException()
        {
        }
        public InvalidMeasurementException(string message) : base(message)
        {
        }
        public InvalidMeasurementException(string message, Exception innerException) : base(message, innerException)
        {
        }
        protected InvalidMeasurementException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}