using EfCoreSevenFeatures.Entity.People;

namespace EfCoreSevenFeatures;

public static class TestPeople
{
    public static Person HarryPotter => new Person
    {
        Address = new Address("4 Private Drive", "Little Whinging", "Surrey", "KT23 3AS"),
        FirstName = "Harry",
        LastName = "Potter",
    };   
    
    public static Person HermioneGranger => new Person
    {
        Address = new Address("12 Grimmauld Place", "London", "London", "NW1 6XE"),
        FirstName = "Hermione",
        LastName = "Granger",
    };
}