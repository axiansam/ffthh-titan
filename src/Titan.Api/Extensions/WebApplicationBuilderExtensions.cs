using Serilog;

public static class WebApplicationBuilderExtensions
{
    public static void ConfigureLogging(this WebApplicationBuilder builder)
    {
        builder.Logging.ClearProviders();

        builder.Host.UseSerilog((context, config) =>
        {
            config
                .Enrich.FromLogContext()
                .MinimumLevel.Debug()
                .WriteTo.Console();
        });
    }
}