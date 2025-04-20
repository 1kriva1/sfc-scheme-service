using SFC.Scheme.Application.Common.Dto.Identity;
using SFC.Scheme.Application.Common.Enums;
using SFC.Scheme.Application.Features.Common.Base;

namespace SFC.Scheme.Application.Features.Identity.Commands.CreateRange;
public class CreateUsersCommand : Request
{
    public override RequestId RequestId { get => RequestId.CreateUsers; }

    public IEnumerable<UserDto> Users { get; set; } = null!;
}