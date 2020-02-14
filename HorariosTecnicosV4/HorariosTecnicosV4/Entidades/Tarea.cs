using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HorariosTecnicosV4.Entidades
{
    public class Tarea
    {
        [Key]
        public int Id { get; set; } //por default EF sabe que una propiedad llamada ID puede ser una clave foranea pero con las anotaciones podemos forzarlo

        [Required]
        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        [Required]
        public DateTime Inico { get; set; }

        [Required]
        public DateTime Fin { get; set; }

        [ForeignKey("TrabajadorId")]
        public Trabajador Trabajador { get; set; }
        public int TrabajadorID { get; set; }

    }
}
