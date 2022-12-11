namespace EfCoreSevenFeatures.Entity.Vehicles;

public abstract class Vehicle
{
    public Guid Id { get; init; }

    public string Producer { get;  }

    public string ModelName { get;  }

    protected Vehicle()
    {
        
    }
    
    public Vehicle(string producer, string modelName)
    {
        Id = Guid.NewGuid();
        Producer = producer;
        ModelName = modelName;
    }
}