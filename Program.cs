using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<ConfigurationSection>(builder.Configuration.GetSection(ConfigurationSection.Option));
var app = builder.Build();

app.MapGet("/", (IOptions<ConfigurationSection> options) =>
{
    var response = new
    {
        options.Value.Key,
        options.Value.AnotherKey
    };
    return Results.Ok(response);
});

app.Run();

public class ConfigurationSection
{
    public const string Option = "AnyConfigurationSection";
    
    public string? Key { get; set; }
    public string? AnotherKey { get; set; }
}