using Npgsql;

namespace Infrastructure.DataContext;

public class DapperContext
{
    private readonly string _connectionString =
        $"Server=localhost;port=5432;database=marketplace_db;User Id=postgres;password=123456";

    public NpgsqlConnection Connection()
    {
        return new NpgsqlConnection(_connectionString);
    }
}