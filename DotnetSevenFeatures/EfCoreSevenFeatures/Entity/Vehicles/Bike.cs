namespace EfCoreSevenFeatures.Entity.Vehicles;

public class Bike : Vehicle
{
    public required string FrameNumber { get; init; }

    public required int FrameSize { get; init; }

    private Bike()
    {
    }

    public Bike(string producer, string modelName) : base(producer, modelName)
    {
    }
}