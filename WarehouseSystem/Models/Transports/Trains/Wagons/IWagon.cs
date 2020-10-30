namespace WarehouseSystem.Models.Transport.Trains.Wagons
{
    public interface IWagon : ITrain
    {
        string NumberOfWagon { get; }
    }
}
