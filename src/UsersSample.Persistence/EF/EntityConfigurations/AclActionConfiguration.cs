namespace UsersSample.Persistence.EF.EntityConfigurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UsersSample.Persistence.Entities;

class AclActionConfiguration : IEntityTypeConfiguration<DbAclAction>
{
    public void Configure(EntityTypeBuilder<DbAclAction> builder)
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