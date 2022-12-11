using EfCoreSevenFeatures.Dal;
using EfCoreSevenFeatures.Entity.Vehicles;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;

namespace EfCoreSevenFeatures;

public class TpcExample
{
    [Fact]
    public async Task AddVehicles()
    {
        // Arrange
        var car = new Car("Lexus", "LC500")
        {
            Vin = "12345678",
            FuelType = "Gasoline"
        };

        var bike = new Bike("Pinarello", "Dogma F10")
        {
            FrameNumber = "123abc",
            FrameSize = 54
        };

        // Act
        await using var context = new TestDbContext();
        await context.Set<Vehicle>().AddAsync(car);
        await context.Set<Vehicle>().AddAsync(bike);
        await context.SaveChangesAsync();
    }
    
    [Fact]
    public async Task ReadVehicles()
    {
        await using var context = new TestDbContext();
        var allVehicles = await context.Set<Vehicle>().ToListAsync();

        allVehicles.Should().Contain(x => x is Car);
        allVehicles.Should().Contain(x => x is Bike);
    }
}