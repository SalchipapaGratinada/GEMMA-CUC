using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gemma.Cadenas
{
    public class CdGrupoEstudiantes
    {
        public static string eliminarDelGrupo(int idClase, int idGrupo, int idProfesor, int idEstudiante)
        {
            string cd = "DELETE FROM `groups_members` where `groups_members`.`groups_classes_id`= 6 " +
                "and `groups_members`.`groups_id`= 4 " +
                "and `groups_members`.`teacher_id`= 28 " +
                "and `groups_members`.`users_id`= 20; ";
            return cd;
        }
    }
}