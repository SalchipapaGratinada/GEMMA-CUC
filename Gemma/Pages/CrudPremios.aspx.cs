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
    public partial class CrudPremios : System.Web.UI.Page
    {
        readonly MySqlConnection conexion = new MySqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);
        public static string idClase = "";
        public static string idPremio = "";
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
                }
                if (Request.QueryString["idPremio"] != null)
                {
                    idPremio = Request.QueryString["idPremio"].ToString();
                }
                switch (opcion)
                {
                    case "C":
                        this.lbltitulo.Text = "Creando Nuevo Premio";
                        this.BtnCreate.Visible = true;
                        break;
                    case "A":
                        this.lbltitulo.Text = " Actualizacion De Premio";
                        btnActualizar.Visible = true;
                        mostrarDatosPremios();
                        break;
                    case "E":
                        this.lbltitulo.Text = "Eliminando Publicacion";
                        this.BtnDelete.Visible = true;
                        mostrarDatosPremios();
                        bloquearCajas();
                        break;
                    default:
                        break;
                }
            }
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Int32.Parse(idPremio);
                string cadena = CdPremios.eliminarPremio(id);
                conexion.Open();
                MySqlCommand cmd = new MySqlCommand(cadena, conexion);
                cmd.ExecuteNonQuery();
                conexion.Close();
                Response.Redirect("Premios.aspx");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void BtnCreate_Click(object sender, EventArgs e)
        {
            string nombre = tbNombre.Text;
            string costo = tbCosto.Text;
            int idUser = Int32.Parse(Session["userId"].ToString());
            int idClaseI = Int32.Parse(idClase);

            if (validarCampos(nombre) || validarCampos(costo))
            {
                msjCamposVacios();
            }
            else
            {
                    try
                    {
                    double costoD = double.Parse(costo);
                        conexion.Open();
                        string cadena = CdPremios.crearPremio(idUser,costoD, nombre, idClaseI);
                        MySqlCommand cmd = new MySqlCommand(cadena, conexion);
                        cmd.ExecuteNonQuery();
                        conexion.Close();
                        Response.Redirect("Premios.aspx");
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                
            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            string nombre = tbNombre.Text;
            string costo = tbCosto.Text;
            int id = Int32.Parse(idPremio);
            if (validarCampos(nombre) || validarCampos(costo))
            {
                msjCamposVacios();
            }
            else
            {
                try
                {
                    double costoD = double.Parse(costo);
                    conexion.Open();
                    string cadena = CdPremios.actualizarPremio( costoD, nombre, id);
                    MySqlCommand cmd = new MySqlCommand(cadena, conexion);
                    cmd.ExecuteNonQuery();
                    conexion.Close();
                    Response.Redirect("Premios.aspx");
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Premios.aspx");
        }

        void mostrarDatosPremios()
        {
            try
            {
                int id = Int32.Parse(idPremio);
                conexion.Open();
                string cadena = CdPremios.mostrarPremio(id);
                MySqlDataAdapter da = new MySqlDataAdapter(cadena, conexion);
                DataSet ds = new DataSet();
                ds.Clear();
                da.Fill(ds);
                DataTable dt = ds.Tables[0];
                DataRow row = dt.Rows[0];
                tbCosto.Text = row[2].ToString();
                tbNombre.Text = row[3].ToString();
                conexion.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void bloquearCajas()
        {
            tbCosto.Enabled = false;
            tbNombre.Enabled = false;
        }

        public Boolean validarCampos(String dato)
        {
            if (dato.Equals(""))
            {
                return true;
            }
            return false;
        }

        public void msjCamposVacios()
        {
            string javaScript = string.Format("camposVacios();");
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "camposVacios", javaScript, true);
        }
    }
}