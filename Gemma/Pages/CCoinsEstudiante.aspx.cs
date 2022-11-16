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
    public partial class CCoinsEstudiante : System.Web.UI.Page
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
            cargarDropGrupo(idClase);
        }
        public void cargarDropGrupo(int idClase)
        {
            try
            {
                int idUser = Int32.Parse(Session["userId"].ToString());
                string cadena = CdEstudiantes.cargarDropGruposEstudiante(idClase, idUser);
                MySqlCommand cmd = new MySqlCommand(cadena, conexion);
                conexion.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dropGrupo.DataSource = ds;
                dropGrupo.DataTextField = "name";
                dropGrupo.DataValueField = "id";
                dropGrupo.DataBind();
                dropGrupo.Items.Insert(0, new ListItem("Seleccione Grupo", "0"));
                conexion.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void dropGrupo_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idGrupo = Int32.Parse(dropGrupo.SelectedValue.ToString());
            cargarEstudiantes(idGrupo);
        }

        public void cargarEstudiantes(int idGrupo)
        {
            int idProfesor = Int32.Parse(Session["userId"].ToString());
            try
            {
                conexion.Open();
                string cadena = CdGestionGrupos.cargarEstudiantesDeGrupos(idGrupo);
                MySqlCommand cmd = new MySqlCommand(cadena, conexion);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gvuEstudiantes.DataSource = dt;
                gvuEstudiantes.DataBind();
                conexion.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnAñadir_Click(object sender, EventArgs e)
        {

            int idEstudiante;
            Button btnConsultar = (Button)sender;
            GridViewRow seleccionF = (GridViewRow)btnConsultar.NamingContainer;
            idEstudiante = Int32.Parse(seleccionF.Cells[1].Text);
            
            try
            {
                if (tbCantidad.Text.Equals(""))
                {
                    msjDigiteCCcoins();
                }
                else
                {
                    double cantidad = double.Parse(tbCantidad.Text);
                    string cadena = CdCCoins.añadirCCoinsPorestudiante(idEstudiante, cantidad);
                    conexion.Open();
                    MySqlCommand cmd = new MySqlCommand(cadena, conexion);
                    cmd.ExecuteNonQuery();
                    conexion.Close();
                    msjCCoinsAñadidos();
                    tbCantidad.Text = "";
                }
                
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void msjDigiteCCcoins()
        {
            string javaScript = string.Format("agregueCCcoins();");
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "agregueCCcoins", javaScript, true);
        }

        public void msjCCoinsAñadidos()
        {
            string javaScript = string.Format("cCoinsAgregdos();");
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "cCoinsAgregdos", javaScript, true);
        }
    }
}