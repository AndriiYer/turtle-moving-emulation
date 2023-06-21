using System;
using TurtleMoving.Engine.Models;

namespace TurtleMoving.Engine.Commands
{
    internal class MoveCommand : CommandBase
    {
        public override string CommandString => CommandNames.Move;

        protected override void ExecuteProcessing(Turtle turtle, string commandParamsString)
        {
            switch(turtle.Facing)
            {
                case Facing.North:
                    turtle.PositionY++;
                    break;
                case Facing.East:
                    turtle.PositionX++;
                    break;
                case Facing.South:
                    turtle.PositionY--;
                    break;
                case Facing.West:
                    turtle.PositionX--;
                    break;
                default: throw new NotImplementedException($"The turtle has unknown Facing value: \"{turtle.Facing}\"");
            }
        }
    }
}
