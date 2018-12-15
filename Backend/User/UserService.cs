using Database;
using User.Validation;

namespace User
{
    public class UserService
    {
        private DBManager _database;
        
        public UserService()
        {
            _database = new DBManager();
        }

        public UserDto GetUser(int id)
        {
            Database.User user = _database.GetUserById(id);
            if (user != null)
            {
                return new UserDto(user.User_Id, user.Username, user.Password,
                    user.Email, user.Name, user.Surname);
            }

            return null;
        }
        
        public UserDto GetUser(string username)
        {
            Database.User user = _database.GetUserByUsername(username);
            if (user != null)
            {
                return new UserDto(user.User_Id, user.Username, user.Password,
                    user.Email, user.Name, user.Surname);
            }

            return null;
        }

        public void CreateUser(UserDto user)
        {
            UserValidator userValidator = new UserValidator();
            if (!userValidator.ValidateUser(user))
            {
                throw new UserValidationException("New user validation failed.");
            }
            
            _database.CreateUser(user.Username, user.Password, user.Email, user.Name, user.Surname);
        }
        
        public void UpdateUser(UserDto user)
        {
            UserValidator userValidator = new UserValidator();
            if (!userValidator.ValidateUser(user))
            {
                throw new UserValidationException("Update user validation failed.");
            }
            
            _database.UpdateUserById(user.Id, user.Username, user.Password, user.Email, user.Name, user.Surname);
        }
    }
}