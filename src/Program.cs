using MarRobotNavigation.Commands;
using MarRobotNavigation.Model;
using MarRobotNavigation.Services;
using System;
using System.IO;
using System.Collections.Generic;
using System.Reflection;

namespace MarRobotNavigation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var inputFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Input.txt");

                // Initialize services and entities
                var parsingService = new InputParsingService();
                parsingService.ParseInputs(File.ReadAllLines(inputFilePath), out var grid, out var robots, out var commandStrings);
                var factory = new CommandFactory();
                factory.RegisterCommands();

                // Process each robot with its respective commands
                foreach (var (robot, command) in robots.Zip(commandStrings, Tuple.Create))
                {
                    var simulator = new MarsRoverSimulator(robot, grid, factory);
                    simulator.Run(command);
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"Input file not found: {ex.Message}");
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Format error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
            }
        }

    }
}