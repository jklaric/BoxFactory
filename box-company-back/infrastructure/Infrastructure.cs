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
    
    public Box CreateBox(int height, int width, int length, string type, int amount )
    {
        var sql = $@"INSERT INTO Boxes (height, width, length, type, amount)
                    VALUES (@height, @width, @length, @type, @amount)
                    RETURNING boxID as {nameof(Box.BoxID)},
                                height as {nameof(Box.Height)},
                                width as {nameof(Box.Width)},
                                length as {nameof(Box.Length)},
                                type as {nameof(Box.Type)},
                                amount as {nameof(Box.Amount)}";
        
        using (var conn = _dataSource.OpenConnection())
        {
            return conn.QueryFirst<Box>(sql, new { height, width, length, type, amount });
        }
    }

    public Box UpdateBox(int id, int height, int width, int length, string type, int amount)
    {
        var sql =
            $@"UPDATE Boxes SET height = @height, width = @width, length = @length, type = @length, amount = @amount
                        WHERE boxID = @id
                        RETURNING boxID as {nameof(Box.BoxID)}
                                height as {nameof(Box.Height)},
                                    width as {nameof(Box.Width)},
                                    length as {nameof(Box.Length)},
                                    type as {nameof(Box.Type)},
                                    amount as {nameof(Box.Amount)}";

        using (var conn = _dataSource.OpenConnection())
        {
            return conn.QueryFirst<Box>(sql, new { id, height, width, length, type, amount });
        }
    }
    
    public bool DeleteBox(int id)
    {
        var sql = @"DELETE FROM Boxes WHERE boxID = @id";
        using (var conn = _dataSource.OpenConnection())
        {
            return conn.Execute(sql, new { id }) == 1;
        }
    }
}