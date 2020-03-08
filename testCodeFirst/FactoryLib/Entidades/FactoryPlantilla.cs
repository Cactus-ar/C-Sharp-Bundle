using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LibreriaComun.entidades
{
    [Table("MAIL_Plantilla")]
    public class FactoryPlantilla
    {
        [Key]
        public int Id { get; set; }

        [Required][MaxLength(100)]
        public string Nombre { get; set; }

        [MaxLength(250)]
        public string Descripcion { get; set; }

        [Required]
        public string Plantilla { get; set; }

        [Required][MaxLength(400)]
        public string Reemplazos { get; set; }

        [Required][MaxLength(200)]
        public string Mail_De { get; set; }

        [Required][MaxLength(250)]
        public string Asunto { get; set; }

        [MaxLength(200)]
        public string Mail_cco { get; set; }
        
        [ForeignKey("EventoId")]
        public FactoryEvento Evento { get; set; }
        public int EventoId { get; set; }

    }
}
