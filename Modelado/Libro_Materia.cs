using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca.Modelado
{
    [Table("LIBRO_MATERIA")]
    public class Libro_Materia
    {
        [Required]
        public Guid libro_id { get; set; }
        [Required]
        public Guid materia_id { get; set; }

        [ForeignKey("libro_id")]
        public Libro libro { get; set; }

        [ForeignKey("materia_id")]
        public Materia materia { get; set; }
    }
}
