namespace UsersSample.Persistence;

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using UsersSample.Domain.Providers;
using UsersSample.Domain.Repositories;
using UsersSample.Persistence.Configuration;
using UsersSample.Persistence.EF;
using UsersSample.Persistence.EF.Providers;
using UsersSample.Persistence.EF.Repositories;

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
        serviceCollection.AddScoped<IUserProvider, UserProvider>();
        serviceCollection.AddScoped<IUsersProvider, UsersProvider>();
        
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