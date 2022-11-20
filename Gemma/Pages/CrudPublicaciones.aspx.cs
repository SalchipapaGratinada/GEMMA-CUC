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
    public partial class CrudPublicaciones : System.Web.UI.Page
    {
        readonly MySqlConnection conexion = new MySqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);
        public static string idClase = "";
        public static string idPublicacion = "";
        public static string opcion = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["op"] != null)
                {
                    opcion = Request.QueryString["op"].ToString();
                }
                if (Request.QueryString["idClase"] != null)
                {
                    idClase = Request.QueryString["idClase"].ToString();
                    cargarDropTipoPost();
                }
                if (Request.QueryString["idPublicacion"] != null)
                {
                    idPublicacion = Request.QueryString["idPublicacion"].ToString();
                }
                switch (opcion)
                {
                    case "C":
                        this.lbltitulo.Text = "Creando Nueva Publicacion";
                        this.BtnCreate.Visible = true;
                        break;
                    case "L":
                        this.lbltitulo.Text = " Datos Publicacion";
                        mostrarDatosPublicacion();
                        bloquearCajas();
                        break;
                    case "E":
                        this.lbltitulo.Text = "Eliminando Publicacion";
                        this.BtnDelete.Visible = true;
                        mostrarDatosPublicacion();
                        bloquearCajas();
                        break;
                    default:
                        break;
                }
            }
        }

        protected void BtnCreate_Click(object sender, EventArgs e)
        {
            string titulo = tbTitulo.Text;
            string descripcion = tbDescripcion.Text;
            int idUser = Int32.Parse(Session["userId"].ToString());
            if (validarCampos(titulo) || validarCampos(descripcion))
            {
                msjCamposVacios();
            }
            else
            {
                int idTipoPost = Int32.Parse(dropTiposPost.SelectedValue.ToString());
                if (idTipoPost != 0)
                {
                    try
                    {
                        int idclase = Int32.Parse(idClase);
                        conexion.Open();
                        string cadena = CdPublicaciones.crearPublicacion(titulo, descripcion, idTipoPost, idUser, idclase);
                        MySqlCommand cmd = new MySqlCommand(cadena, conexion);
                        cmd.ExecuteNonQuery();
                        conexion.Close();
                        Response.Redirect("Publicaciones.aspx");
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
                else
                {
                    msjDropSinSelecionarClase();
                }
            }
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Publicaciones.aspx");
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Int32.Parse(idPublicacion);
                string cadena = CdPublicaciones.eliminarPublicacion(id);
                conexion.Open();
                MySqlCommand cmd = new MySqlCommand(cadena, conexion);
                cmd.ExecuteNonQuery();
                conexion.Close();
                Response.Redirect("Publicaciones.aspx");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        void mostrarDatosPublicacion()
        {
            try
            {
                int id = Int32.Parse(idPublicacion);
                conexion.Open();
                string cadena = CdPublicaciones.cargarPublicacionesPorId(id);
                MySqlDataAdapter da = new MySqlDataAdapter(cadena, conexion);
                DataSet ds = new DataSet();
                ds.Clear();
                da.Fill(ds);
                DataTable dt = ds.Tables[0];
                DataRow row = dt.Rows[0];
                tbTitulo.Text = row[1].ToString();
                tbDescripcion.Text = row[2].ToString();
                conexion.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void msjCamposVacios()
        {
            string javaScript = string.Format("camposVacios();");
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "camposVacios", javaScript, true);
        }

        public void bloquearCajas()
        {
            tbTitulo.Enabled = false;
            tbDescripcion.Enabled = false;
        }
        public void cargarDropTipoPost()
        {
            try
            {
                string cadena = CdPublicaciones.cargarDropTipoPost();
                MySqlCommand cmd = new MySqlCommand(cadena, conexion);
                conexion.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dropTiposPost.DataSource = ds;
                dropTiposPost.DataTextField = "name";
                dropTiposPost.DataValueField = "id";
                dropTiposPost.DataBind();
                dropTiposPost.Items.Insert(0, new ListItem("Seleccione Tipo Post", "0"));
                conexion.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Boolean validarCampos(String dato)
        {
            if (dato.Equals(""))
            {
                return true;
            }
            return false;
        }

        public void msjDropSinSelecionarClase()
        {
            string javaScript = string.Format("dropClasesVacio();");
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "dropClasesVacio", javaScript, true);
        }
    }
}