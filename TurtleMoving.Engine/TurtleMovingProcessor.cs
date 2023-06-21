using System;
using TurtleMoving.Engine.Commands;
using TurtleMoving.Engine.Models;

namespace TurtleMoving.Engine
{
    public class TurtleMovingProcessor
    {
        internal Turtle Turtle { get; } = new Turtle();

        public TurtleMovingProcessor(int dimensionX, int dimensionY)
        {
            Table.Instantiate(dimensionX, dimensionY);
        }

        public void ProcessCommand(string commandString)
        {
            if(string.IsNullOrWhiteSpace(commandString))
            {
                return;
            }

            var commandParts = commandString.ToUpper().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var commandName = commandParts[0];
            string commandParams = null;
            if(commandParts.Length == 2)
            {
                commandParams = commandParts[1];
            }

            var command = CommandFactory.Instance.ParseCommandString(commandName);

            command.Process(Turtle, commandParams);
        }
    }
}
