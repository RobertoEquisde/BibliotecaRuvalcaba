using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca.Modelado
{
    [Table("EJEMPLAR")]
    public class Ejemplar
    {
        [Required]
        [Key]
        public Guid ejemplar_id { get; set; }
        [Required]
        public Guid libro_id { get; set; }
        [StringLength(50)]
        public string codigo_barras { get; set; }
        [StringLength(100)]
        public string ubicacion { get; set; }
        [StringLength(50)]
        public string seccion { get; set; }
        [Required]
        [StringLength(20)]
        public string condicion { get; set; }
        [Required]
        [StringLength(20)]
        public string estado { get; set; }
        [StringLength(500)]
        public string notas { get; set; }
        [Required]
        public DateTime fecha_ingreso { get; set; }
        [Required]
        public bool activo { get; set; }
        //===============FK====================
        [ForeignKey("libro_id")]
        public Libro libro { get; set; }
    }
}
