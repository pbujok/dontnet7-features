namespace EfCoreSevenFeatures.Entity.Vehicles;

public class Car : Vehicle
{
    public required string Vin { get; init; }

    public required string FuelType { get; init; }

    public Car()
    {
    }

    public Car(string producer, string modelName) : base(producer, modelName)
    {
    }
}