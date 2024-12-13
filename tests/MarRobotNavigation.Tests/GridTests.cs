using Xunit;
using MarRobotNavigation.Model;

public class GridTests
{
    [Fact]
    public void Grid_IsOffGrid_ShouldReturnTrue_WhenPositionIsOutOfBounds()
    {
        // Arrange
        var grid = new Grid(5, 5);

        // Act
        var result = grid.IsOffGrid(6, 5);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void Grid_CheckScent_ShouldReturnTrue_WhenScentIsMarked()
    {
        // Arrange
        var grid = new Grid(5, 5);
        var position = new Position(3, 3);
        grid.MarkScent(position);

        // Act
        var result = grid.CheckScent(position);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void Grid_CheckScent_ShouldReturnFalse_WhenScentIsNotMarked()
    {
        // Arrange
        var grid = new Grid(5, 5);
        var position = new Position(3, 3);

        // Act
        var result = grid.CheckScent(position);

        // Assert
        Assert.False(result);
    }
}