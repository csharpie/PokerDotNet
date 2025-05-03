using PokerDotNet.Domain.Enums;

namespace PokerDotNet.Application.Interfaces;

public interface IGameService
{
    bool Start(Game game);
}
