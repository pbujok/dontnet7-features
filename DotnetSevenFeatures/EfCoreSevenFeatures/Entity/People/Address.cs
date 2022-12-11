namespace EfCoreSevenFeatures.Entity.People;

public class Group
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public ICollection<Person> People { get; set; }
}

public record Address(
    string Street,
    string City,
    string State,
    string ZipCode
);