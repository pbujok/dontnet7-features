namespace EfCoreSevenFeatures.Entity.Vehicles;

public abstract class Vehicle
{
    public Guid Id { get; init; }

    public string Producer { get; }

    public string ModelName { get; }

    public Vehicle()
    {
        
    }
    
    public Vehicle(Guid id, string producer, string modelName)
    {
        Id = id;
        Producer = producer;
        ModelName = modelName;
    }
}