using System;
using System.Data;
using System.Data.SqlClient;

namespace FACTURACION.LOGIN
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Iniciar el foco en el primer textbox
            TxtUsuario.Focus();
        }

        protected void BtnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection sqlCon = ConexionDB.getInstancia().CrearConexion())
                using (SqlCommand cmd = new SqlCommand("sp_checlogin", sqlCon))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@usuario", TxtUsuario.Text.Trim()));
                    cmd.Parameters.Add(new SqlParameter("@clave", TxtClave.Text.Trim()));
                    sqlCon.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            //Variables de sesion
                            Session["Log_Status"] = dr["log_status"].ToString();
                            Session["Log_Codigo"] = dr["log_codigo"].ToString();
                            Session["Log_Usuario1"] = TxtUsuario.Text;
                            Session["Log_Nombre"] = dr["log_nombre"].ToString();
                            Session["Log_Apellido"] = dr["log_apellido"].ToString();
                            Session["Log_Departamento"] = dr["log_departamento"].ToString();
                            Session["Log_Cargo"] = dr["log_cargo"].ToString();

                            if (dr["log_status"].ToString() == "Activo")
                            {
                                LblMensaje.Text = "Mensaje.: Login correcto";

                                TxtUsuario.Enabled = false;
                                TxtClave.Enabled = false;
                                BtnAceptar.Enabled = false;

                                ImgCerradura.ImageUrl = "~/IMAGENES/CerraduraVerde.png";
                                Timer2.Enabled = true;
                            }
                            else
                            {
                                LblMensaje.Text = "Mensaje.: Usuario Inhabilitado";
                                Timer2.Enabled = true;
                            }
                        }
                        else
                        {
                            LblMensaje.Text = "Mensaje.: Login incorrecto";
                            Timer2.Enabled = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error de conexion con la Base de Datos: " + ex.Message);
                LblMensaje.Text = "Mensaje.: No hay conexion con la Base de Datos";
            }
        }

        protected void Timer1_Tick1(object sender, EventArgs e)
        {
            //Acceder al menu de la aplicacion y quitar mensajes
            if (LblMensaje.Text == "Mensaje.: Login correcto")
            {
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                LblMensaje.Text = "";
                Timer2.Enabled = false;
                TxtUsuario.Enabled = true;
                TxtClave.Enabled = true;
                BtnAceptar.Enabled = true;
                TxtUsuario.Focus();
            }
        }
    }
}
