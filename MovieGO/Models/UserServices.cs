using MovieGO.Interfaces;
using MovieGO.Models.Provider;
using MovieGO.Models.UserData;
using MovieGO.Repositories;

namespace MovieGO.Models
{
    public class UserServices
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IJwtProvider _jwtProvider; 

        public UserServices(UserRepository usersRepository,IPasswordHasher passwordHasher, IJwtProvider jwtProvider)
        {
            _passwordHasher = passwordHasher;
            _userRepository = usersRepository;
            _jwtProvider = jwtProvider;
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

            var token = _jwtProvider.GenerateJwtToken(user);

            return token;

        }

    }
}
