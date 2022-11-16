using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Gemma
{
    public partial class MpProfesor : System.Web.UI.MasterPage
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            lblBienvenida.Text = "Bienvenido "+ Session["nombre_usuario"].ToString()+"";
        }
    }
}