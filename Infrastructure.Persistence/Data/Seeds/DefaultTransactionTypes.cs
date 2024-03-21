using Application.Enums;
using Domain.Entities;

namespace Infrastructure.Persistence.Data.Seeds;

public static class DefaultTransactionTypes
{
    public static TransactionType[] Seed()
    {
        return Enum.GetValues(typeof(TransactionTypes))
            .Cast<TransactionTypes>()
            .Select(type => new TransactionType(type.ToGuid(), type.ToString()))
            .ToArray();
    }
}