using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gemma.Cadenas
{
    public class CdCCoins
    {
        public static string añadirCCoinsPorClase(int idClase, double cantidad)
        {
            string cd = "UPDATE `wallets` INNER JOIN `class_students` ON " +
                "`class_students`.`classes_id`= "+idClase+" AND `class_students`.`users_id`=`wallets`.`users_id` " +
                "SET `wallets`.`summary`= `wallets`.`summary` +"+cantidad+"; ";
            return cd;
        }
        public static string añadirCCoinsPorGrupo(int idGrupo, double cantidad)
        {
            string cd = "UPDATE `wallets` INNER JOIN `groups_members` " +
                "ON `groups_members`.`groups_id`= "+idGrupo+" AND `groups_members`.`users_id`=`wallets`.`users_id` " +
                "SET `wallets`.`summary`= `wallets`.`summary` +"+cantidad+"; ";
            return cd;
        }

        public static string añadirCCoinsPorestudiante(int idEstudiante, int idClase, double cantidad)
        {
            string cd = "UPDATE `wallets` SET `wallets`.`summary`= `wallets`.`summary` +"+cantidad+" " +
                "WHERE `wallets`.`users_id`= "+idEstudiante+" AND `wallets`.`classes_id`= "+idClase+"; ";
            return cd;
        }

        public static string traerCantidadDeCCoins(int idEstudiante, int idClase)
        {
            string cd = "SELECT id, summary FROM `wallets` WHERE users_id = "+idEstudiante+" AND classes_id = "+idClase+";";
            return cd;
        }
        public static string restarCCoins(int idEstudiante, int idClase, double costo)
        {
            string cd = "UPDATE `wallets` SET summary = summary - "+costo+" " +
                "WHERE `wallets`.`users_id`= "+idEstudiante+"  AND `wallets`.`classes_id`= "+idClase+"; ";
            return cd;
        }



    }
}