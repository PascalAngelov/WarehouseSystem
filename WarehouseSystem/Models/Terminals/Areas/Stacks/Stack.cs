using System;
using System.Collections.Generic;
using System.Linq;

using WarehouseSystem.Common.Constants;
using WarehouseSystem.Models.Products;

namespace WarehouseSystem.Models.Terminals.Areas.Stacks
{
    public class Stack : Area, IStack
    {
        private int number;
        private int row;
        private ICollection<IProduct> products;
        public Stack(string areaName, int number, int row) : base(areaName)
        {
            this.Number = number;
            this.Row = row;
            this.products = new List<IProduct>();
        }
        public int Number
        {
            get
            {
                return this.number;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidNumber);
                }

                this.number = value;
            }
        }

        public int Row
        {
            get
            {
                return this.row;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidNumber);
                }

                this.row = value;
            }
        }

        public IReadOnlyCollection<IProduct> Products => (IReadOnlyCollection<IProduct>)this.products;

        public void AddProduct(IProduct product)
        {
            this.products.Add(product);
        }

        public void RemoveProduct(int id)
        {
            IProduct product = this.products.FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidId);
            }

            this.products.Remove(product);
        }
    }
}
