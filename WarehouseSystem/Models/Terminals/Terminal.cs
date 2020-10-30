using System;
using System.Collections.Generic;
using System.Linq;

using WarehouseSystem.Common.Constants;
using WarehouseSystem.Models.Terminals.Areas;

namespace WarehouseSystem.Models.Terminals
{
    public class Terminal : ITerminal
    {
        private string terminalName;
        private ICollection<IArea> areas;
        public Terminal(string terminalName)
        {
            this.TerminalName = terminalName;
            this.areas = new List<IArea>();
        }
        public string TerminalName 
        {
            get
            {
                return this.terminalName;
            }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidTerminalName);
                }
                this.terminalName = value;
            }
        }

        public IReadOnlyCollection<IArea> Areas => (IReadOnlyCollection<IArea>)this.areas;

        public void AddArea(IArea area)
        {
            this.areas.Add(area);
        }

        public void RemoveArea(string name)
        {
            IArea area = this.areas.FirstOrDefault(a => a.Name == name);
            
            if (area == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidName);
            }

            this.areas.Remove(area);
        }
    }
}
