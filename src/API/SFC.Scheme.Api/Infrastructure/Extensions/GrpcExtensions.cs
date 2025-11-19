using SFC.Scheme.Api.Services;

namespace SFC.Scheme.Api.Infrastructure.Extensions;

public static class GrpcExtensions
{
    public static WebApplication UseGrpc(this WebApplication app)
    {
        app.MapGrpcService<SchemeDataService>();
        app.MapGrpcService<TeamSchemeService>();

        return app;
    }
}