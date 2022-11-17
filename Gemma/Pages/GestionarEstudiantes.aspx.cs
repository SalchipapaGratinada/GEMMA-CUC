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
    public partial class GestionarEstudiantes : System.Web.UI.Page
    {

        readonly MySqlConnection conexion = new MySqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarEstudiantes();
                cargarDropClases();
            }
           
        }

        public void cargarEstudiantes()
        {
            try
            {
                conexion.Open();
                string cadena = CdEstudiantes.cargarEstudiantes();
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
                dropClases.Items.Insert(0, new ListItem("Seleccione Clase A Añadir", "0"));
                conexion.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
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
                //dropGrupo.DataSource = ds;
                //dropGrupo.DataTextField = "name";
                //dropGrupo.DataValueField = "id";
                //dropGrupo.DataBind();
                //dropGrupo.Items.Insert(0, new ListItem("Seleccione Grupo A Añadir", "0"));
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

        protected void BtnRead_Click(object sender, EventArgs e)
        {
            string id;
            Button btnConsultar = (Button)sender;
            GridViewRow seleccionF = (GridViewRow)btnConsultar.NamingContainer;
            id = seleccionF.Cells[1].Text;
            Response.Redirect("~/Pages/CrudGesEstudiantes.aspx?id=" + id);
        }

        protected void BtnAñadir_Click(object sender, EventArgs e)
        {
            int idClase = Int32.Parse(dropClases.SelectedValue.ToString());
            int idProfesor = Int32.Parse(Session["userId"].ToString());
            int idEstudiante;
            Button btnConsultar = (Button)sender;
            GridViewRow seleccionF = (GridViewRow)btnConsultar.NamingContainer;
            idEstudiante = Int32.Parse(seleccionF.Cells[1].Text);
            try
            {
                if (idClase == 0)
                {
                    msjDropVacio();
                }
                else
                {
                    if (validacion(idEstudiante, idClase, idProfesor))
                    {
                        msjEstudianteYaEnClase();
                    }
                    else
                    {
                        conexion.Open();
                        string cadena = CdGestionEstudiantes.añadirestudianteAClase(idEstudiante, idClase, idProfesor);
                        MySqlCommand cmd = new MySqlCommand(cadena, conexion);
                        cmd.ExecuteNonQuery();
                        conexion.Close();
                        msjEstudianteAñadido();
                    }
                }
                
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Boolean validacion(int idEstudiante, int idClase, int idProfeor)
        {
            try
            {
                conexion.Open();
                string cd = CdGestionEstudiantes.validacion(idEstudiante, idClase, idProfeor);
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
                    return true;
                }
                conexion.Close();
                return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public void msjEstudianteAñadido()
        {
            string javaScript = string.Format("estudianteAñadidoAClase();");
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "estudianteAñadidoAClase", javaScript, true);
        }
        public void msjDropVacio()
        {
            string javaScript = string.Format("dropClasesVacio();");
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "dropClasesVacio", javaScript, true);
        }
        public void msjEstudianteYaEnClase()
        {
            string javaScript = string.Format("estudianteYaEnClase();");
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "estudianteYaEnClase", javaScript, true);
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                conexion.Open();
                string cadena = CdGestionEstudiantes.buscar(tbBuscar.Text);
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
    }
}