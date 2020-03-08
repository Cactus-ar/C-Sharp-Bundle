using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LibreriaComun.entidades
{
    [Table("MAIL_Criterio_Busqueda")]
    public class FactoryCriterioBusqueda
    {
        [Key]
        public int Id { get; set; }

        [Required][MaxLength(100)]
        public string Nombre { get; set; }

        [MaxLength(250)]
        public string Descripcion { get; set; }

        [Required]
        public string CriterioBusqueda { get; set; }

        [Required][MaxLength(400)]
        public string Reemplazos { get; set; }

        [Required]
        public int Sucursales { get; set; }

        [ForeignKey("EventoId")]
        public FactoryEvento Evento { get; set; }
        public int EventoId { get; set; }
        

    }
}
