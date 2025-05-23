using SFC.Scheme.Application.Common.Enums;
using SFC.Scheme.Application.Features.Common.Base;

namespace SFC.Scheme.Application.Features.Scheme.Data.Queries.GetAll;

public class GetAllSchemeDataQuery : Request<GetAllSchemeDataViewModel>
{
    public override RequestId RequestId { get => RequestId.GetAllSchemeData; }
}