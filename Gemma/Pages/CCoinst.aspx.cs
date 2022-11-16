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
    public partial class CCoinst : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            
        }

        

      

        protected void tbCantidadCCoins_TextChanged(object sender, EventArgs e)
        {
            
        }

        protected void dropClasesG_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        protected void btnCoinsClases_Click(object sender, EventArgs e)
        {
            Response.Redirect("CCoinsClases.aspx");
        }

        protected void btnCoinsGrupal_Click(object sender, EventArgs e)
        {
            Response.Redirect("CCoinsGrupos.aspx");
        }

        protected void btnCoinsIndividual_Click(object sender, EventArgs e)
        {
            Response.Redirect("CCoinsEstudiante.aspx");
        }
    }
}