using Application.Enums;
using Application.Factories.Implementations;
using Domain.Entities;

namespace Infrastructure.Persistence.Data.Seeds;

public static class DefaultOrderStatuses
{
    public static OrderStatus[] Seed()
    {
        return Enum.GetValues(typeof(OrderStatuses))
            .Cast<int>()
            .Select(item => (OrderStatuses)item)
            .Select(status => (OrderStatus)new OrderStatusFactory().Create(status))
            .ToArray();
    }
}