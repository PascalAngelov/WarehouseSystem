using System;
using System.Collections.Generic;
using System.Linq;

using WarehouseSystem.Common.Constants;
using WarehouseSystem.Models.Terminals.Areas.Stacks;

namespace WarehouseSystem.Models.Terminals.Areas
{
    public class Area : IArea
    {
        private string areaName;
        private ICollection<IStack> stacks;
        public Area(string areaName)
        {
            this.AreaName = areaName;
            this.stacks = new List<IStack>();
        }
        public IReadOnlyCollection<IStack> Stacks => (IReadOnlyCollection<IStack>)this.stacks;

        public string AreaName
        {
            get
            {
                return this.areaName;
            }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidName);
                }

                this.areaName = value;
            }
        }

        public void AddStack(IStack stack)
        {
            this.stacks.Add(stack);
        }

        public void RemoveStack(string name)
        {
            IStack stack = this.stacks.FirstOrDefault(s => s.Name == name);

            if (stack == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidName);
            }

            this.stacks.Remove(stack);
        }
    }
}
