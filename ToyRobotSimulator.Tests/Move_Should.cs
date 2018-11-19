using FluentAssertions;
using Xunit;

namespace ToyRobotSimulator.Tests
{
    public class Move_Should
    {
        [Fact]
        public void Move_North_when_facing_North()
        {
            var toyRobot = new ToyRobot();
            toyRobot.Place(2, 2, Direction.North);

            toyRobot.Move();

            toyRobot.X.Should().Be(2);
            toyRobot.Y.Should().Be(3);
        }

        [Fact]
        public void Move_East_when_facing_East()
        {
            var toyRobot = new ToyRobot();
            toyRobot.Place(2, 2, Direction.East);

            toyRobot.Move();

            toyRobot.X.Should().Be(3);
            toyRobot.Y.Should().Be(2);
        }

        [Fact]
        public void Move_South_when_facing_South()
        {
            var toyRobot = new ToyRobot();
            toyRobot.Place(2, 2, Direction.South);

            toyRobot.Move();

            toyRobot.X.Should().Be(2);
            toyRobot.Y.Should().Be(1);
        }

        [Fact]
        public void Move_West_when_facing_West()
        {
            var toyRobot = new ToyRobot();
            toyRobot.Place(2, 2, Direction.West);

            toyRobot.Move();

            toyRobot.X.Should().Be(1);
            toyRobot.Y.Should().Be(2);
        }

        [Theory]
        [InlineData(4, 4, Direction.North)]
        [InlineData(4, 4, Direction.East)]
        [InlineData(0, 0, Direction.South)]
        [InlineData(0, 0, Direction.West)]
        public void Not_cause_the_robot_to_fall_outside_the_table(int x, int y, string direction)
        {
            var toyRobot = new ToyRobot();
            toyRobot.Place(x, y, direction);

            toyRobot.Move();

            toyRobot.X.Should().Be(x);
            toyRobot.Y.Should().Be(y);
        }
    }
}