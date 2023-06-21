using System;
using TurtleMoving.Engine.Models;

namespace TurtleMoving.Engine.Commands
{
    internal class PlaceCommand : CommandBase
    {
        public override string CommandString => CommandNames.Place;

        protected override bool CheckInitialization => false;

        protected override void ExecuteProcessing(Turtle turtle, string commandParamsString)
        {
            var commandParams = commandParamsString.Split(',');
            turtle.Initialize(
                int.Parse(commandParams[0]),
                int.Parse(commandParams[1]),
                (Facing)Enum.Parse(typeof(Facing), commandParams[2], true));
        }

        protected override void ValidateCommandParams(string commandParamsString)
        {
            var commandParams = commandParamsString.Split(',');

            if (commandParams.Length != 3)
            {
                throw new ArgumentException("Found invalid parameters for the PLACE command");
            }
        }
    }
}
