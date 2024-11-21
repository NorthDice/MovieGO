namespace MovieGO.Models
{
    public class User
    {
        private User(int id, string userName, string passwordHash, string email)
        {
            Id = id;
            UserName = userName;
            PasswordHash = passwordHash;
            Email = email;
        }

        public int Id { get; set; }

        public string UserName { get; private set; }

        public string PasswordHash { get; private set; }

        public string Email { get; private set; }

        public static User Create(int id, string username, string passwordHash, string email)
        {
            return new User(id,username,passwordHash,email);   
        }
    }
}
