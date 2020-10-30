using System.Collections.Generic;
using WarehouseSystem.Models.Terminals.Areas;
namespace WarehouseSystem.Models.Terminals
{
   public interface ITerminal
    {
        string TerminalName { get; }
        IReadOnlyCollection<IArea> Areas { get; }
        void AddArea(IArea area);
        void RemoveArea(string name);
    }
}
