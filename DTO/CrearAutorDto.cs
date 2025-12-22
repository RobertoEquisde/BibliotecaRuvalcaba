using System.ComponentModel.DataAnnotations;

namespace Biblioteca.DTO
{
    public class CrearAutorDto
    {
        [Required]
        [StringLength(100)]
        public string nombre { get; set; }

        [StringLength(100)]
        public string apellidos { get; set; }

        [StringLength(50)]
        public string nacionalidad { get; set; }

        public short? anio_nacimiento { get; set; }

        public short? anio_fallecimiento { get; set; }

        [StringLength(1000)]
        public string biografia { get; set; }
    }
}
