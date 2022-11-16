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
    public partial class CrudClases : System.Web.UI.Page
    {
        readonly MySqlConnection conexion = new MySqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);
        public static string opcion = "";
        public static string idClase = "";
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (Request.QueryString["op"] != null)
                {
                    opcion = Request.QueryString["op"].ToString();
                }
                if (Request.QueryString["id"] != null)
                {
                    idClase = Request.QueryString["id"].ToString();
                    mostrarDatos();
                }
                switch (opcion)
                {
                    case "C":
                        this.lbltitulo.Text = "Creando Nueva Clase";
                        this.BtnCreate.Visible = true;
                        break;
                    case "L":
                        this.lbltitulo.Text = " Datos Clase";
                        bloquearCajas();
                        break;
                    case "A":
                        this.lbltitulo.Text = "Actualizando  Clase";
                        this.BtnUpdate.Visible = true;
                        break;
                    case "E":
                        this.lbltitulo.Text = "Eliminando Clase";
                        this.BtnDelete.Visible = true;
                        bloquearCajas();
                        break;
                    default:
                        break;
                }
            }
            
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("GestionarClase.aspx");
        }

        protected void BtnCreate_Click(object sender, EventArgs e)
        {
            string nombre = tbNombreClase.Text;
            int idUser = Int32.Parse(Session["userId"].ToString());
            if (validarCampos(nombre) || validarCampos(tbCodigo.Text))
            {
                msjCamposVacios();
            }
            else
            {
                int code = Int32.Parse(tbCodigo.Text);
                try
                {
                    conexion.Open();
                    string cadena = CdClases.crearClase(nombre, code, idUser);
                    MySqlCommand cmd = new MySqlCommand(cadena, conexion);
                    cmd.ExecuteNonQuery();
                    conexion.Close();
                    Response.Redirect("GestionarClase.aspx");
                }
                catch (Exception ex)
                {
                    throw ex;
                }
              
            }

        }


        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            string nombre = tbNombreClase.Text;
            string codigo = tbCodigo.Text;
            int id = Int32.Parse(idClase);
            if (validarCampos(nombre) || validarCampos(codigo))
            {
                msjCamposVacios();
            }
            else
            {
                try
                {
                    string cadena = CdClases.actualizarClase(nombre, Int32.Parse(codigo), id);
                    MySqlCommand cmd = new MySqlCommand(cadena, conexion);
                    conexion.Open();
                    cmd.ExecuteNonQuery();
                    conexion.Close();
                    Response.Redirect("GestionarClase.aspx");
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Int32.Parse(idClase);
                string cadena = CdClases.eliminarClase(id);
                conexion.Open();
                MySqlCommand cmd = new MySqlCommand(cadena, conexion);
                cmd.ExecuteNonQuery();
                conexion.Close();
                Response.Redirect("GestionarClase.aspx");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        void mostrarDatos()
        {
            try
            {
                int id = Int32.Parse(idClase);
                conexion.Open();
                string cadena = CdClases.mostrarClase(id);
                MySqlDataAdapter da = new MySqlDataAdapter(cadena, conexion);
                DataSet ds = new DataSet();
                ds.Clear();
                da.Fill(ds);
                DataTable dt = ds.Tables[0];
                DataRow row = dt.Rows[0];
                tbNombreClase.Text = row[1].ToString();
                tbCodigo.Text = row[2].ToString();
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
        public Boolean validarCampos(String dato)
        {
            if (dato.Equals(""))
            {
                return true;
            }
            return false;
        }

        public void bloquearCajas()
        {
            tbNombreClase.Enabled = false;
            tbCodigo.Enabled = false;
        }

    }
}