using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gemma.Cadenas
{
    public class CdEstudiantes
    {

        public static string cargarEstudiantes()
        {
            string cd = "select usu.id AS ID, usu.user_name AS Nombre, usu.user_lastname AS Apellido, carr.name AS Carrera " +
                "from users AS usu inner join careers AS carr on carr.id = usu.careers_id WHERE usu.profiles_id = 4; ";
            return cd;
        }

        public static string cargarDropClasesEstudiante(int userID)
        {
            string cd = "SELECT id, name FROM classes WHERE users_id = " + userID + ";";
            return cd;
        }
        public static string cargarDropGruposEstudiante(int idClase, int userID)
        {
            string cd = "SELECT id, name FROM `groups` WHERE classes_id = "+idClase+" AND classes_users_id = "+userID+";";
            return cd;
        }

        
    }
}