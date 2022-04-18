namespace Users.Core.Infrastracture.Persistence.EF;

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        var connectionString = args[0];
        if (string.IsNullOrWhiteSpace(connectionString))
        {
            throw new Exception("Missing connection string");
        }
        var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
        builder.UseNpgsql(
            connectionString
        );
        return new ApplicationDbContext(builder.Options);
    }
}