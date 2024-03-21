namespace Application.Enums;

public enum TransactionTypes
{
    Creation,
    Update,
}

public static class TransactionTypesExtensions
{

    public static Guid ToGuid(this TransactionTypes type)
    {
        return type switch
        {
            TransactionTypes.Creation => new Guid("56626b64-485b-458a-99fb-cdb5b635526e"),
            TransactionTypes.Update => new Guid("922ff6a9-ad99-4b78-8826-fc2136829e53"),
            _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
        };
    }
}