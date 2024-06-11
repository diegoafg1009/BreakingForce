using Application.Enums;
using Domain.Base;
using Domain.Entities;

namespace Application.Factories.Implementations;

public class ShipmentStatusFactory : StatusFactory<ShipmentStatuses>
{
    protected override Status FactoryMethod(ShipmentStatuses statusName)
    {
        return statusName switch
        {
            ShipmentStatuses.InPreparation => new ShipmentStatus(Guid.Parse("896ac5dc-5ee5-42ba-be53-4bc0e36ed2d6"), "En preparación"),
            ShipmentStatuses.InTransit => new ShipmentStatus(Guid.Parse("53869e29-d69e-4f5d-bfdb-d0872736dd50"), "En tránsito"),
            ShipmentStatuses.ReadyForPickup => new ShipmentStatus(Guid.Parse("93319dc2-70c9-4621-aa11-6c6c70401f4f"), "Listo para recoger"),
            ShipmentStatuses.Delivered => new ShipmentStatus(Guid.Parse("ddd08961-05e0-4662-aa10-f3c9e416be03"), "Entregado"),
            ShipmentStatuses.Canceled => new ShipmentStatus(Guid.Parse("3b2e81c3-32aa-439e-8514-7f7930c66154"), "Cancelado"),
            _ => throw new ArgumentOutOfRangeException(nameof(statusName), statusName, null)
        };
    }
}