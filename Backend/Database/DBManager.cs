using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class DBManager
    {
        #region UserCUD
        public void CreateUser(string username, string password, string email = null, string name = null, string surname = null)
        {
            using(var ctx = new katalogrzeczyEntities())
            {
                ctx.Users.Add(new User()
                {
                    Username = username,
                    Password = password,
                    Email = email,
                    Name = name,
                    Surname = surname
                });
                ctx.SaveChanges();
            }
        }

        public User GetUserById(int id)
        {
            using (var ctx = new katalogrzeczyEntities())
            {
                return (from User user in ctx.Users
                        where user.User_Id == id
                        select user).FirstOrDefault();
            }
        }

        public void DeleteUserById(int id)
        {
            using (var ctx = new katalogrzeczyEntities())
            {
                User user = GetUserById(id);
                if (user != null)
                {
                    ctx.Users.Remove(user);
                    ctx.SaveChanges();
                }
            }
        }

        public void UpdateUserById(int id, 
                                   string username = null, 
                                   string password = null, 
                                   string email = null, 
                                   string name = null, 
                                   string surname = null)
        {
            using (var ctx = new katalogrzeczyEntities())
            {
                User user = GetUserById(id);
                if(user != null)
                {
                    user.Username = username ?? user.Username;
                    user.Password = password ?? user.Password;
                    user.Email = email ?? user.Email;
                    user.Name = name ?? user.Name;
                    user.Surname = surname ?? user.Surname;
                    ctx.SaveChanges();
                }
            }
        }

        public List<User> GetAllUsers()
        {
            using (var ctx = new katalogrzeczyEntities())
            {
                return ctx.Users.ToList();
            }
        }
        #endregion
    }
}
