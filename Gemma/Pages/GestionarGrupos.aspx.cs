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
    public partial class GestionarGrupos : System.Web.UI.Page
    {
        readonly MySqlConnection conexion = new MySqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            cargarGrupos();
        }

        protected void btnCrear_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/CrudGrupos.aspx?op=C");
        }

        public void cargarGrupos()
        {
            try
            {
                conexion.Open();
                int userID = Int32.Parse(Session["userId"].ToString());
                string cadena = CdGrupos.cargarGrupos(userID);
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

        protected void BtnRead_Click(object sender, EventArgs e)
        {
            string id;
            Button btnConsultar = (Button)sender;
            GridViewRow seleccionF = (GridViewRow)btnConsultar.NamingContainer;
            id = seleccionF.Cells[1].Text;
            Response.Redirect("~/Pages/CrudGrupos.aspx?id=" + id + "&op=L");
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            string id;
            Button btnConsultar = (Button)sender;
            GridViewRow seleccionF = (GridViewRow)btnConsultar.NamingContainer;
            id = seleccionF.Cells[1].Text;
            Response.Redirect("~/Pages/CrudGrupos.aspx?id=" + id + "&op=A");
        }
    

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            string id;
            Button btnConsultar = (Button)sender;
            GridViewRow seleccionF = (GridViewRow)btnConsultar.NamingContainer;
            id = seleccionF.Cells[1].Text;
            Response.Redirect("~/Pages/CrudGrupos.aspx?id=" + id + "&op=E");
        }
    }
}