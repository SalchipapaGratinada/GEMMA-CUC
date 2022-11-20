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


        //consultas que cargan datos del estudiante en la session dele studiante

        public static string cargarClasesEstudiante(int idEstudiante)
        {
            string cd = "SELECT `classes`.`id`, `classes`.`name`, `classes`.`code`, (SELECT `users`.`user_name` FROM " +
                "`users` WHERE `users`.`id` = `class_students`.`teacher_id`) AS 'teacher_name', (SELECT `users`.`user_lastname` " +
                "FROM `users` WHERE " +
                "`users`.`id` = `class_students`.`teacher_id`) AS ' teacher_lastname' " +
                "FROM `class_students` INNER JOIN `users` ON `users`.`id` = `class_students`.`users_id` " +
                "AND `users`.`id` = "+idEstudiante+" INNER JOIN `classes` ON `class_students`.`classes_id` = `classes`.`id`; ";
            return cd;
        }
        public static string cargarGruposEstudiante(int idEstudiante)
        {
            string cd = "SELECT groups_id, `groups`.name, size, classes.name AS 'class_name' " +
                "FROM groups_members INNER JOIN `groups` ON `groups`.id = groups_members.groups_id " +
                "INNER JOIN classes ON groups_members.groups_classes_id = classes.id AND groups_members.users_id = "+idEstudiante+"; ";
            return cd;
        }

        public static string cargarCCoinsPorClase(int idEstudiante)
        {
            string cd = "SELECT `users`.`user_name`,`wallets`.`summary` AS `CCoins`,`groups`.`name` AS Grupo, " +
                "`classes`.`name` AS Clase FROM `wallets` " +
                "INNER JOIN `users` ON `users`.`id`=`wallets`.`users_id` AND `users`.`id`= "+idEstudiante+" " +
                "INNER JOIN `groups` ON `groups`.`classes_id`=`wallets`.`classes_id` " +
                "INNER JOIN `classes` ON `classes`.`id`=`wallets`.`classes_id`; ";
            return cd;
        }


    }
}