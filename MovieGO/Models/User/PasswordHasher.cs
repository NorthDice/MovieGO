using Microsoft.AspNetCore.Identity;

namespace MovieGO.Models.User
{
    public class PasswordHasher :IPasswordHasher
    {
        public string Generate (string password) =>
            BCrypt.Net.BCrypt.EnhancedHashPassword(password);
    }
}
