using AutoMapper;

using SFC.Scheme.Application.Common.Dto.Identity;
using SFC.Scheme.Application.Interfaces.Identity;
using SFC.Scheme.Application.Interfaces.Persistence.Repository.Identity;
using SFC.Scheme.Application.Interfaces.Reference;
using SFC.Scheme.Domain.Entities.Identity;

namespace SFC.Scheme.Infrastructure.Services.Reference;
public class IdentityReference(
    IMapper mapper,
    IUserRepository userRepository,
    IIdentityService identityService) : BaseReference<User, Guid, UserDto>(mapper), IIdentityReference
{
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IIdentityService _identityService = identityService;

    protected override Task<User?> GetFromLocalAsync(Guid id, CancellationToken cancellationToken = default)
        => _userRepository.GetByIdAsync(id);

    protected override Task<UserDto?> GetFromReferenceAsync(Guid id, CancellationToken cancellationToken = default)
        => _identityService.GetUserAsync(id, cancellationToken);

    protected override Task<User> AddLocalAsync(User entity, CancellationToken cancellationToken = default)
        => _userRepository.AddAsync(entity);
}