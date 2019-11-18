using System;
using System.Collections.Generic;
using System.Text;

namespace PeluClienteWpf
{
    public class Cliente
    {
        /*
         * 
         * Esto es lo devuelto por la dto de la api
            "id": 1,
            "nombre": "Roberto",
            "apellido": "Giordano",
            "domicilio": null,
            "localidad": null,
            "telefono": null,
            "celular": null,
            "mail": "rpbert@joho.vit",
            "fechaNacimiento": "0001-01-01T00:00:00"
    */

        public int id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string mail { get; set; }
    }
}
