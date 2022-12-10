namespace EfCoreSevenFeatures.Dal;

public class ConnectionStringProvider : IConnectionStringProvider
{
    public string Get()
    {
        return "Server=.;Database=EfCoreSevenFeatures;Integrated Security=SSPI;TrustServerCertificate=True";
    }
}