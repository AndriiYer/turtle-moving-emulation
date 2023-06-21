using System;
using TurtleMoving.Engine.Models;

namespace TurtleMoving.Engine.Commands
{
    internal class LeftCommand : CommandBase
    {
        public override string CommandString => CommandNames.Left;

        protected override void ExecuteProcessing(Turtle turtle, string commandParamsString)
        {
            switch(turtle.Facing)
            {
                case Facing.North:
                    turtle.Facing = Facing.West;
                    break;
                case Facing.East:
                case Facing.South:
                case Facing.West:
                    turtle.Facing--;
                    break;
                default: throw new NotImplementedException($"The turtle has unknown Facing value: \"{turtle.Facing}\"");
            }
        }
    }
}
