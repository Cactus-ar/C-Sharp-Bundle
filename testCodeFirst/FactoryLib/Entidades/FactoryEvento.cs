using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LibreriaComun.entidades
{
    [Table("MAIL_Evento")]
    public class FactoryEvento
    {
        [Key]
        public int Id { get; set; }

        [Required][MaxLength(100)]
        public string Nombre { get; set; }

        [MaxLength(250)]
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }

        [Required]
        public int Prioridad { get; set; }

        public FactoryPlantilla Plantilla { get; set; }
        public FactoryCriterioBusqueda CriterioBusca { get; set; }

        public ICollection<FactoryCriterioActualizacion> CriteriosParaActualizar { get; set; } = new List<FactoryCriterioActualizacion>();


    }
}
