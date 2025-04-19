using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
namespace BancoApp.Data
{
    public class DatabaseHelper
    {
        private readonly string _connectionString;

        public DatabaseHelper(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection")!;
        }
        public SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
        
        public bool TestConnection()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

    }
    
    
}
