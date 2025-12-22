using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca.Modelado
{
    [Table("LIBRO_ETIQUETA")]
    public class Libro_Etiqueta
    {
        [Required]
        public Guid libro_id { get; set; }
        [Required]
        public Guid etiqueta_id { get; set; }

        [ForeignKey("libro_id")]
        public Libro libro { get; set; }

        [ForeignKey("etiqueta_id")]
        public Etiqueta etiqueta { get; set; }
    }
}
