using Serilog;

namespace Deed.Api.Extensions;

internal static class HostBuilderExtensions
{
    internal static IHostBuilder UseSerilogDependencies(this IHostBuilder builder)
    {
        return builder.UseSerilog((context, loggerConfig) =>
            loggerConfig.ReadFrom.Configuration(context.Configuration));
    }
}
