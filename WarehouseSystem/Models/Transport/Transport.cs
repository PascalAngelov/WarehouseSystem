using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarehouseSystem.Models.Products;
using WarehouseSystem.Common.Constants;

namespace WarehouseSystem.Models.Transport
{
    public abstract class Transport : ITransport
    {
        private string forwarder;
        private string dateOfArrival;
        private string dateOfShipment;
        private ICollection<IProduct> products;
        public Transport(string nameOfForwarder, string dateOfArrival, string dateOfShipment)
        {
            this.NameOfForwarder = nameOfForwarder;
            this.DateOfArrival = dateOfArrival;
            this.DateOfShipment = dateOfShipment;
            this.products = new List<IProduct>();
        }
        public string NameOfForwarder
        {
            get
            {
                return this.forwarder;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidNameOfForwarder);
                }

                this.forwarder = value;
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

        public IReadOnlyCollection<IProduct> Products => (IReadOnlyCollection<IProduct>)this.products;

        public void AddProduct(IProduct product)
        {
            this.products.Add(product);
        }

        public void RemovePipe(int Id)
        {
            IProduct product = this.products.FirstOrDefault(p => p.Id == Id);

            if (product == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidId);
            }

            this.products.Remove(product);
        }
    }
}
