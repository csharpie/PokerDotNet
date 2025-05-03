using PokerDotNet.Domain.Enums;

namespace PokerDotNet.Domain.Models;

public record Card(string Name, Suit Suit, string DisplayValue);
