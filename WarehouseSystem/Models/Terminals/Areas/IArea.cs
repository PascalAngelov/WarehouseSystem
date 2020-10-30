using System.Collections.Generic;
using WarehouseSystem.Models.Terminals.Areas.Stacks;

namespace WarehouseSystem.Models.Terminals.Areas
{
   public interface IArea
    {
        string AreaName { get; }
        IReadOnlyCollection<IStack> Stacks { get; }
        void AddStack(IStack stack);
        void RemoveStack(string name);
    }
}
