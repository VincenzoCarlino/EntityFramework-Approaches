namespace Users.Core.Infrastracture.Persistence.EF.EntityConfigurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Users.Core.Domain.Models;
using Users.Core.Infrastracture.Persistence.Entities;

class RoleConfiguration : IEntityTypeConfiguration<DbRole>
{
    public void Configure(EntityTypeBuilder<DbRole> builder)
    {
        builder.ToTable("roles");

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