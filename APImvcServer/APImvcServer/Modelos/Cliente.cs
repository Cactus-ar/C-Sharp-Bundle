using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace APImvcServer.Modelos
{
    //Si el nombre de la tabla difiere del nombre de la clase, hay que hacercelo saber
    //la tabla se llama dbo.Salon_Clientes
    [Table("Salon_Clientes", Schema = "dbo")]

    public class Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Máximo 50 caracteres")]
        public string Nombre { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Máximo 50 caracteres")]
        public string Apellido { get; set; }


        public string Domicilio { get; set; }
        public string Localidad { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public string Mail { get; set; }
        public DateTime FechaNacimiento { get; set; }

    }
}
