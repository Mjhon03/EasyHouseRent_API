using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyHouseRent.Model.Entities
{
    public class Usuarios
    {
        int idUsuarios { get; set; }
        string nombre { get; set; }
        string apellidos { get; set; }
        DateTime fechaNacimiento { get; set; }
        int telefono { get; set; }
        string email { get; set; }
        string contraseña { get; set; }
        string estado { get; set; }
        int idDepartamento { get; set; }
    }
}
