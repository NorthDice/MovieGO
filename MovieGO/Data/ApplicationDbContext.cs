using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MovieGO.Configurations;
using MovieGO.Entities;

namespace MovieGO.Data
{
    public class ApplicationDbContext(
       DbContextOptions<ApplicationDbContext> options,
       IOptions<AuthorizationOptions> authOptions) : DbContext(options)
    {
        public DbSet<UserEntity> Users { get; set; }

        public DbSet<RoleEntity> Roles { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());

            modelBuilder.ApplyConfiguration(new PermissionConfiguration());

            modelBuilder.ApplyConfiguration(new RolePermissionConfiguration(authOptions.Value));

            modelBuilder.ApplyConfiguration(new RoleConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
