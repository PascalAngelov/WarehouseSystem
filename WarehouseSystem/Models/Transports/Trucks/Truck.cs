using System;
using System.Linq;
using System.Text.RegularExpressions;

using WarehouseSystem.Common.Constants;

namespace WarehouseSystem.Models.Transport.Trucks
{
    public class Truck : Transport, ITruck
    {
        private string truckRegistrationNumber;
        private string trailerRegistrationNumber;
        private string driverFirstName;
        private string driverLastName;
        private string driverPersonalIdentificationNumber;
        private string driverIdentityCard;

        public Truck(string truckRegistrationNumber, string trailerRegistrationNumber, string driverFirstName, string driverLastName, string driverPersonalIdentificationNumber, string DriverIdentityCard, string nameOfForwarder, string dateOfArrival, string dateOfShipment)
            : base(nameOfForwarder, dateOfArrival, dateOfShipment)
        {
            this.TruckRegistrationNumber = truckRegistrationNumber;
            this.TrailerRegistrationNumber = trailerRegistrationNumber;
            this.DriverFirstName = driverFirstName;
            this.DriverLastName = driverLastName;
            this.DriverPersonalIdentificationNumber = driverPersonalIdentificationNumber;
            this.DriverIdentityCard = DriverIdentityCard;
        }
        public string TruckRegistrationNumber
        {
            get
            {
                return this.truckRegistrationNumber;
            }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidTruckRegistrationNumber);
                }
                
                Regex.Replace(value, @"\s+", "");
                
                this.truckRegistrationNumber = value.ToUpper();
            }
        }

        public string TrailerRegistrationNumber
        {
            get
            {
                return this.trailerRegistrationNumber;
            }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidTrailerRegistrationNumber);
                }

                Regex.Replace(value, @"\s+", "");

                this.trailerRegistrationNumber = value.ToUpper();
            }
        }

        public string DriverFirstName
        {
            get
            {
                return this.driverFirstName;
            }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidFirstName);
                }

                this.driverFirstName = value;
            }
        }

        public string DriverLastName
        {
            get
            {
                return this.driverLastName;
            }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidLastName);
                }

                this.driverLastName = value;
            }
        }

        public string DriverPersonalIdentificationNumber
        {
            get
            {
                return this.driverPersonalIdentificationNumber;
            }
            set
            {
                if (String.IsNullOrWhiteSpace(value) || !value.All(c => char.IsDigit(c)))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPersonalIdentificationNumber);
                }

                this.driverPersonalIdentificationNumber = value;
            }
        }

        public string DriverIdentityCard
        {
            get
            {
                return this.driverIdentityCard;
            }
            set
            {
                if (String.IsNullOrWhiteSpace(value) || !value.All(c => char.IsDigit(c)))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidIdentityCard);
                }

                this.driverIdentityCard = value;
            }
        }
    }
}
