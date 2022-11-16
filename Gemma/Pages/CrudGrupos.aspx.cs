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
    public partial class CrudGrupos : System.Web.UI.Page
    {
        readonly MySqlConnection conexion = new MySqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);
        public static string opcion = "";
        public static string idGrupo = "-1";
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                cargarDropClases();
                if (Request.QueryString["id"] != null)
                {
                    idGrupo = Request.QueryString["id"].ToString();
                    mostrarDatos();
                }
                
                if (Request.QueryString["op"]!= null)
                {
                    opcion = Request.QueryString["op"].ToString();
                    switch (opcion)
                    {
                        case "C":
                            this.lbltitulo.Text = "Crear Grupo";
                            this.BtnCreate.Visible = true;
                            break;
                        case "L":
                            this.lbltitulo.Text = "Informacion Grupo";
                            bloquearCajas();
                            drupClases.Enabled = false;
                            break;
                        case "E":
                            this.lbltitulo.Text = "Eliminar Grupo";
                            this.BtnDelete.Visible = true;
                            bloquearCajas();
                            drupClases.Enabled = false;
                            break;
                        case "A":
                            this.lbltitulo.Text = "Actualizar Grupo";
                            this.BtnUpdate.Visible = true;
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("GestionarGrupos.aspx");
        }


        protected void BtnCreate_Click(object sender, EventArgs e)
        {
            string nombreGrupo = tbNombreGrupo.Text;
            string tamanio = tbTamaño.Text;
            int idClase = Int32.Parse(drupClases.SelectedValue.ToString());
            int idUSer = Int32.Parse(Session["userId"].ToString());
            if (validarCampos(nombreGrupo) || validarCampos(tamanio))
            {
                msjCamposVacios();
            }
            else
            {
                if (idClase != 0)
                {
                    try
                    {
                        int tamanioInt = Int32.Parse(tamanio);
                        string cadena = CdGrupos.crearGrupo(nombreGrupo,tamanioInt, idClase, idUSer );
                        MySqlCommand cmd = new MySqlCommand(cadena, conexion);
                        conexion.Open();
                        cmd.ExecuteNonQuery();
                        conexion.Close();
                        Response.Redirect("GestionarGrupos.aspx");
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
                else
                {
                    msjDropClasesVacio();
                }
            }
        }

        public void cargarDropClases()
        {
            try
            {
                int idUser = Int32.Parse(Session["userId"].ToString());
                string cadena = CdGrupos.cargarDropClases(idUser);
                MySqlCommand cmd = new MySqlCommand(cadena, conexion);
                conexion.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                drupClases.DataSource = ds;
                drupClases.DataTextField = "name";
                drupClases.DataValueField = "id";
                drupClases.DataBind();
                drupClases.Items.Insert(0, new ListItem("Seleccione Clase", "0"));
                conexion.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void mostrarDatos()
        {
            try
            {
                int id = Int32.Parse(idGrupo);
                conexion.Open();
                string cadena = CdGrupos.mostrarGrupo(id);
                MySqlDataAdapter da = new MySqlDataAdapter(cadena, conexion);
                DataSet ds = new DataSet();
                ds.Clear();
                da.Fill(ds);
                DataTable dt = ds.Tables[0];
                DataRow row = dt.Rows[0];
                tbNombreGrupo.Text = row[1].ToString();
                tbTamaño.Text = row[2].ToString();
                string clase = row[3].ToString();
                foreach (ListItem item in drupClases.Items)
                {
                    if (item.Text == clase)
                    {
                        item.Selected = true;
                        break;
                    }
                }
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
        public void msjDropClasesVacio()
        {
            string javaScript = string.Format("dropClasesVacio();");
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "dropClasesVacio", javaScript, true);
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
            tbNombreGrupo.Enabled = false;
            tbTamaño.Enabled = false;
        }

        public void pruebas(string dato)
        {
            string script = string.Format("alert('AQuiCON String:{0}');", dato);
            ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);
        }
        public void pruebas(ListItem dato)
        {
            string script = string.Format("alert('AQui:{0}');", dato);
            ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            string nombre = tbNombreGrupo.Text;
            string tamanio = tbTamaño.Text;
            int idClase = Int32.Parse(drupClases.SelectedValue.ToString());
            int id = Int32.Parse(idGrupo);
            if (validarCampos(nombre) || validarCampos(tamanio))
            {
                msjCamposVacios();
            }
            else
            {
                if (idClase != 0)
                {
                    try
                    {
                        int tamanioInt = Int32.Parse(tamanio);
                        string cadena = CdGrupos.actualizarGrupo(nombre, tamanioInt, idClase, id);
                        MySqlCommand cmd = new MySqlCommand(cadena, conexion);
                        conexion.Open();
                        cmd.ExecuteNonQuery();
                        conexion.Close();
                        Response.Redirect("GestionarGrupos.aspx");
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
                else
                {
                    msjDropClasesVacio();
                }
            }
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Int32.Parse(idGrupo);
                string cadena = CdGrupos.eliminarGrupo(id);
                conexion.Open();
                MySqlCommand cmd = new MySqlCommand(cadena, conexion);
                cmd.ExecuteNonQuery();
                conexion.Close();
                Response.Redirect("GestionarGrupos.aspx");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}