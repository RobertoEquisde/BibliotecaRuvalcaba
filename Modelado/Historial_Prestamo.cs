using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca.Modelado
{
    [Table("HISTORIAL_PRESTAMO")]
    public class Historial_Prestamo
    {
        [Required]
        [Key]
        public Guid historial_id { get; set; }
        [Required]
        public Guid prestamo_id { get; set; }
        [Required]
        [StringLength(50)]
        public string accion { get; set; }
        [Required]
        public DateTime fecha_accion { get; set; }
        public string detalle { get; set; }

        [ForeignKey("prestamo_id")]
        public Prestamo prestamo { get; set; }

    }
}
