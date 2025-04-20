using SFC.Scheme.Application.Common.Enums;
using SFC.Scheme.Application.Features.Common.Base;

namespace SFC.Scheme.Application.Features.Scheme.Queries.Get;

public class GetSchemeQuery : Request<GetSchemeViewModel>
{
    public override RequestId RequestId { get => RequestId.GetScheme; }

    public long Id { get; set; }
}