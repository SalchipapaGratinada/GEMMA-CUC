using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gemma.Cadenas
{
    public class CdSolicitudesPremios
    {
        public static string crearSolicitud(int idEstudiante, int idPremio)
        {
            string cd = "INSERT INTO `rewards_exchange` (`rewards_id`,`rewards_users_id`,`users_id`,`description`,`classes_id`) " +
                "SELECT `rewards`.`id` as 'rewards_id', `rewards`.`users_id` AS 'rewards_users_id', "+idEstudiante+" " +
                "as 'users_id', 'Solicitud De Canjeo', `rewards`.`classes_id` FROM `rewards` " +
                "WHERE `rewards`.`id`= "+idPremio+"; ";
            return cd;
        }
    }
}