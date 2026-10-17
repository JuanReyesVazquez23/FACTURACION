using System;
using System.Data;
using System.Data.SqlClient;

namespace FACTURACION.LOGIN
{
    public partial class LoginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Iniciar el foco en el primer textbox
            usernameTextBox.Focus();
        }

        protected void AcceptButton_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection sqlConnection = DatabaseConnection.GetInstance().CreateConnection())
                using (SqlCommand sqlCommand = new SqlCommand("sp_CheckLogin", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@usuario", usernameTextBox.Text.Trim()));
                    sqlCommand.Parameters.Add(new SqlParameter("@clave", passwordTextBox.Text.Trim()));
                    sqlConnection.Open();

                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        if (dataReader.Read())
                        {
                            //Variables de sesion
                            Session["LoginStatus"] = dataReader["log_status"].ToString();
                            Session["LoginCode"] = dataReader["log_codigo"].ToString();
                            Session["LoginUser"] = usernameTextBox.Text;
                            Session["LoginName"] = dataReader["log_nombre"].ToString();
                            Session["LoginSurname"] = dataReader["log_apellido"].ToString();
                            Session["LoginDepartment"] = dataReader["log_departamento"].ToString();
                            Session["LoginRole"] = dataReader["log_cargo"].ToString();

                            if (dataReader["log_status"].ToString() == "Activo")
                            {
                                messageLabel.Text = "Mensaje.: Login correcto";

                                usernameTextBox.Enabled = false;
                                passwordTextBox.Enabled = false;
                                acceptButton.Enabled = false;

                                lockImage.ImageUrl = "~/IMAGENES/CerraduraVerde.png";
                                sessionTimer.Enabled = true;
                            }
                            else
                            {
                                messageLabel.Text = "Mensaje.: Usuario Inhabilitado";
                                sessionTimer.Enabled = true;
                            }
                        }
                        else
                        {
                            messageLabel.Text = "Mensaje.: Login incorrecto";
                            sessionTimer.Enabled = true;
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                System.Diagnostics.Debug.WriteLine("Error de conexion con la Base de Datos: " + exception.Message);
                messageLabel.Text = "Mensaje.: No hay conexion con la Base de Datos";
            }
        }

        protected void SessionTimer_Tick(object sender, EventArgs e)
        {
            //Acceder al menu de la aplicacion y quitar mensajes
            if (messageLabel.Text == "Mensaje.: Login correcto")
            {
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                messageLabel.Text = "";
                sessionTimer.Enabled = false;
                usernameTextBox.Enabled = true;
                passwordTextBox.Enabled = true;
                acceptButton.Enabled = true;
                usernameTextBox.Focus();
            }
        }
    }
}
