using Npgsql;

namespace box_company_back.utillity;

public class Utillity
{
    public static readonly Uri Uri;
    public static readonly string ProperlyFormattedConnectionString;
    public static readonly NpgsqlDataSource DataSource;

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
            DataSource = 
                new NpgsqlDataSourceBuilder(ProperlyFormattedConnectionString).Build();
                DataSource.OpenConnection().Close();
        }
        catch (Exception e)
        {
            throw new Exception($@"Connection string is found but cannot be used.", e);
        }
    }
    
    public static string BadResponse(string content)
    {
        return $@"An issue occured while fetching the response body from the API and turning it into a class object.
        Reponse Body: {content}

        EXCEPTION:
        ";
    }

    public static void TriggerRebuild()
    {
        using (var conn = DataSource.OpenConnection())
        {
            try
            {
                conn.Execute(RebuildScript);
            }
            catch (Exception e)
            {
                throw new Exception($@"An error occured while rebuilding the DB. EXCEPTION:", e);
            }
        }
    }

    public static string RebuildScript = @"
DROP SCHEMA IF EXISTS Boxes CASCADE;
CREATE SCHEMA Boxes;

Create Table if not exists Boxes (
boxID int,
height int,
width int,
length int,
type varchar(255),
amount int
);";
    
    public static string NoResponseMessage = $@"
There was no response from the API, the API may not be running.
    ";

 	public static string MyBecause(object actual, object expected)
    {
        string expectedJson = JsonConvert.SerializeObject(expected, Formatting.Indented);
        string actualJson = JsonConvert.SerializeObject(actual, Formatting.Indented);

        return $"because we want these objects to be equivalent:\nExpected:\n{expectedJson}\nActual:\n{actualJson}";
    }
}