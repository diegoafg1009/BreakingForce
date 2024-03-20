using Application.Enums;
using Domain.Base;
using Domain.Entities;

namespace Application.Factories.Implementations;

public class PaymentStatusFactory : StatusFactory<PaymentStatuses>
{
    protected override Status FactoryMethod(PaymentStatuses statusName)
    {
        //TODO: PUT REAL GUIDS
        return statusName switch
        {
            PaymentStatuses.Pending => new PaymentStatus(Guid.Parse("6f17b493-4bdc-4c70-bbeb-f024d2e23600"),
                "Pendiente"),
            PaymentStatuses.Approved => new PaymentStatus(Guid.Parse("aeb99f15-1a49-4b77-b3ed-7958b9577ea9"),
                "Aprobado"),
            PaymentStatuses.Declined => new PaymentStatus(Guid.Parse("66ee5519-0d6d-4893-b919-8e68a827241c"),
                "Rechazado"),
            PaymentStatuses.Canceled => new PaymentStatus(Guid.Parse("a6917b23-590d-49f4-a7e1-780ea9f04f23"),
                "Cancelado"),
            _ => throw new ArgumentOutOfRangeException(nameof(statusName), statusName, null)
        };
    }
}