using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarehouseSystem.Models.Products;
using WarehouseSystem.Common.Constants;

namespace WarehouseSystem.Models.Transport.Vessels
{
    
    public class Vessel : Transport, IVessel
    {
        private string name;
        private string voyage;
        public Vessel(string name, string voyage, string nameOfForwarder, string dateOfArrival, string dateOfShipment)
            : base(nameOfForwarder, dateOfArrival, dateOfShipment)
        {
            this.Name = name;
            this.Voyage = voyage;
        }
        public string Name {
            get
            {
                return this.name;
            }
            set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidNameVessel);
                }

                if (value.ToUpper().StartsWith("MV"))
                {
                    this.name = value.ToUpper();
                }

                this.name = $"MV {value.ToUpper()}";
            } 
        }
        public string Voyage 
        {
            get 
            {
                return this.voyage;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidVoyageVessel);
                }

                this.voyage = value;
            }
        }
    }
}
