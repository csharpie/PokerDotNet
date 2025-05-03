using PokerDotNet.Application.Interfaces;
using PokerDotNet.Domain.Enums;
using PokerDotNet.Domain.Models;

namespace PokerDotNet.Application.Services;

public class DeckService : IDeckService
{
    private const int TOTAL_NUMBER_OF_CARDS = 52;
    private static readonly Random Random = new();

    public List<Card> Cards { get; set; } = [];

    public DeckService()
    {
        while (TOTAL_NUMBER_OF_CARDS != Cards.Count) {
            for (int i = 1; i <= 13; i++)
            {
                string name = i switch
                {
                    1 => "Ace",
                    11 => "Jack",
                    12 => "Queen",
                    13 => "King",
                    _ => i.ToString(),
                };

                var diamondCard = new Card(name, Suit.Diamonds, $"{name} of {Enum.GetName(Suit.Diamonds)}");
                var clubCard = new Card(name, Suit.Clubs, $"{name} of {Enum.GetName(Suit.Clubs)}");
                var heartCard = new Card(name, Suit.Hearts, $"{name} of {Enum.GetName(Suit.Hearts)}");
                var spadeCard = new Card(name, Suit.Hearts, $"{name} of {Enum.GetName(Suit.Spades)}");

                Cards.Add(diamondCard);
                Cards.Add(clubCard);
                Cards.Add(heartCard);
                Cards.Add(spadeCard);
            }
        }
    }

    public Card Draw()
    {
        Card drawnCard;

        if (default == Cards.Count)
            throw new InvalidOperationException("You cannot draw from an empty deck.");
        else {
            drawnCard = Cards[default];
            Cards.Remove(drawnCard);    
        }
        return drawnCard;
    }

    public void Shuffle()
    {
        Cards = [.. Cards.OrderBy(_ => Random.Next())];
    }
}
