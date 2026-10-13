using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Sistema_Facturacion.Login
{
    public partial class Default : System.Web.UI.Page
    {
        //Conexion a la DB
        SqlConnection SqlCon = new SqlConnection();

        protected void Page_Load(object sender, EventArgs e)
        {
            //Login Seguridad
            LblCodigo.Text = (string)Session["Log_Codigo"];
            LblUsuario.Text = (string)Session["Log_Usuario1"];
            LblNombre.Text = (string)Session["Log_Nombre"];
            LblApellido.Text = (string)Session["Log_Apellido"];
            LblDepartamento.Text = (string)Session["Log_Departamento"];
            LblCargo.Text = (string)Session["Log_Cargo"];

            SqlCon = ConexionDB.getInstancia().CrearConexion();
            SqlCommand cmd = new SqlCommand("sp_Insert_SeguridadLogin", SqlCon);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlCon.Open();

            cmd.Parameters.AddWithValue("@Log_Codigo", LblCodigo.Text);
            cmd.Parameters.AddWithValue("@Log_Usuario1", LblUsuario.Text);
            cmd.Parameters.AddWithValue("@Log_Nombre", LblNombre.Text);
            cmd.Parameters.AddWithValue("@Log_Apellido", LblApellido.Text);
            cmd.Parameters.AddWithValue("@Log_Departamento", LblDepartamento.Text);
            cmd.Parameters.AddWithValue("@Log_Cargo", LblCargo.Text);
            cmd.Parameters.AddWithValue("@Log_FechaEntrada", DateTime.Now);

            cmd.ExecuteScalar();
            SqlCon.Close();
        }
    }
}
```[cite: 3, 4, 5]

-- -

### ¿Dónde exactamente lo tienes que poner?

1.En el** Explorador de soluciones** (a la derecha de Visual Studio), busca el archivo asociado a tu página principal (por lo general se llama **`Default.aspx.cs`** o el archivo con extensión `.cs` que cuelga debajo de tu `.aspx`).
2. Haz doble clic en él para abrirlo en el editor de código.
3. Reemplaza todo su contenido con el código de arriba (o asegúrate de que los `using`, el `namespace`, la declaración de la clase y el método `Page_Load` queden estructurados exactamente como se muestra)[cite: 3, 4, 5].