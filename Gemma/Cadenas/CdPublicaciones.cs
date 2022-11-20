using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gemma.Cadenas
{
    public class CdPublicaciones
    {

        public static string crearPublicacion(string titulo, string descripcion, int tipoPost, int idUsuario, int idClase)
        {
            string cd = "INSERT INTO posts (title, description, post_types_id, users_id, classes_id)" +
                " VALUES ('"+titulo+"', '"+descripcion+"', "+tipoPost+","+idUsuario+", "+idClase+");";
            return cd;
        }

        public static string cargarPublicacionesPorClase(int idClase)
        {
            string cd = "select po.id, po.title, po.description, tipo.name as Tipo from posts as po " +
                "inner join post_types AS tipo " +
                "on tipo.id = po.post_types_id where po.classes_id = "+idClase+";";
            return cd;
        }

        public static string cargarPublicacionesPorId(int idPublicacion)
        {
            string cd = "select po.id, po.title, po.description, tipo.name as Tipo from posts as po " +
                "inner join post_types AS tipo " +
                "on tipo.id = po.post_types_id where po.id = " + idPublicacion + ";";
            return cd;
        }

        public static string cargarDropTipoPost()
        {
            string cd = "SELECT * FROM post_types;";
            return cd;
        }

        public static string eliminarPublicacion(int idPublicacion)
        {
            string cd = "DELETE FROM `posts` WHERE `posts`.`id` = "+idPublicacion+";";
            return cd;
        }





    }
}