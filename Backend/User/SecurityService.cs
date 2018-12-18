using Database;

namespace User
{
    public class SecurityService
    {
        private IDBManager _database;
        
        public SecurityService()
        {
            _database = new DBManager();
        }

        public bool AuthenticateUser(UserDto user)
        {
            if (user == null)
            {
                return false;
            }

            Database.User userByUsername = _database.GetUserByUsername(user.Username);
            if (userByUsername != null && userByUsername.IsEnabled)
            {
                return userByUsername.Username == user.Username && 
                       userByUsername.Password == user.Password;
            }

            return false;
        }
    }
}