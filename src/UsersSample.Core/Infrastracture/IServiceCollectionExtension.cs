namespace UsersSample.Core.Infrastracture;

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using UsersSample.Core.Domain.Repositories;
using UsersSample.Core.Infrastracture.Persistence.Configuration;
using UsersSample.Core.Infrastracture.Persistence.EF;
using UsersSample.Core.Infrastracture.Persistence.EF.Repositories;

public static class IServiceCollectionExtension
{
    public static IServiceCollection AddPersistence(
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

        serviceCollection.AddScoped<IUsersRepository, UsersRepository>();
        
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