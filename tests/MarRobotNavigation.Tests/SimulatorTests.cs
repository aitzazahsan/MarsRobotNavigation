using Xunit;
using MarRobotNavigation.Model;
using MarRobotNavigation.Services;
using MarRobotNavigation.Commands;
using MarRobotNavigation;

public class SimulatorTests
{
    [Fact]
    public void MarsRoverSimulator_ShouldProcessCommandsCorrectly()
    {
        // Arrange
        var grid = new Grid(5, 5);
        var robot = new Robot(1, 1, Direction.E);
        var factory = new CommandFactory();
        factory.RegisterCommands();
        var simulator = new MarsRoverSimulator(robot, grid, factory);
        string commandString = "RFRFRFRF";

        // Act
        simulator.Run(commandString);

        // Assert
        Assert.Equal(1, robot.X);
        Assert.Equal(1, robot.Y);
        Assert.Equal(Direction.E, robot.Orientation);
        Assert.False(robot.IsLost);
    }
}