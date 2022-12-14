using Gemma.Cadenas;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Gemma.Pages
{
    public partial class Register : System.Web.UI.Page
    {
        readonly MySqlConnection conexion = new MySqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarDropCarreras();
            }
            
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            tbnombre.Text = "";
            tbApellido.Text = "";
            tbPassword.Text = "";
            tbConfirmacionPassword.Text = "";
            tbEmail.Text = "";
            tbnombre.Focus();
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            string nombre = tbnombre.Text;
            string apellido = tbApellido.Text;
            string nikcName = tbNickName.Text;
            string pass = tbPassword.Text;
            string confirPass = tbConfirmacionPassword.Text;
            string email = tbEmail.Text;
            if (validarCamposVacios(nombre) && validarCamposVacios(nikcName) && validarCamposVacios(apellido) && validarCamposVacios(confirPass) && validarCamposVacios(pass) && validarCamposVacios(email))
            {
                if (passwordIguales(pass, confirPass))
                {
                    if (!validarNick() && !validarCorreo())
                    {
                        int idCarrera = Int32.Parse(dropCarreras.SelectedValue.ToString());
                        if (idCarrera != 0 )
                        {
                            try
                            {
                                conexion.Open();
                                string cadena = CdRegistro.registrarUsuario(nombre, apellido, nikcName, pass, email, idCarrera);
                                MySqlCommand cmd = new MySqlCommand(cadena, conexion);
                                cmd.ExecuteNonQuery();
                                conexion.Close();
                                msjUsuarioAgregado();
                                bloquearCampos();
                            }
                            catch (Exception ex)
                            {
                                throw ex;
                            }
                        }
                        else
                        {
                            msjSeleccioneCarrera();
                        }
                        
                    }                                           
                }
                else
                {
                    msjPassNoCoinciden();
                }
            }
            else
            {
                msjCamposVacios();
            }
        }

        public void cargarDropCarreras()
        {
            try
            {
                string cadena = CdRegistro.cargarDropCarreras();
                MySqlCommand cmd = new MySqlCommand(cadena, conexion);
                conexion.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dropCarreras.DataSource = ds;
                dropCarreras.DataTextField = "name";
                dropCarreras.DataValueField = "id";
                dropCarreras.DataBind();
                dropCarreras.Items.Insert(0, new ListItem("Seleccione Su Carrera", "0"));
                conexion.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        protected Boolean validarCamposVacios(string entrada)
        {
            if (entrada.Equals(""))
            {
                return false;
            }
            return true;
        }

        protected Boolean passwordIguales(string pass, string confirmacionPass)
        {
            if (pass.Equals(confirmacionPass))
            {
                return true;
            }
            return false;
        }

        public Boolean validarNick()
        {
            string nick = tbNickName.Text;
            string cd = "SELECT EXISTS (SELECT * FROM users WHERE user_nickname = '" + nick + "');";
            try
            {
                conexion.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cd, conexion);
                DataSet ds = new DataSet();
                ds.Clear();
                da.Fill(ds);
                DataTable dt = ds.Tables[0];
                DataRow row = dt.Rows[0];
                string boo = row[0].ToString();
                if (boo.Equals("1"))
                {
                    msjNickYaExiste();
                    conexion.Close();
                    return true;
                }
                else
                {
                    conexion.Close();
                    return false;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public Boolean validarFormatoCorreo(string correo)
        {
            string validador = "^[_A-Za-z0-9-\\+]+(\\.[_A-Za-z0-9-]+)*@[A-Za-z0-9-]+(\\.[A-Za-z0-9]+)*(\\.[A-Za-z]{2,})$";
            Boolean salida = Regex.IsMatch(correo,validador);
            return salida;
        }
        public Boolean validarCorreo()
        {
            string email = tbEmail.Text;
            string cd = "SELECT EXISTS (SELECT * FROM users WHERE user_email = '" + email + "');";
            try
            {
                if (validarFormatoCorreo(email))
                {
                    conexion.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter(cd, conexion);
                    DataSet ds = new DataSet();
                    ds.Clear();
                    da.Fill(ds);
                    DataTable dt = ds.Tables[0];
                    DataRow row = dt.Rows[0];
                    string boo = row[0].ToString();
                    if (boo.Equals("1"))
                    {
                        msjCorreo();
                        conexion.Close();
                        return true;
                    }
                    else
                    {
                        conexion.Close();
                        return false;
                    }
                }
                else
                {
                    return false;
                }
                

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void msjCamposVacios ()
        {
            //string javaScript = "alertacamposVacios();";
            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertacamposVacios", javaScript, true);
            string javaScript = string.Format("camposVacios();");
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "camposVacios", javaScript, true);
        }

        public void msjPassNoCoinciden()
        {
            string javaScript = string.Format("passwordNoCoinciden();");
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "passwordNoCoinciden", javaScript, true);
        }
        public void msjUsuarioAgregado()
        {
            string javaScript = string.Format("usuarioRegistrado();");
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "usuarioRegistrado", javaScript, true);
        }
        public void msjNickYaExiste()
        {
            string javaScript = string.Format("nickYaExiste();");
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "nickYaExiste", javaScript, true);
        }

        public void msjSeleccioneCarrera()
        {
            string javaScript = string.Format("seleccioneCarrera();");
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "seleccioneCarrera", javaScript, true);
        }
        public void msjCorreo()
        {
            string javaScript = string.Format("correoExiste();");
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "correoExiste", javaScript, true);
        }

        public void msjtodoReady()
        {
            string javaScript = string.Format("procesoBien();");
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "procesoBien", javaScript, true);
        }

        public void bloquearCampos()
        {
            tbnombre.Enabled = false;
            tbApellido.Enabled = false;
            tbNickName.Enabled = false;
            tbConfirmacionPassword.Enabled = false;
            tbPassword.Enabled = false;
            tbEmail.Enabled = false;
            dropCarreras.Enabled = false;
        }

    }
}