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
    public partial class EstCCoins : System.Web.UI.Page
    {
        readonly MySqlConnection conexion = new MySqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarCCoinsPorClase();
            }
        }

        protected void btnInfo_Click(object sender, EventArgs e)
        {

        }

        public void cargarCCoinsPorClase()
        {
            try
            {
                conexion.Open();
                int userID = Int32.Parse(Session["userId"].ToString());
                string cadena = CdEstudiantes.cargarCCoinsPorClase(userID);
                MySqlCommand cmd = new MySqlCommand(cadena, conexion);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gvuCCoins.DataSource = dt;
                gvuCCoins.DataBind();
                conexion.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}