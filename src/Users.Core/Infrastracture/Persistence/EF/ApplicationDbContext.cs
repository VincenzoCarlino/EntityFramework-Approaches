namespace Users.Core.Infrastracture.Persistence.EF;

using Microsoft.EntityFrameworkCore;
using Users.Core.Domain.Models;
using Users.Core.Infrastracture.Persistence.EF.EntityConfigurations;

class ApplicationDbContext : DbContext
{
    internal DbSet<AclAction> AclActions { get; private set; } = null!;
    internal DbSet<Role> Roles { get; private set; } = null!;
    internal DbSet<RoleAclAction> RoleAclAction { get; private set; } = null!;
    internal DbSet<User> Users { get; private set; } = null!;
    internal DbSet<UserRole> UserRole { get; private set; } = null!;

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.HasPostgresExtension("uuid-ossp");

        modelBuilder.ApplyConfiguration(new AclActionConfiguration());
        modelBuilder.ApplyConfiguration(new RoleAclActionConfiguration());
        modelBuilder.ApplyConfiguration(new RoleConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new UserRoleConfiguration());
    }
}