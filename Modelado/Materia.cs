using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca.Modelado
{
    [Table("MATERIA")]
    public class Materia
    {
        [Required]
        [Key]
        
        public Guid materia_id { get; set; }
        [Required]
        [StringLength(100)]
        public string nombre { get; set; }
        [StringLength(500)]
        public string descripcion { get; set; }
        public bool activo { get; set; }
    }
}
