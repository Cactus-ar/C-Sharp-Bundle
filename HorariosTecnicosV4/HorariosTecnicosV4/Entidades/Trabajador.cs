using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HorariosTecnicosV4.Entidades
{
    public class Trabajador
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; }

        
        public string Email { get; set; }
        public string Domicilio { get; set; }
        public DateTime Ingreso { get; set; }

        [ForeignKey("EspecialidadID")]
        public Especialidad Especialidad { get; set; }
        public int EspecialidadID { get; set; }

        public ICollection<Especialidad> Especialidades { get; set; } = new List<Especialidad>();
        public ICollection<Tarea> Tareas { get; set; } = new List<Tarea>();

    }
}
