namespace EfCoreSevenFeatures.Entity.People;

public class Person
{
    public required Guid Id { get; init; }  = Guid.NewGuid();
    
    public required string FirstName { get; set; }
    
    public required string LastName { get; set; }
    
    public required Address Address { get; set; }
}