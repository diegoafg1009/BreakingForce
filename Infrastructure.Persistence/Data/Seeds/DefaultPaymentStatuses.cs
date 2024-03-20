using Application.Enums;
using Application.Factories.Implementations;
using Domain.Entities;

namespace Infrastructure.Persistence.Data.Seeds;

public static class DefaultPaymentStatuses
{
    public static PaymentStatus[] Seed()
    {
        return Enum.GetValues(typeof(PaymentStatuses))
            .Cast<int>()
            .Select(item => (PaymentStatuses)item)
            .Select(status => (PaymentStatus)new PaymentStatusFactory().Create(status))
            .ToArray();
    }

}