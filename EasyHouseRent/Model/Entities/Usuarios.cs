using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyHouseRent.Model.Entities
{
    public class usuarios
    {
        public int idUsuarios { get; set; }
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public int telefono { get; set; }
        public string email { get; set; }
        public string contraseña { get; set; }
        public string estado { get; set; }
        public int idDepartamento { get; set; }
    }
}
