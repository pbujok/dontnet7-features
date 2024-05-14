namespace EfCoreSevenFeatures.Entity.Company;

public class Company
{
    public  decimal Id { get; set; }

    public required string Name { get; set; }

    public List<CompanyGeographicalLocation> GeographicalLocations { get; set; } =
        new List<CompanyGeographicalLocation>();
}

public class CompanyGeographicalLocation
{
    public decimal CompanyId { get; set; }

    public decimal GeographicalLocationId { get; set; }

    public Company Company { get; set; }

    public GeographicalLocation GeographicalLocation { get; set; }

    public string Relation { get; set; }
}

public class GeographicalLocation
{
    public decimal Id { get; set; }

    public string Name { get; set; }

    public List<CompanyGeographicalLocation> Companies { get; set; } =
        new List<CompanyGeographicalLocation>();
}