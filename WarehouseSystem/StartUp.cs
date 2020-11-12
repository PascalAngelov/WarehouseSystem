using System;
using WarehouseSystem.IO;
using WarehouseSystem.Core;

namespace WarehouseSystem
{
    class StartUp
    {
        static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();
            ICommandInterpreter commandInterpreter = new CommandInterpreter(reader, writer);
 

            IEngine engine = new Engine(writer, commandInterpreter);
            engine.Run();
        }
    }
}
