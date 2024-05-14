using EfCoreSevenFeatures.Dal;
using EfCoreSevenFeatures.Entity.Company;
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

    [Fact]
    public async Task CompanyToPersonMappingTest()
    {
        var company = new Company()
        {
            Name = "Greengoth",
            GeographicalLocations = new List<CompanyGeographicalLocation>()
            {
                new CompanyGeographicalLocation()
                {
                    Relation = "resident",
                    GeographicalLocation = new GeographicalLocation()
                    {
                        Name = "4, Privet Drive"
                    }
                }
            }
        };
        
        await using var context = new TestDbContext();
        await context.Set<Company>().AddAsync(company);

        await context.SaveChangesAsync();
    }
    
    
    [Fact]
    public async Task GetCompanyToPersonMappingTest()
    {
        await using var context = new TestDbContext();
        var a = await context.Set<Company>()
            .Include(x => x.GeographicalLocations)
            .ThenInclude(x => x.GeographicalLocation)
            .FirstOrDefaultAsync();
    }
}