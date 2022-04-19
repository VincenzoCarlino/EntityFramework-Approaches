namespace Users.Core.Infrastracture.Persistence.EF;

using Microsoft.EntityFrameworkCore;
using Users.Core.Domain.Models;
using Users.Core.Infrastracture.Persistence.EF.EntityConfigurations;
using Users.Core.Infrastracture.Persistence.Entities;

class ApplicationDbContext : DbContext
{
    internal DbSet<DbAclAction> AclActions { get; private set; } = null!;
    internal DbSet<DbRole> Roles { get; private set; } = null!;
    internal DbSet<DbRoleAclAction> RoleAclAction { get; private set; } = null!;
    internal DbSet<DbUser> Users { get; private set; } = null!;
    internal DbSet<DbUserRole> UserRole { get; private set; } = null!;

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