using System;
using System.Collections.Generic;
using System.Text;

using WarehouseSystem.Common.Constants;

namespace WarehouseSystem.Models.Products
{
    public abstract class Product : IProduct
    {
        private int id;
        private string manufacturer;
        private decimal price;
        private string dateOfArrival;
        private string dateOfShipment;
        public Product(int id, string manufacturer, decimal price, string dateOfArrival, string dateOfShipment)
        {
            this.Id = id;
            this.Manufacturer = manufacturer;
            this.Price = price;
            this.DateOfArrival = dateOfArrival;
            this.DateOfShipment = dateOfShipment;
        }
        public int Id 
        {
            get 
            {
                return this.id;
            } 
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidId);
                }
                this.id = value;
            }
        }
        public string Manufacturer 
        { 
            get
            {
                return this.manufacturer;
            }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidManufacturer);
                }

                this.manufacturer = value;
            }
        }
        public decimal Price 
        {
            get
            {
                return this.price;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPrice);
                }

                this.price = value;
            }
        }
        public string DateOfArrival
        {
            get
            {
                return this.dateOfArrival;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(SuccessMessages.ToBeArranged);
                }

                this.dateOfArrival = value;
            }
        }

        public string DateOfShipment
        {
            get
            {
                return this.dateOfShipment;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(SuccessMessages.ToBeArranged);
                }

                this.dateOfShipment = value;
            }
        }
    }
}
