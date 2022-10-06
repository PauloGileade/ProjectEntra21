using System;

namespace ProjectEntra21.src.Application.Exceptions
{
    [Serializable]
    public class ValueNotAvailableException : ApplicationException
    {
        public ValueNotAvailableException(string message) : base(message)
        {   
        }
    }
}
