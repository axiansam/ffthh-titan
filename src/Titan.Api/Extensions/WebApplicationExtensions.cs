using Asp.Versioning;

public static class WebApplicationExtensions
{
    public static WebApplication MapEndpoints(this WebApplication app)
    {
        var versionSet = app.NewApiVersionSet()
            .HasApiVersion(new ApiVersion(1))
            .ReportApiVersions()
            .Build();

        var versionedGroup = app.MapGroup("api/v{apiVersion:apiVersion}")
            .WithApiVersionSet(versionSet);

        return app;
    }
}