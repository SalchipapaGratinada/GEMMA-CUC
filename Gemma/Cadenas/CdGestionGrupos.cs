using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gemma.Cadenas
{
    public class CdGestionGrupos
    {

        public static string cargarEstudiantesDeClase(int idClase, int idProfesor)
        {
            string cd = " SELECT `users`.`id`,`users`.`user_name` AS 'name',`users`.`user_lastname` AS 'lastname'," +
                "`careers`.`name` AS 'career_name',`classes`.`name` AS 'class_name' FROM `class_students`" +
                "INNER JOIN `users` " +
                "INNER JOIN `careers` " +
                "INNER JOIN `classes` ON `class_students`.`users_id`=`users`.`id`" +
                " AND `class_students`.`classes_id`= "+idClase+" AND `class_students`.`teacher_id`= "+idProfesor+" GROUP BY `users`.`id`;";
            return cd;
        }
        public static string añadirAGrupo(int idEstudiante, int idGrupo, int idClase, int idProfesor)
        {
            string cd = "INSERT INTO `groups_members` (`users_id`,`groups_id`,`groups_classes_id`,`teacher_id`) " +
                "VALUES("+idEstudiante+", "+idGrupo+", "+idClase+", "+idProfesor+"); ";
            return cd;
        }


        public static string cargarEstudiantesDeGrupos(int idGrupo)
        {
            string cd = "SELECT `users`.`id` AS 'uid',`groups`.`id` AS 'gid',`users`.`user_name` AS 'name'," +
                "`users`.`user_lastname` AS 'lastname',`groups`.`name` AS 'group_name',`groups`.`size` AS 'group_size' " +
                "FROM `groups_members` INNER JOIN `groups` INNER JOIN `users` " +
                "ON `groups_members`.`groups_classes_id`=`groups`.`classes_id` " +
                "AND `groups_members`.`groups_id`= "+idGrupo+" AND `groups_members`.`users_id`=`users`.`id` GROUP BY `users`.`id`; ";
            return cd;
        }
        public static string validacionGrupos(int idClase, int idGrupo, int idProfesor, int idEstudiante)
        {
            string cd = "select exists (select * from `groups_members` where `groups_members`.`groups_classes_id`= "+idClase+" " +
                "and `groups_members`.`groups_id`= "+idGrupo+" " +
                "and `groups_members`.`teacher_id`= "+idProfesor+" " +
                "and `groups_members`.`users_id`= "+idEstudiante+") as 'exists'; ";
            return cd;
        }

    }
}