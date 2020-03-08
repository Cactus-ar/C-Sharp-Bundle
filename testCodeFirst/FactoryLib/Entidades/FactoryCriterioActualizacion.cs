using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LibreriaComun.entidades
{
    [Table("Mail_Criterio_Actualizacion")]
    public class FactoryCriterioActualizacion
    {
        [Key]
        public int Id { get; set; }

        [Required][MaxLength(100)]
        public string Nombre { get; set; }

        [MaxLength(250)]
        public string Descripcion { get; set; }

        [Required]
        public string CriterioActualizacion { get; set; }
        
    }
}
