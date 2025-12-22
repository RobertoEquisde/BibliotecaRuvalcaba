using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Biblioteca.Modelado;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca.Modelado
{
    [Table("PRESTAMO")]
    public class Prestamo
    {
        [Required]
        [Key]
        public Guid prestamo_id { get; set; }
        [Required]
        public Guid ejemplar_id { get; set; }
        [Required]
        public Guid usuario_id { get; set; }
        [Required]
        public DateTime fecha_prestamo { get; set; }
        [Required]
        public DateTime fecha_vencimiento { get; set; }

        public DateTime fecha_devolucion { get; set; }
        [Required]
        public byte renovaciones { get; set; }
        [Required]
        [StringLength(20)]
        public string estado { get; set; }
        public string notas { get; set; }
        [Required]
        public DateTime fecha_registro { get; set; }

        [ForeignKey("ejemplar_id")]
        public Ejemplar ejemplar { get; set; }
        [ForeignKey("usuario_id")]
        public Usuario usuario { get; set; }


    }
}
