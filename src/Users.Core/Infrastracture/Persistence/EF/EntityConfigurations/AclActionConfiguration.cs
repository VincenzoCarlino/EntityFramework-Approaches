namespace Users.Core.Infrastracture.Persistence.EF.EntityConfigurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Users.Core.Domain.Models;

class AclActionConfiguration : IEntityTypeConfiguration<AclAction>
{
    public void Configure(EntityTypeBuilder<AclAction> builder)
    {
        builder.ToTable("acl_actions");

        builder.HasKey(e => e.Id);
        
        builder.Property(e => e.Id)
            .HasColumnName("id");

        builder.Property(e => e.DisplayName)
            .HasColumnName("display_name")
            .IsRequired();
        
        builder.Property(e => e.Description)
            .HasColumnName("description")
            .IsRequired();
    }
}