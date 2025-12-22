using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca.Modelado
{
    [Table("LIBRO")]
    public class Libro
    {
        [Required]
        [Key]
        public Guid libro_id { get; set; }
        [StringLength(13)]
        public string isbn { get; set; }
        [Required]
        [StringLength(255)]
        public string titulo { get; set; }
        [StringLength(255)]
        public string subtitulo { get; set; }
        public short? anio_publicacion { get; set; }
        public short? anio_original { get; set; }
        public short? paginas { get; set; }
        [Required]
        [StringLength(10)]
        public string idioma { get; set; }
        [StringLength(20)]
        public string formato { get; set; }
        [StringLength(2000)]
        public string sinopsis { get; set; }
        [StringLength(255)]
        public string portada_url { get; set; }
        public string notas_personales { get; set; }
        public byte? valoracion { get; set; }
        [StringLength(20)]
        public string estado_lectura { get; set; }
        public DateTime fecha_adquisicion { get; set; }

        public DateTime fecha_registro { get; set; }
        public bool activo { get; set; }
        //=========== FK======================
        public Guid editorial_id { get; set; }
        [ForeignKey("editorial_id")]
        public Editorial Editorial { get; set; }

        // Navigation properties para relaciones muchos-a-muchos
        public ICollection<Libro_Autor> LibroAutores { get; set; }

    }
}
