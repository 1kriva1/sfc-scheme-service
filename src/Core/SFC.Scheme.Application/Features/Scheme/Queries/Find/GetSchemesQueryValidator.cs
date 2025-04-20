using FluentValidation;

using SFC.Scheme.Application.Features.Common.Validators.Common;
using SFC.Scheme.Application.Features.Scheme.Queries.Find.Dto.Filters;

namespace SFC.Scheme.Application.Features.Scheme.Queries.Find;
public class GetSchemesQueryValidator : AbstractValidator<GetSchemesQuery>
{
    public GetSchemesQueryValidator()
    {
        // pagination request validation
        RuleFor(command => command)
            .SetValidator(new PaginationRequestValidator<GetSchemesViewModel, GetSchemesFilterDto>());
    }
}