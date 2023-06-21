using System;
using TurtleMoving.Engine.Models;

namespace TurtleMoving.Engine.Commands
{
    internal class RightCommand : CommandBase
    {
        public override string CommandString => CommandNames.Right;

        protected override void ExecuteProcessing(Turtle turtle, string commandParamsString)
        {
            switch(turtle.Facing)
            {
                case Facing.North:
                case Facing.East:
                case Facing.South:
                    turtle.Facing++;
                    break;
                case Facing.West:
                    turtle.Facing = Facing.North;
                    break;
                default: throw new NotImplementedException($"The turtle has unknown Facing value: \"{turtle.Facing}\"");
            }
        }
    }
}
