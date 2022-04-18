namespace Users.Core.Application;

using System;
using Microsoft.Extensions.DependencyInjection;
using Users.Core.Infrastracture;
using Users.Core.Infrastracture.Persistence.Configuration;

public static class IServiceCollectionExtension
{
    public static IServiceCollection AddApplication(
        this IServiceCollection serviceCollection,
        Func<IServiceProvider, PersistenceConfiguration> persistenceConfigurationDelegateProvider)
    {
        serviceCollection.AddPersistence(
            persistenceConfigurationDelegateProvider
        );

        return serviceCollection;
    }
}