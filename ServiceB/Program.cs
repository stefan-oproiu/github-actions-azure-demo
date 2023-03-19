var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddEnvironmentVariables();

var app = builder.Build();

app.MapGet("/api/internal", async (ctx) =>
{
    var config = ctx.RequestServices.GetRequiredService<IConfiguration>();
    var message = config["CONFIG_MESSAGE"];

    if (string.IsNullOrWhiteSpace(message))
    {
        ctx.Response.StatusCode = StatusCodes.Status404NotFound;
    }

    await ctx.Response.WriteAsync(message);
});

var logger = app.Services.GetRequiredService<ILogger<Program>>();
var config = app.Services.GetRequiredService<IConfiguration>()["ConfigMessage"];
logger.LogInformation($"ConfigMessage: {config}");

app.Run();