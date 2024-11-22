using MovieGO.Interfaces;
using MovieGO.Models.UserData;
using MovieGO.Repositories;

namespace MovieGO.Models
{
    public class UserServices
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;

        public UserServices(UserRepository usersRepository,IPasswordHasher passwordHasher)
        {
            _passwordHasher = passwordHasher;
            _userRepository = usersRepository;
        }

        public async Task Register(string userName,string email, string password)
        {
            var hashedPassword = _passwordHasher.Generate(password);

            var user = User.Create(Guid.NewGuid(),userName, password, email);

            await _userRepository.Add(user);
        }

        public async Task<string> Login (string email,string password)
        {
            var user = await _userRepository.GetByEmail(email);

            var result = _passwordHasher.Verify(password, user.PasswordHash);

            if (result == false)
            {
                throw new ArgumentException("Failed to login");
            }



        }

    }
}
