using Xunit;
using PokerDotNet.Application.Services;

namespace PokerDotNet.Application.UnitTests.Services;

public class DeckServiceTests
{
    [Fact]
    public void Draw_WhenCards_ReturnsCard()
    {
        // Arrange
        var service = new DeckService();

        // Act
        var drawnCard = service.Draw();

        // Assert
        Assert.NotNull(drawnCard);
    }

    [Fact]
    public void Draw_WhenNoCards_ThrowsInvalidOperationExceptionWithMessageYouCannotDrawFromAnEmptyDeck()
    {
        // Arrange
        var service = new DeckService
        {
            Cards = []
        };

        // Act
        var action = () => service.Draw();

        // Assert
        InvalidOperationException exception = Assert.Throws<InvalidOperationException>(action);
        Assert.Equal("You cannot draw from an empty deck.", exception.Message);
    }
}
