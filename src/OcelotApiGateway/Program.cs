using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using OcelotApiGateway.Middlewares;
using OcelotApiGateway.Services.Handlers;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", true, true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", true, true)
    .AddJsonFile("ocelot.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"ocelot.{builder.Environment.EnvironmentName}.json")
    .AddEnvironmentVariables();

builder.Services.AddOcelot(builder.Configuration)
.AddDelegatingHandler<RequestHandler>(true);

builder.Services.AddSwaggerForOcelot(builder.Configuration);

builder.Services.AddControllers();

builder.Services.AddRouting(options => options.LowercaseUrls = true);

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.UseSwaggerForOcelotUI(opt =>
{
    opt.PathToSwaggerGenerator = "/swagger/docs";
    //opt.ReConfigureUpstreamSwaggerJson = SwaggerOcelotTransformsConfig.AlterUpstreamSwaggerJson;
});

await app.UseOcelot();
app.UseMiddleware<CustomMiddleware>();

app.Run();
