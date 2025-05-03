using Xunit;
using PokerDotNet.Application.Services;
using PokerDotNet.Domain.Enums;
using Moq;
using PokerDotNet.Application.Interfaces;

namespace PokerDotNet.Application.UnitTests.Services;

public class GameServiceTests
{
    // [Theory]
    // [InlineData(Game.FiveCardDraw)]
    // public void ChooseGame_WhenFiveCardDraw_PlayersShouldBeOne(Game game)
    // {
    //     // Arrange
    //     var gameService = new GameService();

    //     // Act
    //     gameService.ChooseGame(game);

    //     // Assert
    //     Assert.Single(gameService.Players);

    // }

    // [Fact]
    // public void GetList_ReturnsListOfGameEnums()
    // {
    //     // Arrange
    //     var gameService = new GameService();

    //     // Act
    //     var gamesList = gameService.GetList();

    //     // Assert
    //     Assert.Equivalent(new []{ Game.FiveCardDraw, Game.TexasHoldem, Game.Omaha, Game.JokerPoker, Game.DeucesWild }, gamesList);
    // }

    [Theory]
    [InlineData(Game.FiveCardDraw)]
    [InlineData(Game.TexasHoldem)]
    [InlineData(Game.Omaha)]
    [InlineData(Game.JokerPoker)]
    [InlineData(Game.DeucesWild)]
    public void StartGame_WithAnyGame_ReturnsTrue(Game game)
    {
        // Arrange
        var deckService = new Mock<IDeckService>();
        var gameService = new GameService(deckService.Object);

        // Act
        var started = gameService.Start(game);

        // Assert
        Assert.True(started);
    }

    [Theory]
    [InlineData(Game.FiveCardDraw)]
    public void StartGame_WhenGameIsFiveCardDraw_PlayersShouldHaveCountOfOne(Game game)
    {
        // Arrange
        var deckService = new Mock<IDeckService>();
        var gameService = new GameService(deckService.Object);

        // Act
        gameService.Start(game);

            // Assert
            Assert.Single(gameService.Players);
    }

    [Theory]
    [InlineData(Game.FiveCardDraw)]
    public void StartGame_WhenGameIsFiveCardDraw_PlayersShouldHaveFiveUniqueCardsInHand(Game game)
    {
        // Arrange
        var deckService = new Mock<DeckService>();
        var gameService = new GameService(deckService.Object);

        // Act
        gameService.Start(game);

        // Assert
        Assert.Equal(5, gameService.Players.Single().Hand.Cards.Count);
        Assert.Distinct(gameService.Players.Single().Hand.Cards);
    }
}
