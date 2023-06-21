using FluentAssertions;
using TurtleMoving.Engine.Commands;
using Xunit;

namespace TurtleMoving.Engine.Tests.Commands
{
    public class RightCommandTests : TestsBase
    {
        [Theory]
        [InlineData(Facing.North, Facing.East)]
        [InlineData(Facing.East, Facing.South)]
        [InlineData(Facing.South, Facing.West)]
        [InlineData(Facing.West, Facing.North)]
        public void Having_TurtleFacingNorth_When_ProcessingRightCommand_Then_TurtleTurnsRight(Facing initialFacing, Facing expectedFacing)
        {
            //Arrange
            var processor = GetProcessor();
            var commandString = $"{CommandNames.Place} 0,0,{initialFacing}";
            processor.ProcessCommand(commandString);

            //Act
            processor.ProcessCommand(CommandNames.Right);

            //Assert
            processor.Turtle.Facing.Should().Be(expectedFacing);
        }

        [Theory]
        [InlineData(Facing.North)]
        [InlineData(Facing.West)]
        [InlineData(Facing.South)]
        [InlineData(Facing.East)]
        public void Having_TurtleFacingNorth_When_ProcessingRightCommandWithoutPlaceCommand_Then_DoNothing(Facing facing)
        {
            //Arrange
            var processor = GetProcessor();

            //Act
            processor.ProcessCommand(CommandNames.Right);

            //Assert
            processor.Turtle.Facing.Should().Be(Facing.North);
        }
    }
}
