using Users.Core.Application;
using Users.Core.Infrastracture.Persistence.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplication(
    _ => PersistenceConfiguration.FromEnvVars()
);

var app = builder.Build();

app.Run();