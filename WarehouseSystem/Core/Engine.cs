using System;
using WarehouseSystem.Common.Constants;
using WarehouseSystem.IO;

namespace WarehouseSystem.Core
{
    public class Engine : IEngine
    {
        private readonly ICommandInterpreter commandInterpreter;
        private readonly IWriter writer;
        public Engine(IWriter writer, ICommandInterpreter commandInterpreter)
        {
            this.writer = writer;
            this.commandInterpreter = commandInterpreter;
        }
        public void Run()
        {
            this.writer.CustomWriteLine(FunctionalityMessages.WelcomeMessage);

            this.commandInterpreter.ExecuteCommand();
        }
    }
}
