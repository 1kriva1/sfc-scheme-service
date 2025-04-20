using SFC.Scheme.Api.Infrastructure.Extensions;
using SFC.Scheme.Api.Services;
using SFC.Scheme.Infrastructure.Constants;
using SFC.Scheme.Infrastructure.Extensions;
using SFC.Scheme.Infrastructure.Settings;

namespace SFC.Scheme.Api.Infrastructure.Extensions;

public static class GrpcExtensions
{
    public static WebApplication UseGrpc(this WebApplication app)
    {
        KestrelSettings settings = app.Configuration.GetKestrelSettings();

        if (settings?.Endpoints?.TryGetValue(SettingConstants.KestrelInternalEndpoint, out KestrelEndpointSettings? endpoint) ?? false)
        {
            app.MapGrpcService<SchemeService>()
               .MapInternalService(endpoint.Url);
        }
        else
        {
            app.MapGrpcService<SchemeService>();
        }

        return app;
    }

    /// <summary>
    /// Without RequireHost WebApi and Grpc not working together
    /// RequireHost distinguish webapi and grpc by port value
    /// Also required Kestrel endpoint configuration in appSettings
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="url"></param>
    private static void MapInternalService(this GrpcServiceEndpointConventionBuilder builder, string url)
        => builder.RequireHost($"*:{new Uri(url).Port}");
}