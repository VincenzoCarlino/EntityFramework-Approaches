namespace UsersSample.Core.Infrastracture.Persistence.EF.EntityConfigurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UsersSample.Core.Infrastracture.Persistence.Entities;

class UserConfiguration : IEntityTypeConfiguration<DbUser>
{
    public void Configure(EntityTypeBuilder<DbUser> builder)
    {
        builder.ToTable("users");

        builder.HasKey(e => e.Id);
        builder.HasIndex(e => e.Username)
            .IsUnique();

        builder.Property(e => e.Id)
            .HasColumnName("id");
        builder.Property(e => e.Username)
            .HasColumnName("username")
            .IsRequired();
        builder.Property(e => e.FirstName)
            .HasColumnName("firstname")
            .IsRequired();
        builder.Property(e => e.LastName)
            .HasColumnName("lastname")
            .IsRequired();
    }
}