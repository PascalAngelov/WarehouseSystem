using System.Collections.Generic;
using WarehouseSystem.Models.Transport.Trains.Wagons;

namespace WarehouseSystem.Models.Transport.Trains
{
   public interface ITrain : ITransport
    {
        IReadOnlyCollection<IWagon> Wagons { get; }
        void AddWagon(IWagon wagon);
        void RemoveWagon(string NumberOfWagon);
    }
}
