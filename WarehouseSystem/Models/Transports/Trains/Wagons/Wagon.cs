using System;
using System.Linq;

using WarehouseSystem.Common.Constants;

namespace WarehouseSystem.Models.Transport.Trains.Wagons
{
    public class Wagon : Train, IWagon
    {
        private string numberOfWagon;
        public Wagon(string numberOfWagon, string nameOfForwarder, string dateOfArrival, string dateOfShipment)
            : base(nameOfForwarder, dateOfArrival, dateOfShipment)
        {
            this.NumberOfWagon = numberOfWagon; 
        }
        public string NumberOfWagon
        {
            get
            {
                return this.numberOfWagon;
            }
            set
            {
                if (String.IsNullOrWhiteSpace(value) || !value.All(w => char.IsDigit(w)))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidWagonNumber);
                }

                this.numberOfWagon = value;
            }
        }
    }
}
