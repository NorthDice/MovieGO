using System.Security;

namespace MovieGO.Entities
{
    public class UserEntity
    {
        public int Id { get; set; }

        public string UserName { get; set; } = string.Empty;

        public string PasswordHash { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public ICollection<RoleEntity> Roles { get; set; } = [];
    }
}
