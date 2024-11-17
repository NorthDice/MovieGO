using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace MovieGO.Data
{
    public class ApplicationDbContext(
       DbContextOptions<ApplicationDbContext> options,
       IOptions<AuthorizationOptions> authOptions) : DbContext(options)
    {
        
    }
}
