using Microsoft.AspNetCore.Authorization;

namespace SFC.Scheme.Infrastructure.Authorization.OwnScheme;
public class OwnSchemeRequirement : IAuthorizationRequirement
{
    public OwnSchemeRequirement() { }

    public override string ToString()
    {
        return "OwnSchemeRequirement: Requires user has be owner of resource.";
    }
}