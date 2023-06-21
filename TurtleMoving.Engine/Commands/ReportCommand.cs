using System;
using TurtleMoving.Engine.Models;

namespace TurtleMoving.Engine.Commands
{
    internal class ReportCommand : CommandBase
    {
        public override string CommandString => CommandNames.Report;

        protected override void ExecuteProcessing(Turtle turtle, string commandParamsString)
        {
            Console.WriteLine();
            Console.WriteLine("--- Output ---");
            Console.WriteLine(turtle);
            Console.WriteLine();
            Console.WriteLine("--- Input ---");
        }
    }
}
