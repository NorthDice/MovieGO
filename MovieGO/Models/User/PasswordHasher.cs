using Microsoft.AspNetCore.Identity;
using MovieGO.Interfaces;

namespace MovieGO.Models.User
{
    public class PasswordHasher :IPasswordHasher
    {
        public string Generate (string password) =>
            BCrypt.Net.BCrypt.EnhancedHashPassword(password);

        public bool Verify(string password, string hashedPassword) =>
            BCrypt.Net.BCrypt.EnhancedVerify(password, hashedPassword);
    }
}
