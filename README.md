# Martian Robots Project

This project simulates the movement of robots on a grid representing the surface of Mars. The robots receive commands from Earth and navigate while avoiding falling off the edge of the grid.

## Setup

### Prerequisites

- [Download .NET 7 SDK](https://dotnet.microsoft.com/download/dotnet/7.0) and ensure it's installed on your system.

### Clone the Repository

```bash
git clone https://github.com/aitzazahsan/MarsRobotNavigation.git
cd MarRobotNavigation
```

### Build the Project
```bash
dotnet build
```
### Running the Application
## Input File
- Prepare an input file named Input.txt with the format specified in the problem statement.
- Place it in the directory where the executable is located.
- There is already a file included which is set to copy to output

## Execute
```bash
cd src
dotnet run
```
### Testing
To run the tests, navigate to the test project directory and execute:
```bash
cd tests
dotnet test MarRobotNavigation.Tests
```
### Code Structure
- Entities:
	- Robot, Grid, Position: Define the core behavior and state of the robots and the grid.
- Services
	- InputParsingService: Handles input parsing logic.
- Commands 
    - Encapsulate robot commands using the command pattern for extensibility.
- Simulation 
	- MarsRoverSimulator: Manages the execution of robot instructions.

### Approach
The project utilizes the command pattern to encapsulate robot commands, enabling easy extension with new commands. A CommandFactory is used to register and retrieve commands dynamically, which facilitates future expansions for additional command types.

### Possible Future Improvements
- **Expand Command Set** : Facilitate the addition of new commands with minimal refactoring.
- **Improve Error Handling** : Enhance input validation and provide detailed feedback for user errors.
- **Concurrent Execution** : Allow multiple robots to execute commands concurrently for more realistic simulations.
- **Graphical Interface** : Provide a visualization of the grid and robot movements for better user interaction and debugging.