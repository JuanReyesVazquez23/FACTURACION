using System.Configuration;
using System.Data.SqlClient;

namespace FACTURACION
{
    public class DatabaseConnection
    {
        private static DatabaseConnection _instance;

        private DatabaseConnection()
        {
        }

        public static DatabaseConnection GetInstance()
        {
            if (_instance == null)
            {
                _instance = new DatabaseConnection();
            }
            return _instance;
        }

        // Crea una conexión usando la cadena "CnFact" del Web.config.
        public SqlConnection CreateConnection()
        {
            var connectionSetting = ConfigurationManager.ConnectionStrings["CnFact"];
            string connectionString = connectionSetting != null && !string.IsNullOrWhiteSpace(connectionSetting.ConnectionString)
                ? connectionSetting.ConnectionString
                : "Server=localhost; Database=Facturacion; Integrated Security=SSPI;";

            return new SqlConnection(connectionString);
        }
    }
}
