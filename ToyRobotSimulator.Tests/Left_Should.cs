using FluentAssertions;
using Xunit;

namespace ToyRobotSimulator.Tests
{
    public class Left_Should
    {
        [Theory]
        [InlineData(Direction.North, Direction.West)]
        [InlineData(Direction.East, Direction.North)]
        [InlineData(Direction.South, Direction.East)]
        [InlineData(Direction.West, Direction.South)]
        public void Rotate_robot_left_90_degrees(string before, string after)
        {
            var toyRobot = new ToyRobot();
            toyRobot.Place(1, 1, before);

            toyRobot.Left();

            toyRobot.Facing.Should().Be(after);
        }
    }
}