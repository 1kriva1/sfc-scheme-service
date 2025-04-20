using SFC.Scheme.Application.Common.Dto.Identity;
using SFC.Scheme.Application.Common.Enums;
using SFC.Scheme.Application.Features.Common.Base;

namespace SFC.Scheme.Application.Features.Identity.Commands.Create;
public class CreateUserCommand : Request
{
    public override RequestId RequestId { get => RequestId.CreateUser; }

    public UserDto User { get; set; } = null!;
}