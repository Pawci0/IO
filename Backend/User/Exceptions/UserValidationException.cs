namespace User.Validation
{
    public class UserValidationException : UserException
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