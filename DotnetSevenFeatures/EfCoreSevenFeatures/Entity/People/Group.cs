namespace EfCoreSevenFeatures.Entity.People;

public class Group
{
    public Guid Id { get; init; } = Guid.NewGuid();
    
    public required string Name { get; set; }
    
    public required string ContactTelephoneNumber { get; set; }
    
    public required string ContactEmailAddress { get; set; }
    
    public ICollection<Person> People { get; set; }
}