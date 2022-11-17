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
    public partial class CCoinsClases : System.Web.UI.Page
    {
        readonly MySqlConnection conexion = new MySqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarDropClases();
                btnAgregar.Enabled = false;
            }
        }

        protected void dropClases_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = Int32.Parse(dropClases.SelectedValue.ToString());
            if (index != 0)
            {
                btnAgregar.Enabled = true;
            }
            else
            {
                btnAgregar.Enabled = false;
            }
        }

        protected void tbCantidadCCoins_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(tbCantidadCCoins.Text))
            {
                btnAgregar.Enabled = false;
            }
            else
            {
                btnAgregar.Enabled = true;
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            string cantidadCCoins = (tbCantidadCCoins.Text);
            if (cantidadCCoins.Equals(""))
            {
                msjCajaCCoinsVacia();
            }
            else
            {
                double cantidad = double.Parse(cantidadCCoins);
                int idClase = Int32.Parse(dropClases.SelectedValue.ToString());
                try
                {
                    if (idClase != 0)
                    {
                        string cadena = CdCCoins.añadirCCoinsPorClase(idClase, cantidad);
                        MySqlCommand cmd = new MySqlCommand(cadena, conexion);
                        conexion.Open();
                        cmd.ExecuteNonQuery();
                        conexion.Close();
                        msjCCoinsAgregados();
                        reinicarTodo();
                    }
                    else
                    {
                        msjDropClasesVacio();
                    }
                }
                catch (Exception ex)
                {

                    throw ex;
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
                dropClases.DataSource = ds;
                dropClases.DataTextField = "name";
                dropClases.DataValueField = "id";
                dropClases.DataBind();
                dropClases.Items.Insert(0, new ListItem("Seleccione Clase", "0"));
                conexion.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void reinicarTodo()
        {
            btnAgregar.Enabled = false;
            dropClases.SelectedIndex = 0;
            tbCantidadCCoins.Text = "";
        }

        public void msjDropClasesVacio()
        {
            string javaScript = string.Format("dropClasesVacio();");
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "dropClasesVacio", javaScript, true);
        }
        public void msjCajaCCoinsVacia()
        {
            string javaScript = string.Format("agregueCCcoins();");
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "agregueCCcoins", javaScript, true);
        }
        public void msjCCoinsAgregados()
        {
            string javaScript = string.Format("cCoinsAgregdos();");
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "cCoinsAgregdos", javaScript, true);
        }
    }
}