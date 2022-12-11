using EfCoreSevenFeatures.Dal;
using EfCoreSevenFeatures.Entity.People;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;

namespace EfCoreSevenFeatures;

public class ManyToManyAndTTableSplitExample
{
    private const string Gryffindor = "Gryffindor";

    private Group _group = new Group
    {
        People = new List<Person>
            { TestPeople.HarryPotter, TestPeople.HermioneGranger }, // Many to many without two way navigation
        Name = Gryffindor,
        ContactEmailAddress = "gryffindor91@gmail.com", // Table spliting
        ContactTelephoneNumber = "+44 123 456 789"
    };

    [Fact]
    public async Task AddGroup()
    {
        await using var context = new TestDbContext();
        await context.Groups.AddAsync(_group);
        await context.SaveChangesAsync();
    }

    [Fact]
    public async Task ReadGroup()
    {
        // Arrange
        await using var context = new TestDbContext();
        var group = await context.Groups
            .Include(x => x.People)
            .FirstAsync(x => x.Name == Gryffindor);

        // Assert
        group.ContactEmailAddress.Should().Be(_group.ContactEmailAddress);
        group.ContactTelephoneNumber.Should().Be(_group.ContactTelephoneNumber);
        group.Name.Should().Be(Gryffindor);
    }
}