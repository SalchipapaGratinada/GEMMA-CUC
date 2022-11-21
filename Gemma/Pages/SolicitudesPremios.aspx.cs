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
    public partial class SolicitudesPremios : System.Web.UI.Page
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

        protected void dropClases_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idClase = Int32.Parse(dropClases.SelectedValue.ToString());
            cargarSolicitudesPremios(idClase);
        }

        public void cargarSolicitudesPremios(int idClase)
        {
            try
            {
                conexion.Open();
                string cadena = CdPremios.cargarSolicitudesPremios(idClase);
                MySqlCommand cmd = new MySqlCommand(cadena, conexion);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gvuSolicitudes.DataSource = dt;
                gvuSolicitudes.DataBind();
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
            try
            {
                int idInt = Int32.Parse(id);
                string cadena = CdPremios.eliminarSolicitudPremio(idInt);
                conexion.Open();
                MySqlCommand cmd = new MySqlCommand(cadena, conexion);
                cmd.ExecuteNonQuery();
                conexion.Close();
                int idClase = Int32.Parse(dropClases.SelectedValue.ToString());
                cargarSolicitudesPremios(idClase);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}