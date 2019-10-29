using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityTestTwo
{
       
    public class Tarea
    {
        public enum Prioridad
        {
            Alta, Moderada, Baja
        }

        [Key]
        public int TareaId { get; set; }


        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }
        public bool Terminada { get; set; }

    }
}
