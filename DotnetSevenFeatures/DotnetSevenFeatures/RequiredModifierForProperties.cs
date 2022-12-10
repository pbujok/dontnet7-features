namespace DotnetSevenFeatures;

public class RequiredModifierForProperties
{
    [Fact]
    public void Test1()
    {
        // Try to remove properties initialization
        var person = new Person()
        {
            FirstName = "Paul",
            LastName = "Atreides"
        };
    }
}

file class Person
{
    public required string FirstName { get; init; }
    public required string LastName { get; init; }

    public Person()
    {
    }

    public Person(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }
}