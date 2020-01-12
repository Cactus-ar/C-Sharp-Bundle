using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LamLinqDb.Modelo
{

    public enum Genero
    {
        Masculino = 0,
        Femenino = 1
    }

    [Table("Cliente")]
    public class Cliente
    {
        [Key]
        public int Id { get; set; }


        public int Dni { get; set; }
        public string Nombre { get; set; }
        public string Domicilio { get; set; }
        public string Localidad { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public Genero genero { get; set; }


    }
}
