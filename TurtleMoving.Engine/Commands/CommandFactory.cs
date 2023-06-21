using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace TurtleMoving.Engine.Commands
{
    internal class CommandFactory
    {
        private static readonly CommandFactory instance = new CommandFactory();

        private readonly Dictionary<string, CommandBase> Commands;

        public static CommandFactory Instance { get => instance; }

        public CommandFactory()
        {
            Commands = new Dictionary<string, CommandBase>();
            foreach (var type in
                Assembly.GetAssembly(typeof(CommandBase)).GetTypes()
                .Where(myType => myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(typeof(CommandBase))))
            {
                var command = (CommandBase)Activator.CreateInstance(type);
                Commands.Add(command.CommandString, command);
            }
        }

        public CommandBase ParseCommandString(string commandName) =>
            Commands.ContainsKey(commandName)
                ? Commands[commandName]
                : throw new InvalidOperationException($"Wrong command name: \"{commandName}\"");
    }
}
