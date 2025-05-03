using PokerDotNet.Domain.Enums;

namespace PokerDotNet.Application.Interfaces;

public interface IGameService
{
    Game[] GetList();
    bool Start(Game game);
}
