﻿using MovieGO.Interfaces;
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

        public async Task Register(int id,string userName,string email, string password)
        {
            var hashedPassword = _passwordHasher.Generate(password);

            var user = User.Create(id, userName, password, email);

            await _userRepository.Add(user);
        }

    }
}
