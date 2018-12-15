namespace User.Validation
{
    public class UserValidator
    {
        public bool ValidateUser(UserDto user)
        {
            if (user.Password == null || user.Password.Length < 6)
            {
                return false;
            }

            if (user.Username == null || user.Username.Length < 4)
            {
                return false;
            }
            
            if (user.Name == null || user.Surname == null || user.Email == null)
            {
                return false;
            }

            return true;
        }
    }
}