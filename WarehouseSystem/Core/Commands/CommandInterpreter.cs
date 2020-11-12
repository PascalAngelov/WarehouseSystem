using System;

using WarehouseSystem.IO;
using WarehouseSystem.Common.Constants;
using WarehouseSystem.Common.Enums;

namespace WarehouseSystem.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly CreateCommandInterpreter createCommandInterpreter;

        public CommandInterpreter(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
            this.createCommandInterpreter = new CreateCommandInterpreter(this.reader, this.writer);
        }

        public void ExecuteCommand()
        {
            string msg = null;
            while (msg != FunctionalityMessages.ExitMessage)
            {
                this.writer.CustomWriteLine(FunctionalityMessages.ChooseMessage);
                this.writer.CustomWriteLine(FunctionalityMessages.CreateMessage);
                this.writer.CustomWriteLine(FunctionalityMessages.UpdateMessage);
                this.writer.CustomWriteLine(FunctionalityMessages.StatisticsMessage);
                this.writer.CustomWriteLine(FunctionalityMessages.ExitMessage);

                string command = this.reader.CustomReadLine();

                try
                {
                    if (!Enum.TryParse(command, out CommandType commandType))
                    {
                        throw new InvalidOperationException(ExceptionMessages.InvalidCommand);
                    }

                    switch (commandType)
                    {
                        case CommandType.Create:
                            this.createCommandInterpreter.ExecuteCommand();
                            break;
                        case CommandType.Update:
                            break;
                        case CommandType.Statistics:
                            break;
                        case CommandType.Exit:
                            msg = FunctionalityMessages.ExitMessage;
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
                
            }
        }
    }
}
