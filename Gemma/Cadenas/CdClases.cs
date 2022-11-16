using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gemma.Cadenas
{
    public class CdClases
    {

        public static string crearClase(string nombre, int code, int idUSer)
        {
            string cd = "INSERT INTO `classes` (`name`,`code`,`users_id`)VALUES('"+nombre+"', "+code+", "+idUSer+"); ";
            return cd;
        }
        public static string actualizarClase(string nombre, int code, int id)
        {
            string cd = "UPDATE classes SET name = '"+nombre+"', code = "+code+" WHERE id = "+id+"; ";
            return cd;
        }
        public static string eliminarClase(int id)
        {
            string cd = "DELETE FROM classes WHERE id="+id+"; ";
            return cd;
        }
        public static string cargarClases(int userID)
        {
            string cd = "SELECT * FROM classes WHERE users_id = "+userID+";";
            return cd;
        }
        public static string mostrarClase(int id)
        {   
            string cd = "SELECT * FROM classes WHERE id = " + id + ";";
            return cd;
        }

    }
}