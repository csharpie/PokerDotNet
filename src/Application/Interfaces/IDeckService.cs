using PokerDotNet.Domain.Models;

namespace PokerDotNet.Application.Interfaces;

public interface IDeckService
{
    public Card Draw();
    public void Shuffle();
}
