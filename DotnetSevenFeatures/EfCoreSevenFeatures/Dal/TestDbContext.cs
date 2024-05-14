using EfCoreSevenFeatures.Entity.Company;
using EfCoreSevenFeatures.Entity.People;
using EfCoreSevenFeatures.Entity.Vehicles;
using Microsoft.EntityFrameworkCore;

namespace EfCoreSevenFeatures.Dal;

public class TestDbContext : DbContext
{
    public DbSet<Vehicle> Vehicles => Set<Vehicle>();

    public DbSet<Car> Cars => Set<Car>();

    public DbSet<Bike> Bikes => Set<Bike>();

    public DbSet<Person> People => Set<Person>();

    public DbSet<Group> Groups => Set<Group>();

    public TestDbContext()
    {
    }

    public TestDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var provider = new ConnectionStringProvider();
        optionsBuilder.UseSqlServer(provider.Get());
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Vehicle>()
            .UseTpcMappingStrategy()
            .HasKey(x => x.Id);

        modelBuilder.Entity<Vehicle>()
            .Property(x => x.ModelName);

        modelBuilder.Entity<Vehicle>()
            .Property(x => x.Producer);

        modelBuilder.Entity<Person>().ToTable("People", tb => { tb.HasTrigger("SomeTrigger"); }).HasKey(x => x.Id);

        modelBuilder.Entity<Person>().OwnsOne(x => x.Address).ToJson();

        modelBuilder.Entity<Group>()
            .ToTable("Groups")
            .SplitToTable("GroupContactInfo", builder =>
            {
                builder.Property(x => x.ContactEmailAddress);
                builder.Property(x => x.ContactTelephoneNumber);
                builder.Property(x => x.Id).HasColumnName("PersonId");
            });

        modelBuilder
            .Entity<Group>()
            .HasMany(x => x.People)
            .WithMany();

        modelBuilder
            .Entity<Company>()
            .HasMany(x => x.GeographicalLocations)
            .WithOne(x => x.Company)
            .HasForeignKey(x => x.CompanyId)
            .HasPrincipalKey(x => x.Id);

        modelBuilder
            .Entity<Company>()
            .Property(x => x.Id)
            .HasPrecision(18, 0)
            .ValueGeneratedOnAdd();
        
        modelBuilder
            .Entity<GeographicalLocation>()
            .HasMany(x => x.Companies)
            .WithOne(x => x.GeographicalLocation)
            .HasForeignKey(x => x.GeographicalLocationId)
            .HasPrincipalKey(x => x.Id);
        
        modelBuilder
            .Entity<GeographicalLocation>()
            .Property(x => x.Id)
            .HasPrecision(18, 0)
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<CompanyGeographicalLocation>()
            .HasKey(x => new { x.CompanyId, x.GeographicalLocationId });
        
        modelBuilder
            .Entity<CompanyGeographicalLocation>()
            .Property(x => x.CompanyId)
            .HasPrecision(18, 0);
        
        modelBuilder
            .Entity<CompanyGeographicalLocation>()
            .Property(x => x.GeographicalLocationId)
            .HasPrecision(18, 0);
    }
}