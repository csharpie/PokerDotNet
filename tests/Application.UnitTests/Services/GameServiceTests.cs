using Xunit;
using PokerDotNet.Application.Services;
using PokerDotNet.Domain.Enums;

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

    [Fact]
    public void GetList_ReturnsListOfGameEnums()
    {
        // Arrange
        var gameService = new GameService();

        // Act
        var gamesList = gameService.GetList();

        // Assert
        Assert.Equivalent(new []{ Game.FiveCardDraw, Game.TexasHoldem, Game.Omaha, Game.JokerPoker, Game.DeucesWild }, gamesList);
    }
}
