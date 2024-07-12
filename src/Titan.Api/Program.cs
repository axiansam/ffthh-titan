using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.ConfigureLogging();

builder.Services
    .AddVersioning()
    .AddSwagger();

var app = builder.Build();

app.MapEndpoints();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(config =>
    {
        var descriptions = app.DescribeApiVersions();

        foreach (var description in descriptions)
        {
            var url = $"/swagger/{description.GroupName}/swagger.json";
            var name = description.GroupName.ToUpperInvariant();

            config.SwaggerEndpoint(url, name);
        }
    });
}

app.UseHttpsRedirection();
app.UseSerilogRequestLogging();
app.Run();
