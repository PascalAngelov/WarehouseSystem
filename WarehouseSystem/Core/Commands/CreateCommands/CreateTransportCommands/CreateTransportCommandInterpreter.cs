using System;
using WarehouseSystem.Common.Constants;
using WarehouseSystem.Common.Enums;
using WarehouseSystem.IO;

namespace WarehouseSystem.Core.Commands.CreateCommands.CreateTransportCommands
{
    public class CreateTransportCommandInterpreter : ICommandInterpreter
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        public CreateTransportCommandInterpreter(IReader reader, IWriter writer)
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
                this.writer.CustomWriteLine(FunctionalityMessages.CreateVesselMessage);
                this.writer.CustomWriteLine(FunctionalityMessages.CreateTruckMessage);
                this.writer.CustomWriteLine(FunctionalityMessages.CreateTrainMessage);
                this.writer.CustomWriteLine(FunctionalityMessages.BackMessage);


                string command = this.reader.CustomReadLine();

                try
                {
                    if (!Enum.TryParse(command, out CreateTransportCommandType commandType))
                    {
                        throw new InvalidOperationException(ExceptionMessages.InvalidCommand);
                    }

                    switch (commandType)
                    {
                        case CreateTransportCommandType.Vessel:
                            msg = "Evala brat!!!";
                            break;
                        case CreateTransportCommandType.Truck:
                            msg = "Evala brat!!!";
                            break;
                        case CreateTransportCommandType.Train:
                            msg = "Evala brat!!!";
                            break;
                        case CreateTransportCommandType.Back:
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
