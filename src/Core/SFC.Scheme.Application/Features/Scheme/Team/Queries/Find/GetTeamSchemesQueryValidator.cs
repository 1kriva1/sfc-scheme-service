using FluentValidation;

using SFC.Scheme.Application.Common.Constants;
using SFC.Scheme.Application.Common.Extensions;
using SFC.Scheme.Application.Features.Common.Dto.Common;
using SFC.Scheme.Application.Features.Common.Validators.Common;
using SFC.Scheme.Application.Features.Scheme.Team.Queries.Find.Dto.Filters;

namespace SFC.Scheme.Application.Features.Scheme.Team.Queries.Find;
public class GetTeamSchemesQueryValidator : AbstractValidator<GetTeamSchemesQuery>
{
    public GetTeamSchemesQueryValidator()
    {
        // pagination request validation
        RuleFor(command => command)
            .SetValidator(new PaginationRequestValidator<GetTeamSchemesViewModel, GetTeamSchemesFilterDto>());

        // common
        When(p => p.Filter is not null, () =>
        {
            RuleFor(p => p.Filter!.TeamId)
               .NotEmpty()
               .WithName(nameof(GetTeamSchemesFilterDto.TeamId))
               .OverridePropertyName($"Route.{nameof(GetTeamSchemesFilterDto.TeamId)}")
               .WithMessage(Localization.MustNotBeEmpty);
        });

        // profile
        // general
        When(p => p.Filter?.Profile?.General != null, () =>
        {
            RuleFor(p => p.Filter!.Profile!.General!.Name)
                    .MaximumLength(ValidationConstants.NameValueMaxLength)
                    .WithName(nameof(GetTeamSchemesGeneralProfileFilterDto.Name));

            RuleFor(p => p.Filter!.Profile!.General!.Comment)
                    .MaximumLength(ValidationConstants.DescriptionValueMaxLength)
                    .WithName(nameof(GetTeamSchemesGeneralProfileFilterDto.Comment));
        });

        // players
        When(p => p.Filter?.Players != null, () =>
        {
            When(p => (p.Filter.Players!.Stats!.Total?.From.HasValue ?? false) && (p.Filter.Players!.Stats!.Total?.To.HasValue ?? false), () =>
            {
#pragma warning disable CS8629 // Nullable value type may be null.
                RuleFor(p => p.Filter!.Players!.Stats!.Total!.To)
                            .GreaterThanOrEqualTo(p => p.Filter!.Players!.Stats!.Total!.From.Value)
                            .WithMessage(Localization.MustBeGreaterThan.BuildValidationMessage(nameof(RangeLimitDto<short?>.To), nameof(RangeLimitDto<short?>.From)));

                RuleFor(p => p.Filter!.Players!.Stats!.Total!.From)
                            .LessThanOrEqualTo(p => p.Filter!.Players!.Stats!.Total!.To.Value)
                            .WithMessage(Localization.MustBeLessThan.BuildValidationMessage(nameof(RangeLimitDto<short?>.From), nameof(RangeLimitDto<short?>.To)));
#pragma warning restore CS8629 // Nullable value type may be null.
            });
        });
    }
}