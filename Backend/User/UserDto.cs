namespace User
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public bool IsEnabled { get; set; }

        public UserDto()
        {
            
        }
        
        public UserDto(int id, string username, string password, string email, string name, string surname, bool isEnabled)
        {
            Id = id;
            Username = username;
            Password = password;
            Email = email;
            Name = name;
            Surname = surname;
            IsEnabled = isEnabled;
        }
    }
}