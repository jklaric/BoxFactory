using box_company_back.models;
using Dapper;
using Npgsql;

namespace box_company_back.infrastructure;

public class Infrastructure
{
    private readonly NpgsqlDataSource _dataSource;

    public Infrastructure(NpgsqlDataSource dataSource)
    {
        _dataSource = dataSource;
    }

    public IEnumerable<Box> GetAllBoxes()
    {
        var sql = $@"select * from Boxes;";
        using(var conn = _dataSource.OpenConnection())
        {
            return conn.Query<Box>(sql);
        }
    }
}