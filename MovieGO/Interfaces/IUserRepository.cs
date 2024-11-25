using MovieGO.Enums;
using MovieGO.Models.UserData;
using MovieGO.Models.Users;

namespace MovieGO.Interfaces
{
    public interface IUserRepository
    {
        Task Add(User user);
        Task<User> GetByEmail(string email);
        Task<HashSet<Permissions>> GetUserPermissions(Guid userId);
    }
}
