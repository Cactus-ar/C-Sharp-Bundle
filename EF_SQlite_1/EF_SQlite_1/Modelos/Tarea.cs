using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EF_SQlite_1.Modelos
{
    public class Tarea
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TareaId { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Maximo 50 caracteres para el Titulo")]
        public string Titulo { get; set; }

        [Required]
        [StringLength(200, MinimumLength = 10, ErrorMessage = "Minimo 10..Maximo 200 caracteres")]
        public string Descripcion { get; set; }


        public bool Finalizada { get; set; }


        
    }
}
