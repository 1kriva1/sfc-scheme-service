using FluentValidation;

using SFC.Scheme.Application.Common.Constants;
using SFC.Scheme.Application.Common.Extensions;
using SFC.Scheme.Application.Features.Common.Dto.Common;
using SFC.Scheme.Application.Features.Common.Validators.Common;
using SFC.Scheme.Application.Features.Scheme.Game.Team.Queries.Find.Dto.Filters;

namespace SFC.Scheme.Application.Features.Scheme.Game.Team.Queries.Find;
public class GetGameTeamSchemesQueryValidator : AbstractValidator<GetGameTeamSchemesQuery>
{
    public GetGameTeamSchemesQueryValidator()
    {
        // pagination request validation
        RuleFor(command => command)
            .SetValidator(new PaginationRequestValidator<GetGameTeamSchemesViewModel, GetGameTeamSchemesFilterDto>());

        // common
        When(p => p.Filter is not null, () =>
        {
            RuleFor(p => p.Filter!.GameId)
               .NotEmpty()
               .WithName(nameof(GetGameTeamSchemesFilterDto.GameId))
               .OverridePropertyName($"Route.{nameof(GetGameTeamSchemesFilterDto.GameId)}")
               .WithMessage(Localization.MustNotBeEmpty);

            RuleFor(p => p.Filter!.TeamId)
               .NotEmpty()
               .WithName(nameof(GetGameTeamSchemesFilterDto.TeamId))
               .OverridePropertyName($"Route.{nameof(GetGameTeamSchemesFilterDto.TeamId)}")
               .WithMessage(Localization.MustNotBeEmpty);
        });

        // profile
        // general
        When(p => p.Filter?.Profile?.General != null, () =>
        {
            RuleFor(p => p.Filter!.Profile!.General!.Name)
                    .MaximumLength(ValidationConstants.NameValueMaxLength)
                    .WithName(nameof(GetGameTeamSchemesGeneralProfileFilterDto.Name));

            RuleFor(p => p.Filter!.Profile!.General!.Comment)
                    .MaximumLength(ValidationConstants.DescriptionValueMaxLength)
                    .WithName(nameof(GetGameTeamSchemesGeneralProfileFilterDto.Comment));
        });

        // players
        When(p => p.Filter?.Formation?.Players != null, () =>
        {
            When(p => (p.Filter.Formation?.Players!.Stats!.Total?.From.HasValue ?? false) && (p.Filter.Formation?.Players!.Stats!.Total?.To.HasValue ?? false), () =>
            {
#pragma warning disable CS8629 // Nullable value type may be null.
                RuleFor(p => p.Filter!.Formation!.Players!.Stats!.Total!.To)
                            .GreaterThanOrEqualTo(p => p.Filter!.Formation!.Players!.Stats!.Total!.From.Value)
                            .WithMessage(Localization.MustBeGreaterThan.BuildValidationMessage(nameof(RangeLimitDto<short?>.To), nameof(RangeLimitDto<short?>.From)));

                RuleFor(p => p.Filter!.Formation!.Players!.Stats!.Total!.From)
                            .LessThanOrEqualTo(p => p.Filter!.Formation!.Players!.Stats!.Total!.To.Value)
                            .WithMessage(Localization.MustBeLessThan.BuildValidationMessage(nameof(RangeLimitDto<short?>.From), nameof(RangeLimitDto<short?>.To)));
#pragma warning restore CS8629 // Nullable value type may be null.
            });
        });
    }
}