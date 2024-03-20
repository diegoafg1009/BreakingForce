using Application.Enums;
using Application.Factories.Implementations;
using Domain.Entities;

namespace Infrastructure.Persistence.Data.Seeds;

public static class DefaultShipmentStatuses
{
    public static ShipmentStatus[] Seed()
    {
        return Enum.GetValues(typeof(ShipmentStatuses))
            .Cast<int>()
            .Select(item => (ShipmentStatuses)item)
            .Select(status => (ShipmentStatus)new ShipmentStatusFactory().Create(status))
            .ToArray();
    }

}