namespace SFC.Scheme.Domain.Common.Interfaces;
public interface IGameEntity
{
    long GameId { get; set; }

    GameEntity Game { get; set; }
}