using Microsoft.AspNetCore.Authorization;

using SFC.Scheme.Infrastructure.Authorization.OwnPlayer;
using SFC.Scheme.Infrastructure.Authorization.OwnScheme;
using SFC.Scheme.Infrastructure.Authorization.OwnTeam;
using SFC.Scheme.Infrastructure.Constants;

namespace SFC.Scheme.Infrastructure.Authorization;
public static class AuthorizationPolicies
{
    #region Public

    public static PolicyModel General(IDictionary<string, IEnumerable<string>> claims)
    {
        ArgumentNullException.ThrowIfNull(claims);

        AuthorizationPolicyBuilder builder = GetGeneralPolicyBuilder(claims);
        return BuildPolicyModel(Policy.General, builder);
    }

    public static PolicyModel OwnScheme(IDictionary<string, IEnumerable<string>> claims)
    {
        AuthorizationPolicyBuilder builder = GetGeneralPolicyBuilder(claims)
            .AddRequirements(new OwnSchemeRequirement());

        return BuildPolicyModel(Policy.OwnScheme, builder);
    }

    public static PolicyModel OwnPlayer(IDictionary<string, IEnumerable<string>> claims)
    {
        AuthorizationPolicyBuilder builder = GetGeneralPolicyBuilder(claims)
            .AddRequirements(new OwnPlayerRequirement());

        return BuildPolicyModel(Policy.OwnPlayer, builder);
    }

    public static PolicyModel OwnTeam(IDictionary<string, IEnumerable<string>> claims)
    {
        AuthorizationPolicyBuilder builder = GetGeneralPolicyBuilder(claims)
            .AddRequirements(new OwnTeamRequirement());

        return BuildPolicyModel(Policy.OwnTeam, builder);
    }

    #endregion Public

    #region Private

    private static AuthorizationPolicyBuilder GetGeneralPolicyBuilder(IDictionary<string, IEnumerable<string>> claims)
    {
        AuthorizationPolicyBuilder builder = new AuthorizationPolicyBuilder()
            .RequireAuthenticatedUser();

        foreach (KeyValuePair<string, IEnumerable<string>> claim in claims)
        {
            builder.RequireClaim(claim.Key, claim.Value);
        }

        return builder;
    }

    private static PolicyModel BuildPolicyModel(string name, AuthorizationPolicyBuilder builder)
    {
        return new PolicyModel { Name = name, Policy = builder.Build() };
    }

    #endregion Private
}