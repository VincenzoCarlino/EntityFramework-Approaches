namespace Users.Core.Infrastracture.Persistence.EF.EntityConfigurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Users.Core.Domain.Models;
using Users.Core.Infrastracture.Persistence.Entities;

class UserRoleConfiguration : IEntityTypeConfiguration<DbUserRole>
{
    public void Configure(EntityTypeBuilder<DbUserRole> builder)
    {
        builder.ToTable("user_role");

        builder.HasKey(e => new {e.UserId, e.RoleId});

        builder.Property(e => e.RoleId)
            .HasColumnName("role_id");
        builder.Property(e => e.UserId)
            .HasColumnName("user_id");

        builder.HasOne(e => e.User)
            .WithMany(e => e.UserRoles)
            .HasForeignKey(e => e.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(e => e.Role)
            .WithMany(e => e.RoleUsers)
            .HasForeignKey(e => e.RoleId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}