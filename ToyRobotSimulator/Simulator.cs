using System;
using System.Text.RegularExpressions;

namespace ToyRobotSimulator
{
    public class Simulator
    {
        private static readonly Regex _placeCommand = new Regex(@"PLACE (\d+),(\d+),(\w+)");

        private readonly ToyRobot _toyRobot;

        public Simulator(ToyRobot toyRobot)
        {
            _toyRobot = toyRobot;
        }

        public void Execute(string command)
        {
            if (string.IsNullOrWhiteSpace(command))
                return;

            if (command == "MOVE") _toyRobot.Move();
            if (command == "LEFT") _toyRobot.Left();
            if (command == "RIGHT") _toyRobot.Right();
            if (command == "REPORT") Console.WriteLine(_toyRobot.Report());

            var match = _placeCommand.Match(command);
            if (match.Success)
            {
                var xIsValid = int.TryParse(match.Groups[1].Value, out var x);
                var yIsValid = int.TryParse(match.Groups[2].Value, out var y);
                var direction = match.Groups[3].Value;
                if (xIsValid && yIsValid)
                {
                    _toyRobot.Place(x, y, direction);
                }
            }
        }
    }
}