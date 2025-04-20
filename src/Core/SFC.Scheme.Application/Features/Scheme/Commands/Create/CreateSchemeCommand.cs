using SFC.Scheme.Application.Common.Enums;
using SFC.Scheme.Application.Features.Common.Base;
using SFC.Scheme.Application.Features.Scheme.Common.Dto;

namespace SFC.Scheme.Application.Features.Scheme.Commands.Create;
public class CreateSchemeCommand : Request<CreateSchemeViewModel>
{
    public override RequestId RequestId { get => RequestId.CreateScheme; }

    public CreateSchemeDto Scheme { get; set; } = null!;
}