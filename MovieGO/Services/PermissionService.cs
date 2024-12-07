using MovieGO.Enums;
using MovieGO.Interfaces;

namespace MovieGO.Services
{
    public class PermissionService : IPermissionService
    {
        private readonly IUserRepository _userRepository;

        public PermissionService(IUserRepository usersRepository)
        {
            _userRepository = usersRepository;        
        }
        public Task<HashSet<Permissions>> GetPermissionsAsync(Guid userId)
        {
           return _userRepository.GetUserPermissions(userId);
        }
    }
}
