using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyHouseRent.Model.Entities
{
    public class Anuncios
    {
       public int idAnuncion { get; set; }
       public int idUsuario { get; set; }
       public string titulo { get; set; }
       public string descripcion { get; set; }
       public int puntuacion { get; set; }
       public string direccion { get; set; }
       public string estado { get; set; }
       public int tipoEstructura { get; set; }
       public float valor { get; set; }
       public DateTime fecha { get; set; }
       public string certificado { get; set; }
       public string fotos { get; set; }
    }
}
