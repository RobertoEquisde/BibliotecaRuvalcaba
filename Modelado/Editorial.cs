using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca.Modelado
{
    [Table("EDITORIAL")]
    public class Editorial
    {
        [Required]
        [Key]
        public Guid editorial_id { get; set; }
        [Required]
        [StringLength(150)]
        public string nombre { get; set; }
        [StringLength(100)]
        public string? pais { get; set; }
        [StringLength(100)]
        public string? ciudad { get; set; }
        [StringLength(255)]
        public string? sitio_web { get; set; }

        [Required]
        public bool activo { get; set; }
        
    }
}
