using Dapper;
using Microsoft.Data.SqlClient;

namespace HBO.Data;

public class ApplicationDbContextDP
{
    private readonly IConfiguration _config;
    public ApplicationDbContextDP(IConfiguration config)
    {
        _config = config;
    }


    public IEnumerable<T> LoadData<T>(string sql)
    {
        using (var conn = new SqlConnection(_config.GetConnectionString("Default")))
        {
            return conn.Query<T>(sql);
        }
    }

    public T LoadDataSingle<T>(string sql)
    {
        using (var conn = new SqlConnection(_config.GetConnectionString("Default")))
        {
            return conn.QuerySingle<T>(sql);
        }
    }

    public int ExecuteSql(string sql)
    {
        using (var conn = new SqlConnection(_config.GetConnectionString("Default")))
        {
            return conn.Execute(sql);
        }
    }


    public bool Execute(string sql)
    {
        using (var conn = new SqlConnection(_config.GetConnectionString("Default")))
        {
            return conn.Execute(sql) > 0;
        }
    }
}
