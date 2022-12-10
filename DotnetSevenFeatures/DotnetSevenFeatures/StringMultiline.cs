using FluentAssertions;
using Newtonsoft.Json;

namespace DotnetSevenFeatures;

public class StringMultiline
{
    [Fact]
    public void UsingJsonInCSharpCode()
    {
        // Arrange
        var data = """
            [
                {
                    "name": "Luke Skywalker",
                    "isRealPerson": false
                },
                {
                    "name": "Nikola Tesla",
                    "isRealPerson": true
                },
                {
                    "name": "Gandalf The Gray",
                    "isRealPerson": true
                },
                {
                    "name": "Walter E. Kurtz",
                    "isRealPerson": false
                }
            ]
            """;
        
        // Act
        var deserialized = JsonConvert.DeserializeObject<ICollection<Person>>(data);

        // Assert
        deserialized!.Count.Should().Be(4);
    }
    
    private record Person(string Name, bool IsRealPerson);
}