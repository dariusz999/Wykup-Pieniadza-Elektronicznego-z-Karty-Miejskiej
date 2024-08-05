using System.Data;

namespace FinalProjectWabAPI.Db
{
    public interface IDapperContext
    {
        IDbConnection CreateConnection();
    }
}
