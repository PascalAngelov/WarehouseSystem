using System;
using WarehouseSystem.Common.Constants;
using WarehouseSystem.Common.Enums;
using WarehouseSystem.IO;

namespace WarehouseSystem.Core.Commands.CreateCommands.CreateProductCommands
{
    public class CreateProductCommandInterpreter : ICommandInterpreter
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        public CreateProductCommandInterpreter(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
        }
        public void ExecuteCommand()
        {
            string msg = null;

            while (msg != FunctionalityMessages.BackMessage)
            {
                this.writer.CustomWriteLine(FunctionalityMessages.ChooseMessage);
                this.writer.CustomWriteLine(FunctionalityMessages.CreatePipeMessage);
                this.writer.CustomWriteLine(FunctionalityMessages.BackMessage);


                string command = this.reader.CustomReadLine();

                try
                {
                    if (!Enum.TryParse(command, out CreateProductCommandType commandType))
                    {
                        throw new InvalidOperationException(ExceptionMessages.InvalidCommand);
                    }

                    switch (commandType)
                    {
                        case CreateProductCommandType.Pipe:
                            msg = "Evala brat!!!";
                            break;
                        case CreateProductCommandType.Back:
                            msg = FunctionalityMessages.BackMessage;
                            break;
                    }
                }
                catch (ArgumentException e)
                {
                    msg = e.Message;
                }
                catch (InvalidOperationException e)
                {
                    msg = e.Message;
                }


                if (msg != FunctionalityMessages.BackMessage)
                {
                    this.writer.CustomWriteLine(msg);
                }
            }
        }
    }
}
