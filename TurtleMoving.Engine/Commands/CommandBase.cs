using System;
using TurtleMoving.Engine.Models;

namespace TurtleMoving.Engine.Commands
{
    internal abstract class CommandBase
    {
        public abstract string CommandString { get; }

        protected virtual bool CheckInitialization => true;

        public void Process(Turtle turtle, string commandParamsString)
        {
            ValidateCommandParams(commandParamsString);

            if(CheckInitialization && !turtle.IsInitialized)
            {
                return;
            }

            ExecuteProcessing(turtle, commandParamsString);
        }

        protected abstract void ExecuteProcessing(Turtle turtle, string commandParamsString);

        protected virtual void ValidateCommandParams(string commandParamsString)
        {
            if (!string.IsNullOrEmpty(commandParamsString))
            {
                throw new ArgumentException($"Found invalid parameters for the {CommandString} command");
            }
        }
    }
}
