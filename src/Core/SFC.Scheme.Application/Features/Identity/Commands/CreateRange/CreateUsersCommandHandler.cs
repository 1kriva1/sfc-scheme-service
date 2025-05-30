﻿using AutoMapper;

using MediatR;

using SFC.Scheme.Application.Interfaces.Persistence.Repository.Identity;
using SFC.Scheme.Domain.Entities.Identity;
using SFC.Scheme.Domain.Events.Identity;

namespace SFC.Scheme.Application.Features.Identity.Commands.CreateRange;
public class CreateUsersCommandHandler(
    IMapper mapper,
    IMediator mediator,
    IUserRepository userRepository) : IRequestHandler<CreateUsersCommand>
{
    private readonly IMapper _mapper = mapper;
    private readonly IMediator _mediator = mediator;
    private readonly IUserRepository _userRepository = userRepository;

    public async Task Handle(CreateUsersCommand request, CancellationToken cancellationToken)
    {
        IEnumerable<User> users = _mapper.Map<IEnumerable<User>>(request.Users);

        await _userRepository.AddRangeIfNotExistsAsync([.. users]).ConfigureAwait(false);

        await PublishUsersCreatedEventAsync(users, cancellationToken).ConfigureAwait(false);
    }

    private Task PublishUsersCreatedEventAsync(IEnumerable<User> users, CancellationToken cancellationToken)
    {
        UsersCreatedEvent @event = new(users);
        return _mediator.Publish(@event, cancellationToken);
    }
}