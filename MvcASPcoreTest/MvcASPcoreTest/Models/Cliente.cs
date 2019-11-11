using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MvcASPcoreTest.Models
{
    public class Cliente
    {
        [Key]
        public int ClientesID { get; set; }

        public string nombre { get; set; }
        public string apellido { get; set; }
        public string domicilio { get; set; }
        public string dni { get; set; }
        public string email { get; set; }
        public string telefono { get; set; }
    }
}
