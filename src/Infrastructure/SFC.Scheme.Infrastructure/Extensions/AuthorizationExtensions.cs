using Microsoft.AspNetCore.Authorization;

using SFC.Scheme.Infrastructure.Authorization;

namespace SFC.Scheme.Infrastructure.Extensions;
public static class AuthorizationExtensions
{
    public static void AddGeneralPolicy(this AuthorizationOptions options, IDictionary<string, IEnumerable<string>> claims)
    {
        ArgumentNullException.ThrowIfNull(options);

        PolicyModel general = AuthorizationPolicies.General(claims);
        options.AddPolicy(general.Name, general.Policy);
    }

    public static void AddOwnSchemePolicy(this AuthorizationOptions options, IDictionary<string, IEnumerable<string>> claims)
    {
        PolicyModel ownScheme = AuthorizationPolicies.OwnScheme(claims);
        options.AddPolicy(ownScheme.Name, ownScheme.Policy);
    }

    public static void AddOwnPlayerPolicy(this AuthorizationOptions options, IDictionary<string, IEnumerable<string>> claims)
    {
        PolicyModel ownPlayer = AuthorizationPolicies.OwnPlayer(claims);
        options.AddPolicy(ownPlayer.Name, ownPlayer.Policy);
    }

    public static void AddOwnTeamPolicy(this AuthorizationOptions options, IDictionary<string, IEnumerable<string>> claims)
    {
        PolicyModel ownTeam = AuthorizationPolicies.OwnTeam(claims);
        options.AddPolicy(ownTeam.Name, ownTeam.Policy);
    }
}