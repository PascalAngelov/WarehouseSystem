using System.Collections.Generic;
using WarehouseSystem.Models.Products;

namespace WarehouseSystem.Models.Transport
{
    public interface ITransport
    {
        string NameOfForwarder { get; }
        string DateOfArrival { get; }
        string DateOfShipment { get; }
        IReadOnlyCollection<IProduct> Products { get; }
        void AddProduct(IProduct product);
        void RemovePipe(int Id);
    }
}
