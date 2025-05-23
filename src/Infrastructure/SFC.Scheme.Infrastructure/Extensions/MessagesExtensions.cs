using AutoMapper;

using SFC.Scheme.Application.Interfaces.Scheme.Data.Models;
using SFC.Scheme.Messages.Commands.Common;
using SFC.Scheme.Messages.Events.Scheme.Data;

using SchemeDataValue = SFC.Scheme.Messages.Models.Data.DataValue;
using SchemeFormationDataValue = SFC.Scheme.Messages.Models.Data.FormationDataValue;
using SchemeFormationPositionDataValue = SFC.Scheme.Messages.Models.Data.FormationPositionDataValue;


namespace SFC.Scheme.Infrastructure.Extensions;
public static class MessagesExtensions
{
    public static DataInitialized BuildSchemeDataInitializedEvent(this IMapper mapper, GetAllSchemeDataModel model)
    {
        DataInitialized message = new()
        {
            Formations = mapper.Map<IEnumerable<SchemeFormationDataValue>>(model.Formations),
            FormationPositions = mapper.Map<IEnumerable<SchemeFormationPositionDataValue>>(model.FormationPositions),
            SchemeTypes = mapper.Map<IEnumerable<SchemeDataValue>>(model.SchemeTypes)
        };

        return message;
    }

    public static T SetCommandInitiator<T>(this T command, string initiator) where T : InitiatorCommand
    {
        command.Initiator = initiator;
        return command;
    }
}