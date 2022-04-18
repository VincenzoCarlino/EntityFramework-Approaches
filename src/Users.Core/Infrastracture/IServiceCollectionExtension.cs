namespace Users.Core.Infrastracture;

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Users.Core.Infrastracture.Persistence.Configuration;
using Users.Core.Infrastracture.Persistence.EF;

static class IServiceCollectionExtension
{
    static IServiceCollection AddPersistence(
        this IServiceCollection serviceCollection,
        Func<IServiceProvider, PersistenceConfiguration> persistenceConfigurationDelegateProvider)
    {
        using var serviceProvider = serviceCollection.BuildServiceProvider();

        var persistenceConfiguration = persistenceConfigurationDelegateProvider(serviceProvider);

        serviceCollection.AddDbContext<ApplicationDbContext>((provider, options) =>
                options.UseNpgsql(
                    persistenceConfiguration.GetConnectionString()
                ),
            ServiceLifetime.Scoped
        );
        
        ApplyMigrations(persistenceConfiguration.GetConnectionString());

        return serviceCollection;
    }
    
    private static void ApplyMigrations(string connectionString)
    {
        using (var dbContext = new DesignTimeDbContextFactory()
                   .CreateDbContext(new string[] {connectionString})
              )
        {
            Console.WriteLine("Start applying migrations");
            dbContext.Database.Migrate();
            Console.WriteLine("End migrations");
        }
    }
}