namespace ApiTemplate.Shared.Extensions;

internal static class WebApplicationExtensions
{
    internal static WebApplication ConfigureApp(this WebApplication app)
    {
        app.UseModules();
        app.UseMiddleware<ExceptionMiddleware>();

        return app;
    }
}
