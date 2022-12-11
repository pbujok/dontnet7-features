using EfCoreSevenFeatures.Dal;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;

namespace EfCoreSevenFeatures;

public class JsonColumnsExample
{
    [Fact]
    public async Task AddPerson()
    {
        await using var context = new TestDbContext();
        await context.People.AddAsync(TestPeople.HarryPotter);
        await context.SaveChangesAsync();
    }

    [Fact]
    public async Task ReadPerson()
    {
        // Arrange
        await using var context = new TestDbContext();
        var person = await context.People.FirstAsync(x => x.FirstName == TestPeople.HarryPotter.FirstName);

        // Assert
        person.FirstName.Should().Be(TestPeople.HarryPotter.FirstName);
        person.Address.Should().Be(TestPeople.HarryPotter.Address);
        person.Address.Street.Should().Be("4 Private Drive");
    }
}