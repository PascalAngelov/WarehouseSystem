namespace WarehouseSystem.Models.Transport.Vessels
{
    public interface IVessel : ITransport
    {
        string Name { get; }
        string Voyage { get; }
        
    }
}
