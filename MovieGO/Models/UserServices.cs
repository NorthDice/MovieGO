using MovieGO.Interfaces;

namespace MovieGO.Models
{
    public class UserServices
    {
        private readonly IPasswordHasher _passwordHasher;

        public UserServices(IPasswordHasher passwordHasher)
        {
            _passwordHasher = passwordHasher;
        }

        public async Task Register(string userName,string email, string password)
        {
            var hashedPassword = _passwordHasher.Generate(password);


        }

    }
}
