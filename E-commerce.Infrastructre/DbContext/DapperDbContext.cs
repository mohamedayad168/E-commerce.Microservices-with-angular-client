using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;

namespace E_commerce.Infrastructre.DbContext
{
    public class DapperDbContext
    {
        private readonly IConfiguration _config;
        private readonly IDbConnection dbConnection;

        public DapperDbContext(IConfiguration config)
        {
            _config = config;
            var connectionstring = _config.GetConnectionString("PostgresConnection");
            dbConnection = new NpgsqlConnection(connectionstring);
        }

        public IDbConnection connection => dbConnection;
    }
}
