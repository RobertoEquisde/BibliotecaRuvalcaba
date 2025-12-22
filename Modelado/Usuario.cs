using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca.Modelado
{
    [Table("USUARIO")]
    public class Usuario
    {
        [Required]
        [Key]
        public Guid usuario_id { get; set; }
        [Required]
        [StringLength(100)]
        public string nombre { get; set; }
        [StringLength(100)]
        public string apellidos { get; set; }
        [StringLength(150)]
        public string correo { get; set; }
        [StringLength(20)]
        public string telefono { get; set; }
        [StringLength(255)] 
        public string direccion { get; set; }
        [StringLength(30)]
        [Required]
        public string categoria { get; set; }
        [Required]
        public byte limite_Prestamos { get; set; }
        [Required]
        [StringLength(20)]
        public string estado { get; set; }
        public string notas { get; set; }
        [Required]
        public  DateTime fecha_registro { get; set; }
        [Required]
        public bool activo { get; set; }

    }
}
