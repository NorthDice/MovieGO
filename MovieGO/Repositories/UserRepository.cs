﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieGO.Data;
using MovieGO.Entities;
using MovieGO.Interfaces;
using MovieGO.Models.UserData;
using MovieGO.Models.Users;

namespace MovieGO.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UserRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task Add(User user)
        {
            var roleEntity = await _context.Role
            .SingleOrDefaultAsync(r => r.Id == (int)Role.User)
            ?? throw new InvalidOperationException("User role not found in the database.");



            var userEntity = new UserEntity()
            {
                Id = user.Id,
                UserName = user.UserName,
                PasswordHash = user.PasswordHash,
                Email = user.Email,
            };

            await _context.Users.AddAsync(userEntity);
            await _context.SaveChangesAsync();
        }

        public async Task<User> GetByEmail(string email)
        {
            var userEntity = await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Email == email) ?? throw new NotImplementedException();

            return _mapper.Map<User>(userEntity);
        }
    }
}
