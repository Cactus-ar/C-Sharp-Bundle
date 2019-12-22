using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPCoreMvcBoilerplate.Models
{
    public class Direccion
    {
        public int Id { get; set; }
        public string Calle { get; set; }
        public int Altura { get; set; }
        public int Depto { get; set; }
        public string Localidad { get; set; }
        public string Provincia { get; set; }


    }
}
