using System;
using System.Text.RegularExpressions;
using Database;

namespace User.Validation
{
    public class UserValidator
    {
        private IDBManager _dbManager;

        public UserValidator(IDBManager dbManager)
        {
            _dbManager = dbManager;
        }
        
        public void ValidateNewUser(UserDto user)
        {
            if (user.Username == null || user.Username.Length < 4)
            {
                throw new UserValidationException("Username validation failed");
            }
            
            Database.User userByUsername = _dbManager.GetUserByUsername(user.Username);
            if (userByUsername != null)
            {
                throw new UserValidationException("Username already exists");
            }
            
            ValidatePassword(user.Password);
            ValidateEmail(user.Email);

            Database.User userByEmail = _dbManager.GetUserByEmail(user.Email);
            if (userByEmail != null)
            {
                throw new UserValidationException("Email is already taken");
            }

            ValidateSocialCredentials(user);
        }

        public void ValidateExistingUser(UserDto user)
        {
            Database.User userById = _dbManager.GetUserById(user.Id);
            if (userById == null)
            {
                throw new UserValidationException("User with given id doesn't exists");
            }

            if (userById.Username != user.Username)
            {
                throw new UserValidationException("Username cannot be changed");
            }

            if (userById.Password != user.Password)
            {
                ValidatePassword(user.Password);
            }

            if (userById.Email != user.Email)
            {
                ValidateEmail(user.Email);
            }
            
            ValidateSocialCredentials(user);
        }

        private void ValidatePassword(string password)
        {
            if (password == null || password.Length <= 6)
            {
                throw new UserValidationException("Password validation failed");
            }
        }

        private void ValidateEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new UserValidationException("Email cannot be empty");
            }
            
            const string emailPattern = @"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*"
                                        + "@"
                                        + @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$";
            Regex regex = new Regex(emailPattern);
            Match match = regex.Match(email);
            
            if (!match.Success)
            {
                throw new UserValidationException("Email address is not correct");
            }
        }

        private void ValidateSocialCredentials(UserDto user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));
            
            if (string.IsNullOrWhiteSpace(user.Name) || string.IsNullOrWhiteSpace(user.Surname))
            {
                throw new UserValidationException("Name and Surname cannot be empty");
            }
        }
    }
}