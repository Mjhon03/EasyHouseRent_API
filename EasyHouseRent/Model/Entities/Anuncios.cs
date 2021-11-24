using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyHouseRent.Model.Entities
{
    public class Anuncios
    {
        int idAnuncion { get; set; }
        int idUsuario { get; set; }
        string titulo { get; set; }
        string descripcion { get; set; }
        int puntuacion { get; set; }
        string direccion { get; set; }
        string estado { get; set; }
        int tipoEstructura { get; set; }
        float valor { get; set; }
        DateTime fecha { get; set; }
        string certificado { get; set; }
        string fotos { get; set; }
    }
}
