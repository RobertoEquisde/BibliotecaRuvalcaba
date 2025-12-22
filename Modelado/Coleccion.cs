using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca.Modelado
{
    [Table("COLECCION")]
    public class Coleccion
    {
        [Required]
        [Key]
        public Guid coleccion_id { get; set; }
        [Required]
        [StringLength(100)]
        public string nombre { get; set; }
        [StringLength(500)]
        public string descripcion { get; set; }
        [Required]
        public bool activo { get; set; }
    }
}
