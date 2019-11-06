using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EF_Mysql_8x.Modelos
{
    [Table("employees.employees") ]
    public class Empleado
    {
        public enum genero {M, F};

        [Key]
        public int emp_no { get; set; }
        public DateTime birth_date { get; set; }

        [StringLength(14)]
        public string first_name { get; set; }
        [StringLength(16)]
        public string last_name { get; set; }
        public genero gender { get; set; }
        public DateTime hire_date { get; set; }



    }
}
