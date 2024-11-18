using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using OcelotApiGateway.Middlewares;
using OcelotApiGateway.Services.Handlers;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);
builder.Services.AddOcelot(builder.Configuration)
    .AddDelegatingHandler<RequestHandler>(true);

builder.Services.AddControllers();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

await app.UseOcelot();
app.UseMiddleware<CustomMiddleware>();

app.Run();
