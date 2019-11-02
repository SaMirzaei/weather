namespace Weather.Api.Infrastructures
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class UnauthorizedRequestException : Exception
    {
        public UnauthorizedRequestException()
        {
        }

        public UnauthorizedRequestException(string message)
            : base(message)
        {
        }   

        public UnauthorizedRequestException(string message, Exception exception)
            : base(message, exception)
        {
        }

        protected UnauthorizedRequestException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
