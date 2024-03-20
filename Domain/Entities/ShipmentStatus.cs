using Domain.Base;

namespace Domain.Entities;

public class ShipmentStatus(Guid id, string name) : Status(id, name)
{
    public List<Shipment> Shipments { get; set; } = [];
}