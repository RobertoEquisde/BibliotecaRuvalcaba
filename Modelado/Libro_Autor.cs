using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Biblioteca.Modelado
{
    [Table("LIBRO_AUTOR")]
    public class Libro_Autor
    {
        [Required]
        public Guid libro_id { get; set; }

        [Required]
        public Guid autor_id { get; set; }

        [Required]
        [StringLength(30)]
        public string rol { get; set; } = "Autor";

        [Required]
        public byte orden { get; set; } = 1;

        [ForeignKey("libro_id")]
        [JsonIgnore]
        public Libro Libro { get; set; }

        [ForeignKey("autor_id")]
        public Autor Autor { get; set; }
    }
}
