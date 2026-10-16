using System.Configuration;
using System.Data.SqlClient;

namespace FACTURACION
{
    public class ConexionDB
    {
        private static ConexionDB _instancia;

        private ConexionDB()
        {
        }

        public static ConexionDB getInstancia()
        {
            if (_instancia == null)
            {
                _instancia = new ConexionDB();
            }
            return _instancia;
        }

        // Crea una conexión usando la cadena "CnFact" del Web.config.
        public SqlConnection CrearConexion()
        {
            var cnSetting = ConfigurationManager.ConnectionStrings["CnFact"];
            string connectionString = cnSetting != null && !string.IsNullOrWhiteSpace(cnSetting.ConnectionString)
                ? cnSetting.ConnectionString
                : "Server=localhost; Database=Facturacion; Integrated Security=SSPI;";

            return new SqlConnection(connectionString);
        }
    }
}
