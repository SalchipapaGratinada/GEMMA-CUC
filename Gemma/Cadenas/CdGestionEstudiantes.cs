using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gemma.Cadenas
{
    public class CdGestionEstudiantes
    {
        public static string añadirestudianteAClase(int idUsurario, int idClase, int idProfesor)
        {
            string cd = "insert into `class_students` (`users_id`,`classes_id`,`teacher_id`) " +
                "values("+idUsurario+", "+idClase+", "+idProfesor+"); ";
            return cd;
        }
        public static string eliminarEstudianteDeClase(int idUsurario, int idClase, int idProfesor)
        {
            string cd = "DELETE FROM `class_students` " +
                "WHERE `class_students`.`users_id`= "+idUsurario+" AND `class_students`.`classes_id`= "+idClase+" " +
                "AND `class_students`.`teacher_id`= "+idProfesor+"; ";
            return cd;
        }
        public static string validacion(int idUsurario, int idClase, int idProfesor)
        {
            string cd = "select exists(select * from `class_students` " +
                "where `class_students`.`users_id`= "+idUsurario+" and `class_students`.`classes_id`= "+idClase+" " +
                "and `class_students`.`teacher_id`= "+idProfesor+"); ";
            return cd;
        }

        public static string mostraDatos(int idEstudiante)
        {
            string cd = "select `users`.`id` as 'Id', `users`.`user_name` as 'name'," +
                "`users`.`user_lastname` as 'lastname',`users`.`user_nickname` as 'nickname'," +
                "`users`.`user_profile_image` as 'user_image',`users`.`user_email` as 'email' from `users` " +
                "where `users`.`id`= "+idEstudiante+"; ";
            return cd;
        }

        public static string buscar(string cadena)
        {
            string cd = "select usu.id AS ID, usu.user_name AS Nombre, usu.user_lastname AS Apellido, carr.name AS Carrera " +
                "from users AS usu inner join careers AS carr on carr.id = usu.careers_id WHERE usu.profiles_id = 4 " +
                "and usu.user_name like '%"+cadena+"%'; ";
            return cd;
        }

    }
}