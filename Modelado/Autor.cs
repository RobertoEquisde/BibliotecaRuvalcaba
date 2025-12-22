using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca.Modelado
{
    [Table("AUTOR")]
    public class Autor
    {
        [Required]
        [Key]
        public Guid autor_id { get; set; }
        [Required]
        [StringLength(100)]
        public string nombre { get; set; }
        [StringLength(100)]
        public string apellidos { get; set; }
        [Required]
        [StringLength(200)]
        public string nombre_completo { get; set; }
        [Required]
        [StringLength(200)]
        public string nombre_ordenacion { get; set; }
        [StringLength(50)]
        public string nacionalidad { get; set; }
        public short? anio_nacimiento { get; set; }
        public short? anio_fallecimiento { get; set; }
        [StringLength(1000)]
        public string biografia { get; set; }
        [Required]
        public bool activo { get; set; }


    }
}
