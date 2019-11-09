using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperSQL
{
    public class Persona
    {
        public int ClientesId { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string domicilio { get; set; }
        public int dni { get; set; }
        public string email { get; set; }
        public string telefono { get; set; }

        public string FullInfo
        {
            get 
            {
                return $"{nombre} {apellido} ({email})";
            }
        
        }

    }
}
