using Xunit;
using MarRobotNavigation.Model;
using MarRobotNavigation.Services;

public class InputParsingTests
{
    [Fact]
    public void InputParsingService_ParseInputs_ShouldParseCorrectly()
    {
        // Arrange
        var service = new InputParsingService();
        string[] inputs = new[]
        {
        "5 3",
        "1 1 E",
        "RFRFRFRF",
        "3 2 N",
        "FRRFLLFFRRFLL"
    };

        // Act
        service.ParseInputs(inputs, out var grid, out var robots, out var commandStrings);

        // Assert
        Assert.Equal(5, grid.MaxX);
        Assert.Equal(3, grid.MaxY);
        Assert.Equal(2, robots.Count);
        Assert.Equal(2, commandStrings.Count);
        Assert.Equal(robots[0].X, 1);
        Assert.Equal(robots[0].Y, 1);
        Assert.Equal(robots[0].Orientation, Direction.E);
        Assert.Equal("RFRFRFRF", commandStrings[0]);
    }
}