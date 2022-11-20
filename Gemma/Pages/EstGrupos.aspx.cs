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
    public partial class EstGrupos : System.Web.UI.Page
    {
        readonly MySqlConnection conexion = new MySqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarDatosGrupos();
            }
        }

        protected void btnInfo_Click(object sender, EventArgs e)
        {

        }
        public void cargarDatosGrupos()
        {
            try
            {
                conexion.Open();
                int userID = Int32.Parse(Session["userId"].ToString());
                string cadena = CdEstudiantes.cargarGruposEstudiante(userID);
                MySqlCommand cmd = new MySqlCommand(cadena, conexion);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gvuGrupos.DataSource = dt;
                gvuGrupos.DataBind();
                conexion.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}