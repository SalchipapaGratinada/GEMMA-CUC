using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gemma.Cadenas
{
    public class CdGrupos
    {
        public static string cargarGrupos(int userID)
        {
            string cd = "select `groups`.`id`,`groups`.`name` as 'group_name',`groups`.`size`,`classes`.`name` as 'class_name' " +
                "from `groups` inner join `classes` on " +
                "`groups`.`classes_id`=`classes`.`id` and `groups`.`classes_users_id`= "+userID+"; ";
            return cd;
        }

        public static string mostrarGrupo(int idGrupo)
        {
            string cd = "select `groups`.`id`,`groups`.`name` as 'group_name',`groups`.`size`,`classes`.`name` as 'class_name' " +
                "from `groups` inner join `classes` on " +
                "`groups`.`classes_id`=`classes`.`id` and `groups`.`id`= " + idGrupo + "; ";
            return cd;
        }

        public static string cargarDropClases(int userID)
        {
            string cd = "SELECT id, name FROM classes WHERE users_id = " + userID + ";";
            return cd;
        }
        public static string crearGrupo(string nombre, int tamanio, int idClase,int userID)
        {
            string cd = "INSERT INTO `groups` (name, size, classes_id, classes_users_id) VALUES ('"+nombre+"'," +
                " "+tamanio+", "+idClase+", "+userID+");";
            return cd;
        }
        public static string eliminarGrupo(int idGrupo)
        {
            string cd = "DELETE FROM `groups` WHERE id = "+idGrupo+";";
            return cd;
        }
        public static string actualizarGrupo(string nombre, int tamanio, int idClase, int idGrupo)
        {
            string cd = "UPDATE `groups` SET name = '"+nombre+"', size = "+tamanio+", classes_id = "+idClase+" WHERE id = "+idGrupo+";";
            return cd;
        }
    }
}