namespace EfCoreSevenFeatures.Entity.Vehicles;

public class Bike : Vehicle
{
    public required string FrameNumber { get; init; }

    public required int FrameSize { get; init; }

    public Bike()
    {
    }

    public Bike(Guid id, string producer, string modelName) : base(id, producer, modelName)
    {
    }
}