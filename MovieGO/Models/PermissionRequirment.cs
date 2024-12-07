using Microsoft.AspNetCore.Authorization;
using MovieGO.Enums;

namespace MovieGO.Models
{
    public class PermissionRequirement(Permissions[] permissions)
        : IAuthorizationRequirement
    {
        public Permissions[] Permissions { get; set; } = permissions;

    }
}
