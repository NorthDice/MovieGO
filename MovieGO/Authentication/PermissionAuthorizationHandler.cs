using Microsoft.AspNetCore.Authorization;

namespace MovieGO.Authentication
{
    public class PermissionAuthorizationHandler : AuthorizationHandler<RolePermissionRequirement>
    {
        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context, 
            RolePermissionRequirement requirement)
        {
            
        }
    }
}
