using FluentAssertions;
using TurtleMoving.Engine.Commands;
using Xunit;

namespace TurtleMoving.Engine.Tests
{
    public class PlaceCommandTests : TestsBase
    {
        [Fact]
        public void Having_Turtle_When_ProcessingPlaceCommandTestsCommand_Then_TurtleGotInitialized()
        {
            //Arrange
            var processor = GetProcessor();
            var commandString = $"{CommandNames.Place} 0,0,{Facing.North}";

            //Act
            processor.ProcessCommand(commandString);

            //Assert
            processor.Turtle.IsInitialized.Should().Be(true);
        }
    }
}
