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
    public partial class GestionEstudiantesGrupos : System.Web.UI.Page
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
            cargarEstudiantes(idClase);
            cargarDropGrupo(idClase);

        }

        public void cargarEstudiantes(int idClase)
        {
            int idProfesor = Int32.Parse(Session["userId"].ToString());
            try
            {
                conexion.Open();
                string cadena = CdGestionGrupos.cargarEstudiantesDeClase(idClase, idProfesor);
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
                dropGrupo.Items.Insert(0, new ListItem("Seleccione Grupo A Añadir", "0"));
                conexion.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void BtnAñadir_Click(object sender, EventArgs e)
        {
            int idGrupo = Int32.Parse(dropGrupo.SelectedValue.ToString());
            int idClase = Int32.Parse(dropClases.SelectedValue.ToString());
            int idEstudiante;
            Button btnConsultar = (Button)sender;
            GridViewRow seleccionF = (GridViewRow)btnConsultar.NamingContainer;
            idEstudiante = Int32.Parse(seleccionF.Cells[1].Text);
            int idProfesor = Int32.Parse(Session["userId"].ToString());
            if (idGrupo != 0)
            {
                try
                {
                    if (validacion(idEstudiante, idClase, idProfesor, idGrupo))
                    {
                        msjEstudianteYaEnGrupo();
                    }
                    else
                    {
                        conexion.Open();
                        string cadena = CdGestionGrupos.añadirAGrupo(idEstudiante,idGrupo,idClase, idProfesor);
                        MySqlCommand cmd = new MySqlCommand(cadena, conexion);
                        cmd.ExecuteNonQuery();
                        conexion.Close();
                        msjEstudianteAñadidoAGrupo();
                    }
                    
                }
                catch (Exception ex)
                {
                    throw ex;
                }
               
            }
            else
            {
                msjDropVacio();
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            int idEstudiante;
            Button btnConsultar = (Button)sender;
            GridViewRow seleccionF = (GridViewRow)btnConsultar.NamingContainer;
            idEstudiante = Int32.Parse(seleccionF.Cells[1].Text);
            try
            {
                int idProfesor = Int32.Parse(Session["userId"].ToString());
                int idClase = Int32.Parse(dropClases.SelectedValue.ToString());
                string cadena = CdGestionEstudiantes.eliminarEstudianteDeClase(idEstudiante, idClase, idProfesor);
                conexion.Open();
                MySqlCommand cmd = new MySqlCommand(cadena, conexion);
                cmd.ExecuteNonQuery();
                conexion.Close();
                cargarEstudiantes(idClase);
                msjEstudianteEliminadoClase();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Boolean validacion(int idEstudiante, int idClase, int idProfeor, int idGrupo)
        {
            try
            {
                conexion.Open();
                string cd = CdGestionGrupos.validacionGrupos(idClase, idGrupo, idProfeor, idEstudiante);
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


        public void msjEstudianteYaEnGrupo()
        {
            string javaScript = string.Format("estudianteYaEstaEnGrupo();");
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "estudianteYaEstaEnGrupo", javaScript, true);
        }

        public void msjEstudianteEliminadoClase()
        {
            string javaScript = string.Format("estudianteEliminadoClase();");
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "estudianteEliminadoClase", javaScript, true);
        }
        public void msjDropVacio()
        {
            string javaScript = string.Format("dropGruposVacios();");
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "dropGruposVacios", javaScript, true);
        }

        public void msjEstudianteAñadidoAGrupo()
        {
            string javaScript = string.Format("estudianteAñadidoAGrupo();");
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "estudianteAñadidoAGrupo", javaScript, true);
        }



    }
}