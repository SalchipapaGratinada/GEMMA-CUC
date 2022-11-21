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
    public partial class Premios : System.Web.UI.Page
    {
        readonly MySqlConnection conexion = new MySqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarDropClases();
            }
        }

        public void cargarDropClases()
        {
            try
            {
                int idUser = Int32.Parse(Session["userId"].ToString());
                string cadena = CdEstudiantes.cargarDropClasesEstudiante(idUser);
                MySqlCommand cmd = new MySqlCommand(cadena, conexion);
                conexion.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dropClases.DataSource = ds;
                dropClases.DataTextField = "name";
                dropClases.DataValueField = "id";
                dropClases.DataBind();
                dropClases.Items.Insert(0, new ListItem("Seleccione Clase ", "0"));
                conexion.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnCrear_Click(object sender, EventArgs e)
        {
            int idClase = Int32.Parse(dropClases.SelectedValue.ToString());
            if (idClase != 0)
            {
                Response.Redirect("CrudPremios.aspx?idClase=" + idClase + "&op=C");
            }
            else
            {
                msjDropSinSelecionarClase();
            }
        }

        public void msjDropSinSelecionarClase()
        {
            string javaScript = string.Format("dropClasesVacio();");
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "dropClasesVacio", javaScript, true);
        }

        protected void dropClases_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idClase = Int32.Parse(dropClases.SelectedValue.ToString());
            cargarPremios(idClase);
        }

        public void cargarPremios(int idClase)
        {
            try
            {
                conexion.Open();
                string cadena = CdPremios.cargarPremiosPorClase(idClase);
                MySqlCommand cmd = new MySqlCommand(cadena, conexion);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gvuPremios.DataSource = dt;
                gvuPremios.DataBind();
                conexion.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            string id;
            Button btnConsultar = (Button)sender;
            GridViewRow seleccionF = (GridViewRow)btnConsultar.NamingContainer;
            id = seleccionF.Cells[1].Text;
            Response.Redirect("~/Pages/CrudPremios.aspx?idPremio=" + id + "&op=E");
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            string id;
            Button btnConsultar = (Button)sender;
            GridViewRow seleccionF = (GridViewRow)btnConsultar.NamingContainer;
            id = seleccionF.Cells[1].Text;
            Response.Redirect("~/Pages/CrudPremios.aspx?idPremio=" + id + "&op=A");
        }
    }
}