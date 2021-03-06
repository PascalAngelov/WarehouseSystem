﻿namespace WarehouseSystem.Models.Products
{
    public interface IProduct
    {
        int Id { get; }
        
        string Manufacturer { get; }

        decimal Price { get; }

        string DateOfArrival { get; }

        string DateOfShipment { get; }

    }
}
