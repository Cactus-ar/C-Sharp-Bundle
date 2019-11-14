using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APImvcServer.Dtos
{
    public class DtoCliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Domicilio { get; set; }
        public string Localidad { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public string Mail { get; set; }
        public DateTime FechaNacimiento { get; set; }
    }
}
