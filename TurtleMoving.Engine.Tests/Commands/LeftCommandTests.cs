using FluentAssertions;
using TurtleMoving.Engine.Commands;
using Xunit;

namespace TurtleMoving.Engine.Tests
{
    public class LeftCommandTests : TestsBase
    {
        [Theory]
        [InlineData(Facing.North, Facing.West)]
        [InlineData(Facing.West, Facing.South)]
        [InlineData(Facing.South, Facing.East)]
        [InlineData(Facing.East, Facing.North)]
        public void Having_TurtleFacingNorth_When_ProcessingLeftCommand_Then_TurtleTurnsLeft(Facing initialFacing, Facing expectedFacing)
        {
            //Arrange
            var processor = GetProcessor();
            var commandString = $"{CommandNames.Place} 0,0,{initialFacing}";
            processor.ProcessCommand(commandString);

            //Act
            processor.ProcessCommand(CommandNames.Left);

            //Assert
            processor.Turtle.Facing.Should().Be(expectedFacing);
        }

        [Theory]
        [InlineData(Facing.North)]
        [InlineData(Facing.West)]
        [InlineData(Facing.South)]
        [InlineData(Facing.East)]
        public void Having_TurtleFacingNorth_When_ProcessingLeftCommandWithoutPlaceCommand_Then_DoNothing(Facing facing)
        {
            //Arrange
            var processor = GetProcessor();

            //Act
            processor.ProcessCommand(CommandNames.Left);

            //Assert
            processor.Turtle.Facing.Should().Be(Facing.North);
        }
    }
}
