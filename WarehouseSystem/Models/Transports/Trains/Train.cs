using System;
using System.Collections.Generic;
using System.Linq;

using WarehouseSystem.Common.Constants;
using WarehouseSystem.Models.Transport.Trains.Wagons;

namespace WarehouseSystem.Models.Transport.Trains
{
    public class Train : Transport, ITrain
    {
        private ICollection<IWagon> wagons;
        public Train(string nameOfForwarder, string dateOfArrival, string dateOfShipment) 
            : base(nameOfForwarder, dateOfArrival, dateOfShipment) 
        {
            this.wagons = new List<IWagon>();
        }
        public IReadOnlyCollection<IWagon> Wagons => (IReadOnlyCollection<IWagon>) this.wagons;

        public void AddWagon(IWagon wagon)
        {
            this.wagons.Add(wagon);
        }

        public void RemoveWagon(string NumberOfWagon)
        {
            IWagon product = this.wagons.FirstOrDefault(p => p.NumberOfWagon == NumberOfWagon);

            if (product == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidWagonNumber);
            }

            this.wagons.Remove(product);
        }
    }
}
