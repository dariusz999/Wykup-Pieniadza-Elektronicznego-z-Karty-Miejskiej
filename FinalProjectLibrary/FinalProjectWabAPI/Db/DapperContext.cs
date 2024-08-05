using System.Data;
using Microsoft.Data.SqlClient;

namespace FinalProjectWabAPI.Db
{
    public class DapperContext : IDapperContext
    {
        private readonly IConfiguration _configuration;
        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IDbConnection CreateConnection()
            => new
                SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
    }
}
