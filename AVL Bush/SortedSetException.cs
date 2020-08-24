using System;
using System.Runtime.Serialization;

namespace AVL_Bush
{
    [Serializable]
    internal class SortedSetException : Exception
    {
        public SortedSetException()
        {
        }

        public SortedSetException(string message) : base(message)
        {
        }

        public SortedSetException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected SortedSetException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}