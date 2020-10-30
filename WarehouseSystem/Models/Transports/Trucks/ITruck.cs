namespace WarehouseSystem.Models.Transport.Trucks
{
   public interface ITruck : ITransport
    {
        string TruckRegistrationNumber { get; }
        string TrailerRegistrationNumber { get; }
        string DriverFirstName { get; }
        string DriverLastName { get; }
        string DriverPersonalIdentificationNumber { get; }
        string DriverIdentityCard { get; }
    }
}
