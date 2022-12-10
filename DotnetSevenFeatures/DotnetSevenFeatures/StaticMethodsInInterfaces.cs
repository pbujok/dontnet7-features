using FluentAssertions;

namespace DotnetSevenFeatures;

public class StaticMethodsInInterfaces
{
    [Fact]
    public void UsingStaticMethodsInInterfaces()
    {
        // Arrange
        var givenDistance = 600;

        // Act && Assert
        CalculateTravelTime<Car>(givenDistance).Should().Be(new TimeSpan(6, 0, 0));
        CalculateTravelTime<Bike>(givenDistance).Should().Be(new TimeSpan(20, 0, 0));
        CalculateTravelTime<Plane>(givenDistance).Should().Be(new TimeSpan(0, 45, 0));
    }

    private TimeSpan CalculateTravelTime<T>(int distance) where T : IVehicle
    {
        var instance = T.CreateInstance();
        return instance.CalculateTravelTime(distance);
    }

    private interface IVehicle
    {
        static abstract IVehicle CreateInstance();

        TimeSpan CalculateTravelTime(int distance);
    }

    private class Car : IVehicle
    {
        public static IVehicle CreateInstance() => new Car();

        public TimeSpan CalculateTravelTime(int distance)
        {
            return TimeSpan.FromHours(distance / 100.0);
        }
    }

    private class Bike : IVehicle
    {
        public static IVehicle CreateInstance() => new Bike();

        public TimeSpan CalculateTravelTime(int distance)
        {
            return TimeSpan.FromHours(distance / 30.0);
        }
    }

    private class Plane : IVehicle
    {
        public static IVehicle CreateInstance() => new Plane();

        public TimeSpan CalculateTravelTime(int distance)
        {
            return TimeSpan.FromHours(distance / 800.0);
        }
    }
}