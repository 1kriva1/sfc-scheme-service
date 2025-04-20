using SFC.Scheme.Application.Common.Dto.Common;
using SFC.Scheme.Application.Common.Mappings.Interfaces;
using SFC.Scheme.Domain.Entities.Identity;

namespace SFC.Scheme.Application.Common.Dto.Identity;
public class UserDto : AuditableDto, IMapTo<User>
{
    public Guid Id { get; set; }
}