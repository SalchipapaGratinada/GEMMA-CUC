using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Gemma.Pages
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            tbnombre.Text = "";
            tbApellido.Text = "";
            tbPassword.Text = "";
            tbConfirmacionPassword.Text = "";
            tbEmail.Text = "";
            tbnombre.Focus();
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            string nombre = tbnombre.Text;
            string apellido = tbApellido.Text;
            string nikcName = tbNickName.Text;
            string pass = tbPassword.Text;
            string confirPass = tbConfirmacionPassword.Text;
            string email = tbEmail.Text;
            if (validarCamposVacios(nombre) && validarCamposVacios(nikcName) && validarCamposVacios(apellido) && validarCamposVacios(confirPass) && validarCamposVacios(pass) && validarCamposVacios(email))
            {
                if (passwordIguales(pass, confirPass))
                {
                    
                }
            }
            else
            {
                msjCamposVacios();
            }
        }


        protected Boolean validarCamposVacios(string entrada)
        {
            if (entrada.Equals(""))
            {
                return false;
            }
            return true;
        }

        protected Boolean passwordIguales(string pass, string confirmacionPass)
        {
            if (pass.Equals(confirmacionPass))
            {
                return true;
            }
            return false;
        }


        public void msjCamposVacios ()
        {
            //string javaScript = "alertacamposVacios();";
            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertacamposVacios", javaScript, true);
            string javaScript = string.Format("alertacamposVacios();");
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alertacamposVacios", javaScript, true);
        }


    }
}