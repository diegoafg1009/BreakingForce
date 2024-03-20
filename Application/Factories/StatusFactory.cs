using Domain.Base;

namespace Application.Factories;

public abstract class StatusFactory <T> where T : Enum
{
    protected abstract Status FactoryMethod(T statusName);
    public Status Create(T statusName)
    {
        var status = FactoryMethod(statusName);
        return status;
    }
}