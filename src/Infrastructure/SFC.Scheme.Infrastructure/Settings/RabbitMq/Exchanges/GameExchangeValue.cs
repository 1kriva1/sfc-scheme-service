using SFC.Scheme.Infrastructure.Settings.RabbitMq.Exchanges.Common.Data;
using SFC.Scheme.Infrastructure.Settings.RabbitMq.Exchanges.Common.Domain;

namespace SFC.Scheme.Infrastructure.Settings.RabbitMq.Exchanges;
public class GameExchangeValue
{
    public DataExchange<GameDataDependentExchange> Data { get; set; } = default!;

    public GameDomainExchange Domain { get; set; } = default!;
}

public class GameDataDependentExchange
{
    public DataDependentExchange Scheme { get; set; } = default!;
}

public class GameDomainExchange
{
    public DomainExchange<GameDomainEventsExchange> Game { get; set; } = default!;

    public DomainExchange<GamePlayerDomainEventsExchange> Player { get; set; } = default!;

    public GameTeamDomainExchange Team { get; set; } = default!;
}

public class GameTeamDomainExchange
{
    public DomainExchange<GameTeamPlayerDomainEventsExchange> Player { get; set; } = default!;

    public DomainExchange<GameTeamTeamDomainEventsExchange> Team { get; set; } = default!;
}

public class GameDomainEventsExchange
{
    public Exchange Created { get; set; } = default!;

    public Exchange Updated { get; set; } = default!;
}

public class GamePlayerDomainEventsExchange
{
    public Exchange Created { get; set; } = default!;

    public Exchange Updated { get; set; } = default!;
}

public class GameTeamTeamDomainEventsExchange
{
    public Exchange Created { get; set; } = default!;

    public Exchange Updated { get; set; } = default!;
}

public class GameTeamPlayerDomainEventsExchange
{
    public Exchange Created { get; set; } = default!;

    public Exchange Updated { get; set; } = default!;

    public Exchange Deleted { get; set; } = default!;
}