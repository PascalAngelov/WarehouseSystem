using System;

namespace WarehouseSystem.IO
{
    public class ConsoleReader : IReader
    {
        public string CustomReadLine()
        {
            return Console.ReadLine();
        }
    }
}
