using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Gemma
{
    public partial class MpEstudiante : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblbienvenida.Text = "Bienvenido " + Session["nombre_usuario"].ToString() + "";
        }
    }
}