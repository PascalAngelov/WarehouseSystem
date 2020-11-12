using System;
using WarehouseSystem.IO;
using WarehouseSystem.Common.Constants;
using WarehouseSystem.Common.Enums;


namespace WarehouseSystem.Core.Commands.CreateCommands.CreateTerminalCommands
{
    public class CreateTerminalCommandInterpreter : ICommandInterpreter
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        public CreateTerminalCommandInterpreter(IReader reader, IWriter writer)
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
                this.writer.CustomWriteLine(FunctionalityMessages.CreateTerminalMessage);
                this.writer.CustomWriteLine(FunctionalityMessages.CreateAreaMessage);
                this.writer.CustomWriteLine(FunctionalityMessages.CreateStackMessage);
                this.writer.CustomWriteLine(FunctionalityMessages.BackMessage);


                string command = this.reader.CustomReadLine();

                try
                {
                    if (!Enum.TryParse(command, out CreateTerminalCommandType commandType))
                    {
                        throw new InvalidOperationException(ExceptionMessages.InvalidCommand);
                    }

                    switch (commandType)
                    {
                        case CreateTerminalCommandType.Terminal:
                            msg = "Evala brat!!!";
                            break;
                        case CreateTerminalCommandType.Area:
                            msg = "Evala brat!!!";
                            break;
                        case CreateTerminalCommandType.Stack:
                            msg = "Evala brat!!!";
                            break;
                        case CreateTerminalCommandType.Back:
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
