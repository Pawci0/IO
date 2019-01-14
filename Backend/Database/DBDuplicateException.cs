using System;
using System.Runtime.Serialization;

namespace Database
{
    [Serializable]
    public class DBDuplicateException : Exception
    {
        public DBDuplicateException()
        {
        }

        public DBDuplicateException(string message) : base(message)
        {
        }

        public DBDuplicateException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DBDuplicateException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}