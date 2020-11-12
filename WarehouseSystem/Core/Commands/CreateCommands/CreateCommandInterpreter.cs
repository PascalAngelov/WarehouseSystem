using System;

using WarehouseSystem.IO;
using WarehouseSystem.Common.Enums;
using WarehouseSystem.Common.Constants;
using WarehouseSystem.Core.Commands.CreateCommands.CreateTransportCommands;
using WarehouseSystem.Core.Commands.CreateCommands.CreateProductCommands;
using WarehouseSystem.Core.Commands.CreateCommands.CreateTerminalCommands;

namespace WarehouseSystem.Core
{
    public class CreateCommandInterpreter : ICommandInterpreter
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly CreateTransportCommandInterpreter createTransportCommandInterpreter;
        private readonly CreateProductCommandInterpreter createProductCommandInterpreter;
        private readonly CreateTerminalCommandInterpreter createTerminalCommandInterpreter;
        public CreateCommandInterpreter(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
            this.createTransportCommandInterpreter = new CreateTransportCommandInterpreter(this.reader, this.writer);
            this.createProductCommandInterpreter = new CreateProductCommandInterpreter(this.reader, this.writer);
            this.createTerminalCommandInterpreter = new CreateTerminalCommandInterpreter(this.reader, this.writer);
        }
        public void ExecuteCommand()
        {
            string msg = null;
            
            while (msg != FunctionalityMessages.BackMessage)
            {
                this.writer.CustomWriteLine(FunctionalityMessages.ChooseMessage);
                this.writer.CustomWriteLine(FunctionalityMessages.CreateTransportMessage);
                this.writer.CustomWriteLine(FunctionalityMessages.CreateProductMessage);
                this.writer.CustomWriteLine(FunctionalityMessages.CreateTerminalMessage);
                this.writer.CustomWriteLine(FunctionalityMessages.BackMessage);
                

                string command = this.reader.CustomReadLine();
                try
                {
                    if (!Enum.TryParse(command, out CreateCommandType commandType))
                    {
                        throw new InvalidOperationException(ExceptionMessages.InvalidCommand);
                    }

                    switch (commandType)
                    {
                        case CreateCommandType.Transport:
                            this.createTransportCommandInterpreter.ExecuteCommand();
                            break;
                        case CreateCommandType.Product:
                            this.createProductCommandInterpreter.ExecuteCommand();
                            break;
                        case CreateCommandType.Terminal:
                            this.createTerminalCommandInterpreter.ExecuteCommand();
                            break;
                        case CreateCommandType.Back:
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
                
                if (msg != FunctionalityMessages.BackMessage && msg != null)
                {
                    this.writer.CustomWriteLine(msg);
                }
            }
        }
    }
}
