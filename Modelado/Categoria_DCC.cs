using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biblioteca.Modelado
{
    [Table("CATEGORIA_DDC")]
    public class CategoriaDDC
    {
        [Key]
        public Guid categoria_id { get; set; } = Guid.NewGuid();

        [Required]
        [StringLength(10)]
        public string codigo { get; set; }

        [Required]
        [StringLength(100)]
        public string nombre { get; set; }

        [StringLength(500)]
        public string? descripcion { get; set; }

        public Guid? categoria_padre_id { get; set; } 

        [Required]
        public byte nivel { get; set; }

        [Required]
        public bool activo { get; set; } = true;

        // === Propiedades de navegación ===

        [ForeignKey("categoria_padre_id")]
        public virtual CategoriaDDC? Padre { get; set; }

        public virtual ICollection<CategoriaDDC> Hijos { get; set; } = new List<CategoriaDDC>();
    }
}