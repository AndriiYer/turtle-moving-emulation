using FluentAssertions;
using TurtleMoving.Engine.Commands;
using Xunit;

namespace TurtleMoving.Engine.Tests
{
    public class MoveCommandTests : TestsBase
    {
        [Theory]
        [InlineData(Facing.North, 2, 3)]
        [InlineData(Facing.West, 1, 2)]
        [InlineData(Facing.South, 2, 1)]
        [InlineData(Facing.East, 3, 2)]
        public void Having_TurtleFacingNorth_When_ProcessingMoveCommand_Then_TurtleTurnsLeft(Facing initialFacing, int expectedPositionX, int expectedPositionY)
        {
            //Arrange
            var processor = GetProcessor();
            var commandString = $"{CommandNames.Place} 2,2,{initialFacing}";
            processor.ProcessCommand(commandString);

            //Act
            processor.ProcessCommand(CommandNames.Move);

            //Assert
            processor.Turtle.PositionX.Should().Be(expectedPositionX);
            processor.Turtle.PositionY.Should().Be(expectedPositionY);
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
            processor.Turtle.PositionX = 2;
            processor.Turtle.PositionY = 2;

            //Act
            processor.ProcessCommand(CommandNames.Move);

            //Assert
            processor.Turtle.PositionX.Should().Be(2);
            processor.Turtle.PositionY.Should().Be(2);
        }
    }
}
