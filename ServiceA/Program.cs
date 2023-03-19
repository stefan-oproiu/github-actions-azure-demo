var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient();

var app = builder.Build();

app.MapGet("/api/hello", async (ctx) =>
{
    var client = ctx.RequestServices.GetRequiredService<IHttpClientFactory>().CreateClient();
    var url = ctx.RequestServices.GetRequiredService<IConfiguration>()["ServiceBUrl"];
    var response = await client.GetAsync($"{url}/api/internal");

    if (!response.IsSuccessStatusCode)
    {
        ctx.Response.StatusCode = StatusCodes.Status404NotFound;
    }

    var message = await response.Content.ReadAsStringAsync();

    await ctx.Response.WriteAsync(message);
});

app.Run();