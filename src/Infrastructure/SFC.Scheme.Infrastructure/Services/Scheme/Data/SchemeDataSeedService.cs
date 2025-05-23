using SFC.Scheme.Application.Interfaces.Common;
using SFC.Scheme.Application.Interfaces.Metadata;
using SFC.Scheme.Application.Interfaces.Persistence.Repository.Scheme.Data;
using SFC.Scheme.Application.Interfaces.Scheme.Data;
using SFC.Scheme.Domain.Entities.Scheme.Data;
using SFC.Scheme.Infrastructure.Persistence.Extensions;

namespace SFC.Scheme.Infrastructure.Services.Scheme.Data;
public class SchemeDataSeedService(
    IMetadataService metadataService,
    IDateTimeService dateTimeService,
    IFormationPositionRepository formationPositionRepository,
    IFormationRepository formationRepository) : ISchemeDataSeedService
{
    private readonly IMetadataService _metadataService = metadataService;
    private readonly IFormationPositionRepository _formationPositionRepository = formationPositionRepository;
    private readonly IFormationRepository _formationRepository = formationRepository;

    #region Stub data

    private readonly List<FormationValue> _formationValues =
    [
        new FormationValue { Id = 0, FormationId = FormationEnum.PowerfullAttacking, Line = 0, Index = 0, FormationPositionId = FormationPositionEnum.GK, CreatedDate = dateTimeService.Now },
        new FormationValue { Id = 1, FormationId = FormationEnum.PowerfullAttacking, Line = 1, Index = 0, FormationPositionId = FormationPositionEnum.LB, CreatedDate = dateTimeService.Now },
        new FormationValue { Id = 2, FormationId = FormationEnum.PowerfullAttacking, Line = 1, Index = 1, FormationPositionId = FormationPositionEnum.CB, CreatedDate = dateTimeService.Now },
        new FormationValue { Id = 3, FormationId = FormationEnum.PowerfullAttacking, Line = 1, Index = 2, FormationPositionId = FormationPositionEnum.RB, CreatedDate = dateTimeService.Now },
        new FormationValue { Id = 4, FormationId = FormationEnum.PowerfullAttacking, Line = 2, Index = 0, FormationPositionId = FormationPositionEnum.LM, CreatedDate = dateTimeService.Now },
        new FormationValue { Id = 5, FormationId = FormationEnum.PowerfullAttacking, Line = 2, Index = 1, FormationPositionId = FormationPositionEnum.CM, CreatedDate = dateTimeService.Now },
        new FormationValue { Id = 6, FormationId = FormationEnum.PowerfullAttacking, Line = 2, Index = 2, FormationPositionId = FormationPositionEnum.CM, CreatedDate = dateTimeService.Now },
        new FormationValue { Id = 7, FormationId = FormationEnum.PowerfullAttacking, Line = 2, Index = 3, FormationPositionId = FormationPositionEnum.RM, CreatedDate = dateTimeService.Now },
        new FormationValue { Id = 8, FormationId = FormationEnum.PowerfullAttacking, Line = 3, Index = 0, FormationPositionId = FormationPositionEnum.LF, CreatedDate = dateTimeService.Now },
        new FormationValue { Id = 9, FormationId = FormationEnum.PowerfullAttacking, Line = 3, Index = 1, FormationPositionId = FormationPositionEnum.CF, CreatedDate = dateTimeService.Now },
        new FormationValue { Id = 10, FormationId = FormationEnum.PowerfullAttacking, Line = 3, Index = 2, FormationPositionId = FormationPositionEnum.RF, CreatedDate = dateTimeService.Now },

        new FormationValue { Id = 11, FormationId = FormationEnum.Control, Line = 0, Index = 0, FormationPositionId = FormationPositionEnum.GK, CreatedDate = dateTimeService.Now },
        new FormationValue { Id = 12, FormationId = FormationEnum.Control, Line = 1, Index = 0, FormationPositionId = FormationPositionEnum.LB, CreatedDate = dateTimeService.Now },
        new FormationValue { Id = 13, FormationId = FormationEnum.Control, Line = 1, Index = 1, FormationPositionId = FormationPositionEnum.CB, CreatedDate = dateTimeService.Now },
        new FormationValue { Id = 14, FormationId = FormationEnum.Control, Line = 1, Index = 2, FormationPositionId = FormationPositionEnum.RB, CreatedDate = dateTimeService.Now },
        new FormationValue { Id = 15, FormationId = FormationEnum.Control, Line = 2, Index = 0, FormationPositionId = FormationPositionEnum.LM, CreatedDate = dateTimeService.Now },
        new FormationValue { Id = 16, FormationId = FormationEnum.Control, Line = 2, Index = 1, FormationPositionId = FormationPositionEnum.CM, CreatedDate = dateTimeService.Now },
        new FormationValue { Id = 17, FormationId = FormationEnum.Control, Line = 2, Index = 2, FormationPositionId = FormationPositionEnum.CM, CreatedDate = dateTimeService.Now },
        new FormationValue { Id = 18, FormationId = FormationEnum.Control, Line = 2, Index = 3, FormationPositionId = FormationPositionEnum.CM, CreatedDate = dateTimeService.Now },
        new FormationValue { Id = 19, FormationId = FormationEnum.Control, Line = 2, Index = 4, FormationPositionId = FormationPositionEnum.RM, CreatedDate = dateTimeService.Now },
        new FormationValue { Id = 20, FormationId = FormationEnum.Control, Line = 3, Index = 0, FormationPositionId = FormationPositionEnum.LF, CreatedDate = dateTimeService.Now },
        new FormationValue { Id = 21, FormationId = FormationEnum.Control, Line = 3, Index = 1, FormationPositionId = FormationPositionEnum.RF, CreatedDate = dateTimeService.Now },

        new FormationValue { Id = 22, FormationId = FormationEnum.Defend, Line = 0, Index = 0, FormationPositionId = FormationPositionEnum.GK, CreatedDate = dateTimeService.Now },
        new FormationValue { Id = 23, FormationId = FormationEnum.Defend, Line = 1, Index = 0, FormationPositionId = FormationPositionEnum.LB, CreatedDate = dateTimeService.Now },
        new FormationValue { Id = 24, FormationId = FormationEnum.Defend, Line = 1, Index = 1, FormationPositionId = FormationPositionEnum.CB, CreatedDate = dateTimeService.Now },
        new FormationValue { Id = 25, FormationId = FormationEnum.Defend, Line = 1, Index = 2, FormationPositionId = FormationPositionEnum.CB, CreatedDate = dateTimeService.Now },
        new FormationValue { Id = 26, FormationId = FormationEnum.Defend, Line = 1, Index = 3, FormationPositionId = FormationPositionEnum.RB, CreatedDate = dateTimeService.Now },
        new FormationValue { Id = 27, FormationId = FormationEnum.Defend, Line = 2, Index = 0, FormationPositionId = FormationPositionEnum.LM, CreatedDate = dateTimeService.Now },
        new FormationValue { Id = 28, FormationId = FormationEnum.Defend, Line = 2, Index = 1, FormationPositionId = FormationPositionEnum.CM, CreatedDate = dateTimeService.Now },
        new FormationValue { Id = 29, FormationId = FormationEnum.Defend, Line = 2, Index = 2, FormationPositionId = FormationPositionEnum.CM, CreatedDate = dateTimeService.Now },
        new FormationValue { Id = 30, FormationId = FormationEnum.Defend, Line = 2, Index = 3, FormationPositionId = FormationPositionEnum.CM, CreatedDate = dateTimeService.Now },
        new FormationValue { Id = 31, FormationId = FormationEnum.Defend, Line = 2, Index = 4, FormationPositionId = FormationPositionEnum.RM, CreatedDate = dateTimeService.Now },
        new FormationValue { Id = 32, FormationId = FormationEnum.Defend, Line = 3, Index = 0, FormationPositionId = FormationPositionEnum.ST, CreatedDate = dateTimeService.Now },

        new FormationValue { Id = 33, FormationId = FormationEnum.Atacking, Line = 0, Index = 0, FormationPositionId = FormationPositionEnum.GK, CreatedDate = dateTimeService.Now },
        new FormationValue { Id = 34, FormationId = FormationEnum.Atacking, Line = 1, Index = 0, FormationPositionId = FormationPositionEnum.LB, CreatedDate = dateTimeService.Now },
        new FormationValue { Id = 35, FormationId = FormationEnum.Atacking, Line = 1, Index = 1, FormationPositionId = FormationPositionEnum.CB, CreatedDate = dateTimeService.Now },
        new FormationValue { Id = 36, FormationId = FormationEnum.Atacking, Line = 1, Index = 2, FormationPositionId = FormationPositionEnum.CB, CreatedDate = dateTimeService.Now },
        new FormationValue { Id = 37, FormationId = FormationEnum.Atacking, Line = 1, Index = 3, FormationPositionId = FormationPositionEnum.RB, CreatedDate = dateTimeService.Now },
        new FormationValue { Id = 38, FormationId = FormationEnum.Atacking, Line = 2, Index = 0, FormationPositionId = FormationPositionEnum.LM, CreatedDate = dateTimeService.Now },
        new FormationValue { Id = 39, FormationId = FormationEnum.Atacking, Line = 2, Index = 1, FormationPositionId = FormationPositionEnum.CM, CreatedDate = dateTimeService.Now },
        new FormationValue { Id = 40, FormationId = FormationEnum.Atacking, Line = 2, Index = 2, FormationPositionId = FormationPositionEnum.RM, CreatedDate = dateTimeService.Now },
        new FormationValue { Id = 41, FormationId = FormationEnum.Atacking, Line = 3, Index = 0, FormationPositionId = FormationPositionEnum.LF, CreatedDate = dateTimeService.Now },
        new FormationValue { Id = 42, FormationId = FormationEnum.Atacking, Line = 3, Index = 1, FormationPositionId = FormationPositionEnum.CF, CreatedDate = dateTimeService.Now },
        new FormationValue { Id = 43, FormationId = FormationEnum.Atacking, Line = 3, Index = 2, FormationPositionId = FormationPositionEnum.RF, CreatedDate = dateTimeService.Now },

        new FormationValue { Id = 44, FormationId = FormationEnum.Balanced, Line = 0, Index = 0, FormationPositionId = FormationPositionEnum.GK, CreatedDate = dateTimeService.Now },
        new FormationValue { Id = 45, FormationId = FormationEnum.Balanced, Line = 1, Index = 0, FormationPositionId = FormationPositionEnum.LB, CreatedDate = dateTimeService.Now },
        new FormationValue { Id = 46, FormationId = FormationEnum.Balanced, Line = 1, Index = 1, FormationPositionId = FormationPositionEnum.CB, CreatedDate = dateTimeService.Now },
        new FormationValue { Id = 47, FormationId = FormationEnum.Balanced, Line = 1, Index = 2, FormationPositionId = FormationPositionEnum.CB, CreatedDate = dateTimeService.Now },
        new FormationValue { Id = 48, FormationId = FormationEnum.Balanced, Line = 1, Index = 3, FormationPositionId = FormationPositionEnum.RB, CreatedDate = dateTimeService.Now },
        new FormationValue { Id = 49, FormationId = FormationEnum.Balanced, Line = 2, Index = 0, FormationPositionId = FormationPositionEnum.LM, CreatedDate = dateTimeService.Now },
        new FormationValue { Id = 50, FormationId = FormationEnum.Balanced, Line = 2, Index = 1, FormationPositionId = FormationPositionEnum.CM, CreatedDate = dateTimeService.Now },
        new FormationValue { Id = 51, FormationId = FormationEnum.Balanced, Line = 2, Index = 2, FormationPositionId = FormationPositionEnum.CM, CreatedDate = dateTimeService.Now },
        new FormationValue { Id = 52, FormationId = FormationEnum.Balanced, Line = 2, Index = 3, FormationPositionId = FormationPositionEnum.RM, CreatedDate = dateTimeService.Now },
        new FormationValue { Id = 53, FormationId = FormationEnum.Balanced, Line = 3, Index = 0, FormationPositionId = FormationPositionEnum.LF, CreatedDate = dateTimeService.Now },
        new FormationValue { Id = 54, FormationId = FormationEnum.Balanced, Line = 3, Index = 1, FormationPositionId = FormationPositionEnum.RF, CreatedDate = dateTimeService.Now },

        new FormationValue { Id = 55, FormationId = FormationEnum.BoxToBox, Line = 0, Index = 0, FormationPositionId = FormationPositionEnum.GK, CreatedDate = dateTimeService.Now },
        new FormationValue { Id = 56, FormationId = FormationEnum.BoxToBox, Line = 1, Index = 0, FormationPositionId = FormationPositionEnum.LB, CreatedDate = dateTimeService.Now },
        new FormationValue { Id = 57, FormationId = FormationEnum.BoxToBox, Line = 1, Index = 1, FormationPositionId = FormationPositionEnum.CB, CreatedDate = dateTimeService.Now },
        new FormationValue { Id = 58, FormationId = FormationEnum.BoxToBox, Line = 1, Index = 2, FormationPositionId = FormationPositionEnum.RB, CreatedDate = dateTimeService.Now },
        new FormationValue { Id = 59, FormationId = FormationEnum.BoxToBox, Line = 2, Index = 0, FormationPositionId = FormationPositionEnum.CDM, CreatedDate = dateTimeService.Now },
        new FormationValue { Id = 60, FormationId = FormationEnum.BoxToBox, Line = 3, Index = 0, FormationPositionId = FormationPositionEnum.LM, CreatedDate = dateTimeService.Now },
        new FormationValue { Id = 61, FormationId = FormationEnum.BoxToBox, Line = 3, Index = 1, FormationPositionId = FormationPositionEnum.CM, CreatedDate = dateTimeService.Now },
        new FormationValue { Id = 62, FormationId = FormationEnum.BoxToBox, Line = 3, Index = 2, FormationPositionId = FormationPositionEnum.RM, CreatedDate = dateTimeService.Now },
        new FormationValue { Id = 63, FormationId = FormationEnum.BoxToBox, Line = 4, Index = 0, FormationPositionId = FormationPositionEnum.LW, CreatedDate = dateTimeService.Now },
        new FormationValue { Id = 64, FormationId = FormationEnum.BoxToBox, Line = 4, Index = 1, FormationPositionId = FormationPositionEnum.ST, CreatedDate = dateTimeService.Now },
        new FormationValue { Id = 65, FormationId = FormationEnum.BoxToBox, Line = 4, Index = 2, FormationPositionId = FormationPositionEnum.RW, CreatedDate = dateTimeService.Now },

        new FormationValue { Id = 66, FormationId = FormationEnum.FakeNine, Line = 0, Index = 0, FormationPositionId = FormationPositionEnum.GK, CreatedDate = dateTimeService.Now },
        new FormationValue { Id = 67, FormationId = FormationEnum.FakeNine, Line = 1, Index = 0, FormationPositionId = FormationPositionEnum.CB, CreatedDate = dateTimeService.Now },
        new FormationValue { Id = 68, FormationId = FormationEnum.FakeNine, Line = 2, Index = 0, FormationPositionId = FormationPositionEnum.LWB, CreatedDate = dateTimeService.Now },
        new FormationValue { Id = 69, FormationId = FormationEnum.FakeNine, Line = 2, Index = 1, FormationPositionId = FormationPositionEnum.CDM, CreatedDate = dateTimeService.Now },
        new FormationValue { Id = 70, FormationId = FormationEnum.FakeNine, Line = 2, Index = 2, FormationPositionId = FormationPositionEnum.RWB, CreatedDate = dateTimeService.Now },
        new FormationValue { Id = 71, FormationId = FormationEnum.FakeNine, Line = 3, Index = 0, FormationPositionId = FormationPositionEnum.LM, CreatedDate = dateTimeService.Now },
        new FormationValue { Id = 72, FormationId = FormationEnum.FakeNine, Line = 3, Index = 1, FormationPositionId = FormationPositionEnum.CM, CreatedDate = dateTimeService.Now },
        new FormationValue { Id = 73, FormationId = FormationEnum.FakeNine, Line = 3, Index = 2, FormationPositionId = FormationPositionEnum.RM, CreatedDate = dateTimeService.Now },
        new FormationValue { Id = 74, FormationId = FormationEnum.FakeNine, Line = 4, Index = 0, FormationPositionId = FormationPositionEnum.CAM, CreatedDate = dateTimeService.Now },
        new FormationValue { Id = 75, FormationId = FormationEnum.FakeNine, Line = 5, Index = 0, FormationPositionId = FormationPositionEnum.LF, CreatedDate = dateTimeService.Now },
        new FormationValue { Id = 76, FormationId = FormationEnum.FakeNine, Line = 5, Index = 1, FormationPositionId = FormationPositionEnum.RF, CreatedDate = dateTimeService.Now }
    ];

    #endregion

    #region Public

    public async Task SeedDataAsync(CancellationToken cancellationToken = default)
    {
        IEnumerable<FormationPosition> formationPositions = SeedExtensions.GetSeedDataEnumValues<FormationPosition, FormationPositionEnum>(@enum =>
            ConvertFormationPosition(@enum).SetCreatedDate(dateTimeService));

        await _formationPositionRepository.ResetAsync(formationPositions.ToArray())
                                          .ConfigureAwait(false);

        IEnumerable<Formation> formations = SeedExtensions.GetSeedDataEnumValues<Formation, FormationEnum>(@enum =>
            new Formation(@enum, _formationValues.Where(value => value.FormationId == @enum).ToList()).SetCreatedDate(dateTimeService));

        await _formationRepository.ResetAsync(formations.ToArray())
                                  .ConfigureAwait(false);

        await _metadataService.CompleteAsync(MetadataServiceEnum.Scheme, MetadataDomainEnum.Data, MetadataTypeEnum.Initialization).ConfigureAwait(false);
    }

    #endregion Public

    #region Private

    private static FormationPosition ConvertFormationPosition(FormationPositionEnum @enum)
    {
        FormationPosition position = new(@enum);

        switch (position.Id)
        {
            case FormationPositionEnum.GK:
                position.FootballPositionId = FootballPositionEnum.Goalkeeper;
                break;
            case FormationPositionEnum.LB:
            case FormationPositionEnum.RB:
            case FormationPositionEnum.CB:
            case FormationPositionEnum.LWB:
            case FormationPositionEnum.RWB:
                position.FootballPositionId = FootballPositionEnum.Defender;
                break;
            case FormationPositionEnum.LM:
            case FormationPositionEnum.RM:
            case FormationPositionEnum.CM:
            case FormationPositionEnum.CDM:
            case FormationPositionEnum.CAM:
                position.FootballPositionId = FootballPositionEnum.Midfielder;
                break;
            case FormationPositionEnum.LF:
            case FormationPositionEnum.RF:
            case FormationPositionEnum.CF:
            case FormationPositionEnum.ST:
            case FormationPositionEnum.LW:
            case FormationPositionEnum.RW:
                position.FootballPositionId = FootballPositionEnum.Forward;
                break;
        }

        return position;
    }

    #endregion Private
}