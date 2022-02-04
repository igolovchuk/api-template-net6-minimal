using Serilog;

namespace ApiTemplate.Shared.Extensions;

internal static class AppBuilderExtensions
{
    internal static WebApplicationBuilder ConfigureBuilder(this WebApplicationBuilder builder)
    {
        builder.AddHealthChecks();
        builder.Services.AddApplicationSevices();
        builder.Services.AddValidation();
        builder.Services.AddAutoMapper();

        builder.WebHost.UseSerilog((context, config) => config.ReadFrom.Configuration(context.Configuration));

        return builder;
    }

    private static WebApplicationBuilder AddHealthChecks(this WebApplicationBuilder builder)
    {
        return builder;
    }
}


