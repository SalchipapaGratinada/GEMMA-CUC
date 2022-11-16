using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Gemma.Pages
{
    public partial class Profesor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnprueba_Click(object sender, EventArgs e)
        {
            lblusuario.Text = Session["nombre_usuario"].ToString();
            lblid.Text = Session["userId"].ToString();

        }
    }
}