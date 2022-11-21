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
    public partial class EstCanjeoCCoins : System.Web.UI.Page
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
                string cadena = CdEstudiantes.cargarDropClasesConIdEstudiante(idUser);
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
            cargarPremios(idClase);
        }
        public void cargarPremios(int idClase)
        {
            try
            {
                conexion.Open();
                string cadena = CdPremios.cargarPremiosPorClaseEstudiante(idClase);
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

        protected void btnCanjear_Click(object sender, EventArgs e)
        {
            double costo;
            int idPremio;
            Button btnConsultar = (Button)sender;
            GridViewRow seleccionF = (GridViewRow)btnConsultar.NamingContainer;
            idPremio = Int32.Parse(seleccionF.Cells[1].Text);
            costo = double.Parse(seleccionF.Cells[3].Text);
            double cCoinsDisponibles = traerCCOinsDisponibles();
            int idEstudiante = Int32.Parse(Session["userId"].ToString());
            int idClase = Int32.Parse(dropClases.SelectedValue.ToString());
            if (cCoinsDisponibles < costo)
            {
                msjCCoinsInsuficientes();
            }
            else
            {
                restarCCoins(idEstudiante, idClase, costo);
                try
                {
                    conexion.Open();
                    string cadena = CdSolicitudesPremios.crearSolicitud(idEstudiante, idPremio);
                    MySqlCommand cmd = new MySqlCommand(cadena, conexion);
                    cmd.ExecuteNonQuery();
                    conexion.Close();
                    msjCanjeoExitoso();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public void restarCCoins(int idEstudiante, int idClase, double costo)
        {
            try
            {
                conexion.Open();
                string cadena = CdCCoins.restarCCoins(idEstudiante, idClase, costo);
                MySqlCommand cmd = new MySqlCommand(cadena, conexion);
                cmd.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void msjCCoinsInsuficientes()
        {
            string javaScript = string.Format("CCoinsInsuficientes();");
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "CCoinsInsuficientes", javaScript, true);
        }
        public void msjCanjeoExitoso()
        {
            string javaScript = string.Format("canjeoExitoso();");
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "canjeoExitoso", javaScript, true);
        }
        public double traerCCOinsDisponibles()
        {
            double cantidad;
            try
            {
                int idClase = Int32.Parse(dropClases.SelectedValue.ToString());
                int idEstudiante = Int32.Parse(Session["userId"].ToString());
                conexion.Open();
                string cadena = CdCCoins.traerCantidadDeCCoins(idEstudiante,idClase);
                MySqlDataAdapter da = new MySqlDataAdapter(cadena, conexion);
                DataSet ds = new DataSet();
                ds.Clear();
                da.Fill(ds);
                DataTable dt = ds.Tables[0];
                DataRow row = dt.Rows[0];
                cantidad = double.Parse(row[1].ToString());
                conexion.Close();
                return cantidad;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}