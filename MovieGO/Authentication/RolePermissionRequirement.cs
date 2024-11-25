using Microsoft.AspNetCore.Authorization;
using MovieGO.Enums;
namespace MovieGO.Authentication
{
    public class RolePermissionRequirement : IAuthorizationRequirement
    {
        public Permissions[] Permissions { get; set; } = [];
    }
}
