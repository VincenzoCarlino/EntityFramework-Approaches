namespace UsersSample.Application;

using System;
using Microsoft.Extensions.DependencyInjection;
using UsersSample.Application.Services;
using UsersSample.Persistence;
using UsersSample.Persistence.Configuration;

public static class IServiceCollectionExtension
{
    public static IServiceCollection AddApplication(
        this IServiceCollection serviceCollection,
        Func<IServiceProvider, PersistenceConfiguration> persistenceConfigurationDelegateProvider)
    {
        serviceCollection.AddPersistence(
            persistenceConfigurationDelegateProvider
        );

        serviceCollection.AddScoped<IUsersService, UsersService>();

        return serviceCollection;
    }
}