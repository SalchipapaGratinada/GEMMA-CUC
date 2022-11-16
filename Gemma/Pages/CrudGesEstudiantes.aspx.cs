using Gemma.Cadenas;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Gemma.Pages
{
    public partial class CrudGesEstudiantes : System.Web.UI.Page
    {
        readonly MySqlConnection conexion = new MySqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);
        public static string idEstudiante = "-1";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                idEstudiante = Request.QueryString["id"].ToString();
                mostrarDatos();
                bloquearCampos();
            }
            
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("GestionarEstudiantes.aspx");
        }

        public void bloquearCampos()
        {
            tbNombreEstudiante.Enabled = false;
            tbApellidoEstudiante.Enabled = false;
            tbNickEstudiante.Enabled = false;
            tbEmailEstudiante.Enabled = false;
        }

        public void mostrarDatos()
        {
            try
            {
                int id = Int32.Parse(idEstudiante);
                conexion.Open();
                string cadena = CdGestionEstudiantes.mostraDatos(id);
                MySqlDataAdapter da = new MySqlDataAdapter(cadena, conexion);
                DataSet ds = new DataSet();
                ds.Clear();
                da.Fill(ds);
                DataTable dt = ds.Tables[0];
                DataRow row = dt.Rows[0];
                tbNombreEstudiante.Text = row[1].ToString();
                tbApellidoEstudiante.Text = row[2].ToString();
                tbNickEstudiante.Text = row[3].ToString();
                tbEmailEstudiante.Text = row[5].ToString();
                conexion.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



    }
}