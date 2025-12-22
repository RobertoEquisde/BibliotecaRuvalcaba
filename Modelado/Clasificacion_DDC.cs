using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biblioteca.Modelado
{
    [Table("CLASIFICACION_DDC")]
    public class ClasificacionDDC
    {
        [Key]
        public Guid clasificacion_id { get; set; } = Guid.NewGuid();

        [Required]
        [StringLength(15)]
        public string codigo_completo { get; set; }

        [Required]
        [StringLength(200)] 
        public string descripcion { get; set; }

        [Required]
        public Guid categoria_id { get; set; }

        [StringLength(500)]
        public string? notas { get; set; }  

        // === Navegación ===
        [ForeignKey("categoria_id")]
        public virtual CategoriaDDC? Categoria { get; set; }
    }
}