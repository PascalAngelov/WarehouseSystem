using WarehouseSystem.Models.Transport;
using WarehouseSystem.Models.Terminals.Areas.Stacks;
namespace WarehouseSystem.Models.Products.Pipes
{
    public interface IPipe : IProduct
    {
        ITransport TransportArrival { get; }
        ITransport TransportDispatch { get; }
        IStack Stack { get; }
        bool Quarantined { get; }
        bool CustomsClearance { get; }
        bool Dispatched { get; }
        bool Repaired { get; }
        void ChangeStatus(string quarantined, string customsClearance, string dispatched, string repaired);
    }
}
