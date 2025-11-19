using SFC.Scheme.Infrastructure.Constants;

namespace SFC.Scheme.Infrastructure.Extensions;
public static class EnvironmentExtensions
{
    public static bool IsRunningInContainer => Environment.GetEnvironmentVariable(EnvironmentConstants.RunningInContainer) == "true";
}