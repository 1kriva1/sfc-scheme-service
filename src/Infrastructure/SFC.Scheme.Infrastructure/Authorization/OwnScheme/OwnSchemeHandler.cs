using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

using SFC.Scheme.Application.Interfaces.Persistence.Repository.Scheme;
using SFC.Scheme.Infrastructure.Extensions;

namespace SFC.Scheme.Infrastructure.Authorization.OwnScheme;
public class OwnSchemeHandler(ISchemeRepository schemeRepository, IHttpContextAccessor httpContextAccessor)
    : AuthorizationHandler<OwnSchemeRequirement>
{
    private readonly ISchemeRepository _schemeRepository = schemeRepository;
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

    protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, OwnSchemeRequirement requirement)
    {
        string? schemeIdValue = _httpContextAccessor.HttpContext?.GetRouteValue("id")?.ToString();

        if (!long.TryParse(schemeIdValue, out long schemeId))
        {
            context.Fail(new AuthorizationFailureReason(this, "Route does not have \"id\" parameter value."));
            return;
        }

        Guid? userId = _httpContextAccessor.GetUserId();

        if (!userId.HasValue)
        {
            context.Fail(new AuthorizationFailureReason(this, "User does not have NameIdentifier claim value."));
            return;
        }

        if (!await _schemeRepository.AnyAsync(schemeId, userId.Value).ConfigureAwait(true))
        {
            context.Fail(new AuthorizationFailureReason(this, $"User - {userId} does not related to this resource - {schemeId}."));
            return;
        }

        context.Succeed(requirement);
    }
}