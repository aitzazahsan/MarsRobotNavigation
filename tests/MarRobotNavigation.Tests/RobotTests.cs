using Xunit;
using MarRobotNavigation.Model;

public class RobotTests
{
    [Fact]
    public void Robot_Initialization_ShouldSetPropertiesCorrectly()
    {
        // Arrange
        int x = 1;
        int y = 1;
        Direction orientation = Direction.N;

        // Act
        Robot robot = new Robot(x, y, orientation);

        // Assert
        Assert.Equal(x, robot.X);
        Assert.Equal(y, robot.Y);
        Assert.Equal(orientation, robot.Orientation);
    }

    [Fact]
    public void Robot_Move_OffGrid_ShouldMarkRobotAsLost()
    {
        // Arrange
        var grid = new Grid(5, 5);
        var robot = new Robot(5, 5, Direction.N);

        // Act
        robot.Move(grid);

        // Assert
        Assert.True(robot.IsLost);
    }

    [Fact]
    public void Robot_TurnLeft_ShouldChangeOrientationCorrectly()
    {
        // Arrange
        var robot = new Robot(0, 0, Direction.N);

        // Act
        robot.TurnLeft();

        // Assert
        Assert.Equal(Direction.W, robot.Orientation);
    }

    [Fact]
    public void Robot_TurnRight_ShouldChangeOrientationCorrectly()
    {
        // Arrange
        var robot = new Robot(0, 0, Direction.N);

        // Act
        robot.TurnRight();

        // Assert
        Assert.Equal(Direction.E, robot.Orientation);
    }

    [Fact]
    public void Robot_Move_ShouldUpdatePositionCorrectly_WhenNotLost()
    {
        // Arrange
        var grid = new Grid(5, 5);
        var robot = new Robot(1, 1, Direction.E);

        // Act
        robot.Move(grid);

        // Assert
        Assert.Equal(2, robot.X);
        Assert.Equal(1, robot.Y);
        Assert.False(robot.IsLost);
    }

    [Fact]
    public void Robot_Move_ShouldIgnoreMove_WhenRobotIsLost()
    {
        // Arrange
        var grid = new Grid(5, 5);
        var robot = new Robot(5, 5, Direction.N);
        robot.Move(grid); // This will mark the robot as lost

        // Act
        robot.Move(grid); // Further moves should be ignored

        // Assert
        Assert.Equal(5, robot.X);
        Assert.Equal(5, robot.Y);
        Assert.True(robot.IsLost);
    }
}