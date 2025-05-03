using PokerDotNet.Application.Interfaces;
using PokerDotNet.Domain.Enums;
using PokerDotNet.Domain.Models;

namespace PokerDotNet.Application.Services;

public class GameService : IGameService
{
    public Game Game { get; set; }
    public List<Player> Players { get; set; } = [];

    public Game[] GetList()
    {
        return [Game.FiveCardDraw, Game.TexasHoldem, Game.Omaha, Game.JokerPoker, Game.DeucesWild];
    }

    public bool Start(Game game)
    {
        // Game = game;

        // if (Game.FiveCardDraw == Game) {
            
        //     Players.Add(new Player(new Hand([])));
        // }

        throw new NotImplementedException();
    }
}