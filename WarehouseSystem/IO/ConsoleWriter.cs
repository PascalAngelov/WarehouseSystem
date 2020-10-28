using System;

namespace WarehouseSystem.IO
{
    public class ConsoleWriter : IWriter
    {
        public void CustomWrite(string text)
        {
            Console.WriteLine(text);
        }

        public void CustomWriteLine(string text)
        {
            Console.Write(text);
        }
    }
}
