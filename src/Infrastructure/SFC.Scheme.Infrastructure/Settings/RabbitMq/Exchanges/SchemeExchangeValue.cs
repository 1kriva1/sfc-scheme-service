using SFC.Scheme.Infrastructure.Settings.RabbitMq.Exchanges.Common.Data;
using SFC.Scheme.Infrastructure.Settings.RabbitMq.Exchanges.Common.Domain;

namespace SFC.Scheme.Infrastructure.Settings.RabbitMq.Exchanges;
public class SchemeExchangeValue
{
    public DataExchange<SchemeDataDependentExchange> Data { get; set; } = default!;

    public SchemeDomainExchange Domain { get; set; } = default!;
}

public class SchemeDataDependentExchange
{
    public DataDependentExchange Data { get; set; } = default!;

    public DataDependentExchange Team { get; set; } = default!;

    public DataDependentExchange Game { get; set; } = default!;
}

public class SchemeDomainExchange
{
    public required DomainExchange<TeamSchemeDomainEventsExchange> Team { get; set; }

    public required SchemeGameDomainExchange Game { get; set; }
}

public class SchemeGameDomainExchange
{
    public DomainExchange<GameSchemeDomainEventsExchange> Team { get; set; } = default!;
}

public class TeamSchemeDomainEventsExchange
{
    public Exchange Created { get; set; } = default!;

    public Exchange Updated { get; set; } = default!;
}

public class GameSchemeDomainEventsExchange
{
    public Exchange Created { get; set; } = default!;

    public Exchange Updated { get; set; } = default!;
}