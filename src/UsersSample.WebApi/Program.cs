using Microsoft.OpenApi.Models;
using UsersSample.Application;
using UsersSample.Core.Infrastracture.Persistence.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplication(
    _ => PersistenceConfiguration.FromEnvVars()
);

builder.Services.AddRouting(options =>
{
    options.LowercaseUrls = true;
});

builder.Services.AddApiVersioning();

builder.Services.AddVersionedApiExplorer(options =>
{
    // The format of the version added to the route URL
    options.GroupNameFormat = "'v'VVV";
    // Tells swagger to replace the version in the controller route
    options.SubstituteApiVersionInUrl = true;
});

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Users API", Version = "v1" });
    options.OrderActionsBy((apiDesc) => apiDesc.RelativePath);
    options.EnableAnnotations();
});


var app = builder.Build();

app.UseSwagger();

app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Users API V1");
    options.EnableDeepLinking();
    options.RoutePrefix = string.Empty;
});

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();