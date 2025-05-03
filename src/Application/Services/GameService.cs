using PokerDotNet.Application.Interfaces;
using PokerDotNet.Domain.Enums;
using PokerDotNet.Domain.Models;

namespace PokerDotNet.Application.Services;

public class GameService : IGameService
{
    private readonly IDeckService _deckService;

    public Game Game { get; set; }
    public List<Player> Players { get; set; } = [];
    public List<Game> Games { get; } = [Game.FiveCardDraw, Game.TexasHoldem, Game.Omaha, Game.JokerPoker, Game.DeucesWild];

    public GameService(IDeckService deckService)
    {
        _deckService = deckService;
    }

    public bool Start(Game game)
    {
        if (Game.FiveCardDraw == game) {
            var hand = new Hand([]);

            while(hand.Cards.Count < 5) {
                hand.Cards.Add(_deckService.Draw());
            }

            Players.Add(new Player(hand));
        }

        return true;
    }
}