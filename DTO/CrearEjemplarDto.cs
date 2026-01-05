using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca.DTO
{
    public class CrearEjemplarDto
    {
        [Required(ErrorMessage = "El ID del libro es obligatorio")]
        public Guid LibroId { get; set; }

        [StringLength(50, ErrorMessage = "El código de barras no puede exceder 50 caracteres")]
        public string? CodigoBarras { get; set; }

        [StringLength(100, ErrorMessage = "La ubicación no puede exceder 100 caracteres")]
        public string? Ubicacion { get; set; }

        [StringLength(50, ErrorMessage = "La sección no puede exceder 50 caracteres")]
        public string? Seccion { get; set; }

        [Required(ErrorMessage = "La condición es obligatoria")]
        [RegularExpression("^(Excelente|Bueno|Regular|Malo)$",
            ErrorMessage = "La condición debe ser: Excelente, Bueno, Regular o Malo")]
        public string Condicion { get; set; } = "Bueno";

        [Required(ErrorMessage = "El estado es obligatorio")]
        [RegularExpression("^(Disponible|Prestado|Reservado|Reparación|Extraviado)$",
            ErrorMessage = "El estado debe ser: Disponible, Prestado, Reservado, Reparación o Extraviado")]
        public string Estado { get; set; } = "Disponible";

        [StringLength(500, ErrorMessage = "Las notas no pueden exceder 500 caracteres")]
        public string? Notas { get; set; }


    }
}
