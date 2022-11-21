using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gemma.Cadenas
{
    public class CdPremios
    {
        public static string cargarPremiosPorClase(int idClase)
        {
            string cd = "SELECT * FROM `rewards` INNER JOIN `classes` " +
                "ON `rewards`.`classes_id`=`classes`.`id` AND `rewards`.`classes_id`= "+ idClase + "; ";
            return cd;
        }

        public static string cargarPremiosPorClaseEstudiante(int idClase)
        {
            string cd = "SELECT `rewards`.`id`, `rewards`.`name`, `rewards`.`cost` FROM `rewards` " +
                "INNER JOIN `classes`  ON `rewards`.`classes_id`=`classes`.`id` AND `rewards`.`classes_id`= "+idClase+"; ";
            return cd;
        }

        public static string mostrarPremio(int idPremio)
        {
            string cd = "SELECT id, users_id, cost, name FROM `rewards` WHERE id = "+idPremio+";";
            return cd;
        }

        public static string crearPremio(int idUsu, double costo, string nombre, int idClases)
        {
            string cd = "INSERT INTO `rewards` (`users_id`,`cost`,`name`,`prize_image`,`classes_id`) " +
                "VALUES("+idUsu+", "+costo+", '"+nombre+"', null, "+idClases+"); ";
            return cd;
        }
        public static string actualizarPremio(double costo, string nombre, int idPremio)
        {
            string cd = "UPDATE `rewards` SET `rewards`.`cost`= "+costo+", `rewards`.`name` = '"+nombre+"' " +
                " WHERE `rewards`.`id`= "+idPremio+"; ";
            return cd;
        }
        public static string eliminarPremio( int idPremio)
        {
            string cd = "DELETE FROM `rewards` WHERE `rewards`.`id`= "+idPremio+"; ";
            return cd;
        }

        public static string cargarSolicitudesPremios(int idClase)
        {
            string cd = "SELECT `rewards_exchange`.`id` AS 'REID', `rewards`.`name` AS 'reward_name', " +
                "`rewards_exchange`.`description`, `users`.`user_name`, `users`.`user_lastname` " +
                "FROM `rewards_exchange` " +
                "INNER JOIN `classes` ON `rewards_exchange`.`classes_id`=`classes`.`id` AND `rewards_exchange`.`classes_id` = "+idClase+" " +
                "INNER JOIN `rewards` ON `rewards`.`id`=`rewards_exchange`.`rewards_id` " +
                "INNER JOIN `users` ON `users`.`id`=`rewards_exchange`.`users_id`; ";
            return cd;

        }

        public static string eliminarSolicitudPremio(int id)
        {
            string cd = "DELETE FROM `rewards_exchange` WHERE `rewards_exchange`.`id`= "+id+"; ";
            return cd;
        }



    }
}