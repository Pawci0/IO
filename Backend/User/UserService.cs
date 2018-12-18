using System;
using System.Security.Cryptography;
using System.Text;
using Database;
using User.Validation;

namespace User
{
    public class UserService
    {
        private IDBManager _database;
        
        public UserService()
        {
            _database = new DBManager();
        }

        public UserDto GetUser(int id)
        {
            Database.User user = _database.GetUserById(id);
            if (user != null)
            {
                return ConvertUserToDto(user);
            }

            return null;
        }
        
        public UserDto GetUser(string username)
        {
            Database.User user = _database.GetUserByUsername(username);
            if (user != null)
            {
                return ConvertUserToDto(user);
            }

            return null;
        }

        public void CreateUser(UserDto user)
        {
            UserValidator userValidator = new UserValidator(_database);
            userValidator.ValidateNewUser(user);
            
            user.Password = GetHashedPassword(user.Username, user.Password);
            
            _database.CreateUser(user.Username, user.Password, user.Email, user.Name, user.Surname);
        }
        
        public void UpdateUser(UserDto user)
        {
            user.Password = GetHashedPassword(user.Username, user.Password);
            
            UserValidator userValidator = new UserValidator(_database);
            userValidator.ValidateExistingUser(user);
            
            _database.UpdateUserById(user.Id, user.Username, user.Password, user.Email, user.Name, user.Surname);
        }

        public void DisableUser(int userId)
        {
            Database.User userById = _database.GetUserById(userId);
            if (userById != null)
            {
                _database.DeleteUserById(userId);
            }
            else
            {
                throw new UserException($"User with id {userId} not found");
            }
        }

        public string GetHashedPassword(string salt, string password)
        {
            HashAlgorithm algorithm = new SHA256Managed();

            string saltAndPassword = string.Concat(salt, password);
            byte[] bytesOfSaltAndPassword = Encoding.UTF8.GetBytes(saltAndPassword);

            return Convert.ToBase64String(algorithm.ComputeHash(bytesOfSaltAndPassword));
        }

        private UserDto ConvertUserToDto(Database.User dbUser)
        {
            UserDto dtoUser = new UserDto(dbUser.User_Id, dbUser.Username, dbUser.Password,
                                          dbUser.Email, dbUser.Name, dbUser.Surname, dbUser.IsEnabled);

            return dtoUser;
        }
    }
}