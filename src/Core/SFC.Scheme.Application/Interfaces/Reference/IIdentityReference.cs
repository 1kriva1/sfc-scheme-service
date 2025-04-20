using SFC.Scheme.Application.Common.Dto.Identity;
using SFC.Scheme.Domain.Entities.Identity;

namespace SFC.Scheme.Application.Interfaces.Reference;

/// <summary>
/// Identity user reference service.
/// </summary>
public interface IIdentityReference : IReference<User, Guid, UserDto> { }