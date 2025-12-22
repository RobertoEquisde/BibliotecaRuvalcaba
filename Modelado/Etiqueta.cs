using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca.Modelado
{
    [Table("ETIQUETA")]
    public class Etiqueta
    {
        [Required]
        [Key]
        public Guid etiqueta_id { get; set; }
        [Required]
        [StringLength(50)]
        public string nombre { get; set; }
        [StringLength(10)]
        public string color { get; set; }
        public bool activo { get; set; }
    }
}
