using System.ComponentModel.DataAnnotations;

namespace Biblioteca.DTO
{
    public class CrearEditorialDto
    {
        [Required]
        [StringLength(150)]
        public string nombre { get; set; }

        [StringLength(100)]
        public string pais { get; set; }

        [StringLength(100)]
        public string ciudad { get; set; }

        [StringLength(255)]
        public string sitio_web { get; set; }
    }
}
