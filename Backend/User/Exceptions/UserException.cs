using System;

namespace User.Validation
{
    public class UserException : Exception
    {
        public UserException()
        {
        }

        public UserException(string message)
            : base(message)
        {
        }
    }
}