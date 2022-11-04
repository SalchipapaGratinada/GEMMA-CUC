using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;

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
                    Response.Redirect("Login.aspx");
                }
                else
                {
                    conexion.Close();
                    Response.Redirect("Register.aspx");
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}