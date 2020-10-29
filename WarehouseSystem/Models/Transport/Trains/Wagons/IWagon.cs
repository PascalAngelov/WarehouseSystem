namespace WarehouseSystem.Models.Transport.Trains.Wagons
{
    public interface IWagon : ITrain
    {
        int NumberOfWagon { get; }
    }
}
