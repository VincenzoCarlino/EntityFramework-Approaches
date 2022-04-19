namespace UsersSample.Core.Infrastracture.Persistence.EF.EntityConfigurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UsersSample.Core.Infrastracture.Persistence.Entities;

class RoleAclActionConfiguration : IEntityTypeConfiguration<DbRoleAclAction>
{
    public void Configure(EntityTypeBuilder<DbRoleAclAction> builder)
    {
        builder.ToTable("role_aclaction");

        builder.HasKey(e => new {e.RoleId, e.AclActionId});

        builder.Property(e => e.RoleId)
            .HasColumnName("role_id");
        builder.Property(e => e.AclActionId)
            .HasColumnName("acl_action_id");

        builder.HasOne(e => e.Role)
            .WithMany(e => e.RoleAclActions)
            .HasForeignKey(e => e.RoleId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(e => e.AclAction)
            .WithMany(e => e.AclActionRoles)
            .HasForeignKey(e => e.AclActionId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}