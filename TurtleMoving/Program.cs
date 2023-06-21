using System;
using System.Configuration;
using System.IO;
using TurtleMoving.Engine;

namespace TurtleMoving
{
    class Program
    {
        static void Main(string[] args)
        {
            var appSettings = ConfigurationManager.AppSettings;
            var dimensionX = int.Parse(appSettings["DimensionX"]);
            var dimensionY = int.Parse(appSettings["DimensionY"]);

            var turtleMovingProcessor = new TurtleMovingProcessor(dimensionX, dimensionY);

            Console.WriteLine("Welcome to the Turtle moving!");
            Console.WriteLine("To proceed with a command file please enter the file name, otherwise please press Enter...");
            var fileName = Console.ReadLine();
            
            if (File.Exists(fileName))
            {
                Console.WriteLine("Proceeding with the command file.");
                Console.WriteLine();
                Console.WriteLine("--- Input ---");

                ProcessCommandFile(turtleMovingProcessor, fileName);

                Console.WriteLine("Done.");
                Console.WriteLine("Please press Enter for exit...");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Proceeding with commands from the console.");
                Console.WriteLine("For exit, please enter the empty string.");
                Console.WriteLine();
                Console.WriteLine("--- Input ---");
                ProcessConsole(turtleMovingProcessor);
            }
         }

        private static void ProcessConsole(TurtleMovingProcessor turtleMovingProcessor)
        {
            string commandString;
            do
            {
                commandString = Console.ReadLine();
                try
                {
                    turtleMovingProcessor.ProcessCommand(commandString);
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            while (!string.IsNullOrWhiteSpace(commandString));
        }

        private static void ProcessCommandFile(TurtleMovingProcessor turtleMovingProcessor, string fileName)
        {
            using (var streamReader = new StreamReader(fileName))
            {
                string commandString;
                while ((commandString = streamReader.ReadLine()) != null)
                {
                    Console.WriteLine(commandString);
                    try
                    {
                        turtleMovingProcessor.ProcessCommand(commandString);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }
    }
} 
