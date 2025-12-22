using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca.Modelado
{
    [Table("Reserva")]
    public class Reserva
    {
        [Required]
        [Key]
        public Guid reserva_id { get; set; }
        [Required]
        public Guid libro_id { get; set; }
        [Required]
        public Guid usuario_id { get; set; }
        [Required]
        public DateTime fecha_reserva { get; set; }
        public DateTime fecha_limite { get; set; }
        [Required]
        [StringLength(20)]
        public string estado { get; set; }
        public byte posicion_cola { get; set; }
        public DateTime fecha_notificacion { get; set; }
        public string notas { get; set; }

        [ForeignKey("reserva_id")]
        public Libro libro { get; set; }
        [ForeignKey("usuario_id")]
        public Usuario usuario { get; set; }
    }
}
