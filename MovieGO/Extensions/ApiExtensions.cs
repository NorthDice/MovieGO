using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MovieGO.Enums;
using MovieGO.Models;
using MovieGO.Models.Provider;
using System.Text;

namespace MovieGO.Extensions
{
    public static class ApiExtensions
    {
        public static void AddApiAuthentication(
            IServiceCollection services,
            IOptions<JwtOptions> jwtOptions)
        {

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
                {
                    options.TokenValidationParameters = new()
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.Value.SecretKey))
                    };

                    options.Events = new JwtBearerEvents
                    {
                        OnMessageReceived = context =>
                        {
                            context.Token = context.Request.Cookies["MovieGo"];
                            return Task.CompletedTask;
                        }
                    };
                });


            services.AddAuthorization();

        }
        public static IEndpointConventionBuilder RequirePermissions<TBuilder>(
             this TBuilder builder, params Permissions[] permissions)
             where TBuilder : IEndpointConventionBuilder
        {
            return builder.RequireAuthorization(policy =>
            policy.AddRequirements(new PermissionRequirement(permissions)));
        }
    }
}
