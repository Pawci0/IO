using System;

namespace User.Validation
{
    public class UserValidationException : Exception
    {
        public UserValidationException()
        {
        }

        public UserValidationException(string message)
            : base(message)
        {
        }
    }
}