using Npgsql;

namespace box_company_back.utillity;

public class Utillity
{
    public static readonly Uri Uri;
    public static readonly string ProperlyFormattedConnectionString;

    static Utillity()
    {
        string rawConnectionString;
        string envVarKeyName = "pgconn";

        rawConnectionString = Environment.GetEnvironmentVariable(envVarKeyName)!;
        if (rawConnectionString == null)
        {
            throw new Exception($@"Missing environment variable, please add your connection string!");
        }

        try
        {
            Uri = new Uri(rawConnectionString);
            ProperlyFormattedConnectionString = string.Format(
                "Server={0};Database={1};User Id={2};Password={3};Port={4};Pooling=true;MaxPoolSize=3",
                Uri.Host,
                Uri.AbsolutePath.Trim('/'),
                Uri.UserInfo.Split(':')[0],
                Uri.UserInfo.Split(':')[1],
                Uri.Port > 0 ? Uri.Port : 5432);
            new NpgsqlDataSourceBuilder(ProperlyFormattedConnectionString).Build().OpenConnection().Close();
        }
        catch (Exception e)
        {
            throw new Exception($@"Connection string is found but cannot be used.", e);
        }
    }

}