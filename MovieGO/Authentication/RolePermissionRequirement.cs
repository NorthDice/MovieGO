using Microsoft.AspNetCore.Authorization;
using MovieGO.Enums;
namespace MovieGO.Authentication
{
    public class RolePermissionRequirement : IAuthorizationRequirement
    {
        public RolePermissionRequirement(Permissions[] permissions)
        {
            Permissions = permissions;
        }

        public Permissions[] Permissions { get; set; } = [];
    }
}
