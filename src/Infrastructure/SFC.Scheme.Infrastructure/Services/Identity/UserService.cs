using Microsoft.AspNetCore.Http;

using SFC.Scheme.Application.Interfaces.Identity;
using SFC.Scheme.Infrastructure.Extensions;

namespace SFC.Scheme.Infrastructure.Services.Identity;
public class UserService(IHttpContextAccessor httpContextAccessor) : IUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

    public Guid? GetUserId() => _httpContextAccessor.GetUserId();
}