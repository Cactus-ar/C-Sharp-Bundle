using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EF_SQlite_1.Modelos
{
    public class Jornada
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int JornadaId { get; set; }
        public string Observaciones { get; set; }
        public DateTime Fecha { get; set; }

        
    }
}
