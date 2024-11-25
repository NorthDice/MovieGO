using Microsoft.AspNetCore.Authentication.OAuth.Claims;
using Microsoft.AspNetCore.Authorization;

namespace MovieGO.Authentication
{
    public class PermissionAuthorizationHandler : AuthorizationHandler<RolePermissionRequirement>
    {
        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context, 
            RolePermissionRequirement requirement)
        {
            var userId = context.User.Claims.FirstOrDefault(
                c=> c.Type == CustomClaims.UserId
                );
        }
    }
}
