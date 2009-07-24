namespace Pulse.Emmiters.DotNet.Domain.Exceptions
{
    using System;
    using System.Runtime.Serialization;

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

