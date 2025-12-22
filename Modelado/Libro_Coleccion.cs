using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biblioteca.Modelado
{
    [Table("LIBRO_COLECCION")]
    public class Libro_Coleccion
    {
        // Clave primaria compuesta
        [Key]
        [Column(Order = 0)]
        public Guid libro_id { get; set; }

        [Key]
        [Column(Order = 1)]
        public Guid coleccion_id { get; set; }

        // Propiedades de navegación
        [ForeignKey("libro_id")]
        public Libro Libro { get; set; }

        [ForeignKey("coleccion_id")]
        public Coleccion Coleccion { get; set; }

        // Campo adicional
        public byte? numero_en_serie { get; set; }
    }
}
