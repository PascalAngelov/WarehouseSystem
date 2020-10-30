using System.Collections.Generic;
using WarehouseSystem.Models.Products;

namespace WarehouseSystem.Models.Terminals.Areas.Stacks
{
   public interface IStack
    {
        int Number { get; }
        int Row { get; }
        IReadOnlyCollection<IProduct> Products { get; }
        void AddProduct(IProduct product);
        void RemoveProduct(int id);
    }
}
