﻿using AutoMapper;

using MediatR;

using SFC.Scheme.Application.Interfaces.Persistence.Repository.Identity;
using SFC.Scheme.Domain.Entities.Identity;

namespace SFC.Scheme.Application.Features.Identity.Commands.Create;
public class CreateUserCommandHandler(IMapper mapper, IUserRepository identityUserRepository)
    : IRequestHandler<CreateUserCommand>
{
    private readonly IMapper _mapper = mapper;
    private readonly IUserRepository _identityUserRepository = identityUserRepository;

    public Task Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        User user = _mapper.Map<User>(request.User);
        return _identityUserRepository.AddAsync(user);
    }
}