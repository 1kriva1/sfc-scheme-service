using SFC.Scheme.Application.Common.Enums;
using SFC.Scheme.Application.Features.Common.Base;

namespace SFC.Scheme.Application.Features.Scheme.Commands.Update;
public class UpdateSchemeCommand : Request
{
    public override RequestId RequestId { get => RequestId.UpdateScheme; }

    public long SchemeId { get; set; }

    public required UpdateSchemeDto Scheme { get; set; }

    public UpdateSchemeCommand SetSchemeId(long id)
    {
        SchemeId = id;
        return this;
    }
}