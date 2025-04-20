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
}

public class SchemeDomainExchange
{
    /// <summary>
    /// Should be replaces by service(s) that required seed for Schemes
    /// </summary>
    public DomainExchange<SchemeSchemeDomainEventsExchange> Scheme { get; set; } = default!;

    public SchemeTeamDomainExchange Team { get; set; } = default!;
}

public class SchemeSchemeDomainEventsExchange
{
    public Exchange Created { get; set; } = default!;

    public Exchange Updated { get; set; } = default!;
}

public class SchemeTeamDomainExchange
{
    public DomainExchange<SchemeTeamPlayerDomainEventsExchange> Player { get; set; } = default!;
}

public class SchemeTeamPlayerDomainEventsExchange
{
    public Exchange Created { get; set; } = default!;

    public Exchange Updated { get; set; } = default!;
}