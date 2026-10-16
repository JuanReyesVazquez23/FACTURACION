using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace FACTURACION
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Validar que el usuario haya iniciado sesion
            if (Session["Log_Usuario1"] == null)
            {
                Response.Redirect("~/LOGIN/FRMLOGIN.aspx");
                return;
            }

            //Login Seguridad
            LblCodigo.Text = (string)Session["Log_Codigo"];
            LblUsuario.Text = (string)Session["Log_Usuario1"];
            LblNombre.Text = (string)Session["Log_Nombre"];
            LblApellido.Text = (string)Session["Log_Apellido"];
            LblDepartamento.Text = (string)Session["Log_Departamento"];
            LblCargo.Text = (string)Session["Log_Cargo"];

            try
            {
                using (SqlConnection sqlCon = ConexionDB.getInstancia().CrearConexion())
                using (SqlCommand cmd = new SqlCommand("sp_Insert_SeguridadLogin", sqlCon))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    sqlCon.Open();

                    cmd.Parameters.AddWithValue("@Log_Codigo", LblCodigo.Text ?? "");
                    cmd.Parameters.AddWithValue("@Log_Usuario1", LblUsuario.Text ?? "");
                    cmd.Parameters.AddWithValue("@Log_Nombre", LblNombre.Text ?? "");
                    cmd.Parameters.AddWithValue("@Log_Apellido", LblApellido.Text ?? "");
                    cmd.Parameters.AddWithValue("@Log_Departamento", LblDepartamento.Text ?? "");
                    cmd.Parameters.AddWithValue("@Log_Cargo", LblCargo.Text ?? "");
                    cmd.Parameters.AddWithValue("@Log_FechaEntrada", DateTime.Now);

                    cmd.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error al insertar seguridad login: " + ex.Message);
            }
        }
    }
}
