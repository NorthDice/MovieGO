using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieGO.Entities;

namespace MovieGO.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.HasKey(user => user.Id);

            builder.HasMany(user => user.Roles)
                   .WithMany(role => role.Users)
                   .UsingEntity<UserRoleEntity>(
                        l => l.HasOne<RoleEntity>().WithMany().HasForeignKey(r => r.RoleId),
                        r => r.HasOne<UserEntity>().WithMany().HasForeignKey(l => l.UserId));
        }
    }
}
