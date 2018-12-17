using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchEngine.DTO
{
    public class UserDTO : ISearchItemDTO
    {
        public int User_Id { get; }
        public string Username { get; }
        public string Email { get; }
        public string Name { get; }
        public string Surname { get; }
        public float Score { get; }

        internal UserDTO(User user, float searchScore)
        {
            User_Id = user.User_Id;
            Username = user.Username;
            Email = user.Email ?? "";
            Name = user.Name;
            Surname = user.Surname;
            Score = searchScore;
        }
    }
}
