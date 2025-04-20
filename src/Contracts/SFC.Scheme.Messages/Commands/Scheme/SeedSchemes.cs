using SFC.Scheme.Messages.Commands.Common;

namespace SFC.Scheme.Messages.Commands.Scheme;
public class SeedSchemes : InitiatorCommand
{
    public IEnumerable<SchemeEntity> Schemes { get; init; } = [];
}