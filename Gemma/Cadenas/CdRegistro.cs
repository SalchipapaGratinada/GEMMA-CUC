using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gemma.Cadenas
{
    public class CdRegistro
    {

        public static string registrarUsuario(string  nombre, string apellido, string nick, string passw, string email, int carrera )
        {
            string cd = "INSERT INTO users (user_name, user_lastname, user_nickname, user_password, user_email, user_profile_image, profiles_id, careers_id)" +
                " VALUES('"+nombre+"', '"+apellido+"', '"+nick+"', '"+passw+"', '"+email+"', null, 4, "+carrera+"); ";
            return cd;
        }

        public static string traerPerfil(string nick, string password)
        {
            string cd = "SELECT profiles_id FROM users WHERE user_nickname = '"+nick+"' AND user_password = '"+password+"';";
            return cd;
        }
        public static string traerNombreAnndId(string nick, string password)
        {
            string cd = "SELECT id, user_nickname FROM users WHERE user_nickname = '" + nick + "' AND user_password = '" + password + "';";
            return cd;
        }
        public static string cargarDropCarreras()
        {
            string cd = "SELECT * FROM `careers`; ";
            return cd;
        }

    }
}