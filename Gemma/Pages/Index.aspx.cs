using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;
using Gemma.Cadenas;

namespace Gemma.Pages
{
    public partial class Index : System.Web.UI.Page
    {
        readonly MySqlConnection conexion = new MySqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIniciarSecion_Click(object sender, EventArgs e)
        {
            string usu = tbusuario.Text;
            string ps = tbpassword.Text;
            string cd = "SELECT EXISTS (SELECT * FROM users WHERE user_nickname = '" + usu + "' AND user_password = '" + ps + "');";
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
                    conexion.Close();
                    if (traerPerfil() == 4)
                    {
                        traerNombreAndId();
                        Response.Redirect("Estudiante.aspx");
                    }
                    else if(traerPerfil() == 3)
                    {
                        traerNombreAndId();
                        Response.Redirect("Profesor.aspx");
                    }
                    else
                    {
                        msjUsuarioOPassIncorrecta();
                    }

                }
                else
                {
                    conexion.Close();
                    msjUsuarioOPassIncorrecta();
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        

        public int traerPerfil()
        {
            string usu = tbusuario.Text;
            string pass = tbpassword.Text;
            try
            {
                conexion.Open();
                string cadena = CdRegistro.traerPerfil(usu, pass);
                MySqlDataAdapter da = new MySqlDataAdapter(cadena, conexion);
                DataSet ds = new DataSet();
                ds.Clear();
                da.Fill(ds);
                DataTable dt = ds.Tables[0];
                DataRow row = dt.Rows[0];
                string perfil = row[0].ToString();
                if (perfil.Equals("4"))
                {
                    conexion.Close();
                    return 4;
                }
                else if(perfil.Equals("3"))
                {
                    conexion.Close();
                    return 3;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
                
            }
        }


        public void traerNombreAndId()
        {
            string usu = tbusuario.Text;
            string pass = tbpassword.Text;
            try
            {
                conexion.Open();
                string cadena = CdRegistro.traerNombreAnndId(usu, pass);
                MySqlDataAdapter da = new MySqlDataAdapter(cadena, conexion);
                DataSet ds = new DataSet();
                ds.Clear();
                da.Fill(ds);
                DataTable dt = ds.Tables[0];
                DataRow row = dt.Rows[0];
                Session["userId"] = Int32.Parse(row[0].ToString());
                Session["nombre_usuario"] = row[1].ToString();
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        public void msjPerfilEstudiante()
        {
            string javaScript = string.Format("perfilEstudiante();");
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "perfilEstudiante", javaScript, true);
        }

        public void msjUsuarioOPassIncorrecta()
        {
            string javaScript = string.Format("UsuarioOPassInccorrecta();");
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "UsuarioOPassInccorrecta", javaScript, true);
        }



    }
}