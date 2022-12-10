namespace EfCoreSevenFeatures.Entity.People;

public record Address(
    string Street,
    string City,
    string State,
    string ZipCode
);