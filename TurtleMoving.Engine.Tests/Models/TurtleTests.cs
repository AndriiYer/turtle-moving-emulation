using FluentAssertions;
using TurtleMoving.Engine.Commands;
using TurtleMoving.Engine.Models;
using Xunit;

namespace TurtleMoving.Engine.Tests
{
    public class TurtleTests : TestsBase
    {
        [Fact]
        public void Having_Turtle_When_SettingTooBigPositionX_Then_TurtleHasCorrectPositionX()
        {
            //Arrange
            var commandString = $"{CommandNames.Place} 5,4,{Facing.West}";
            var processor = GetProcessor();

            //Act
            processor.ProcessCommand(commandString);

            //Assert
            processor.Turtle.PositionX.Should().Be(Table.Instance.DimensionX - 1);
        }

        [Fact]
        public void Having_Turtle_When_SettingTooSmallPositionX_Then_TurtleHasCorrectPositionX()
        {
            //Arrange
            var commandString = $"{CommandNames.Place} -1,4,{Facing.West}";
            var processor = GetProcessor();

            //Act
            processor.ProcessCommand(commandString);

            //Assert
            processor.Turtle.PositionX.Should().Be(0);
        }

        [Fact]
        public void Having_Turtle_When_SettingTooBigPositionY_Then_TurtleHasCorrectPositionY()
        {
            //Arrange
            var commandString = $"{CommandNames.Place} 4,5,{Facing.West}";
            var processor = GetProcessor();

            //Act
            processor.ProcessCommand(commandString);

            //Assert
            processor.Turtle.PositionY.Should().Be(Table.Instance.DimensionX - 1);
        }

        [Fact]
        public void Having_Turtle_When_SettingTooSmallPositionY_Then_TurtleHasCorrectPositioY()
        {
            //Arrange
            var commandString = $"{CommandNames.Place} 0,-1,{Facing.West}";
            var processor = GetProcessor();

            //Act
            processor.ProcessCommand(commandString);

            //Assert
            processor.Turtle.PositionY.Should().Be(0);
        }
    }
}
