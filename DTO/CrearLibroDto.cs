using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Biblioteca.DTO
{
    public class CrearLibroDto
    {
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

        public DateTime? fecha_adquisicion { get; set; }

        [Required]
        public Guid editorial_id { get; set; }

        // Lista de autores con sus roles
        [Required]
        public List<AutorLibroDto> autores { get; set; }
    }

    public class AutorLibroDto
    {
        [Required]
        public Guid autor_id { get; set; }

        [StringLength(30)]
        public string rol { get; set; } = "Autor";

        public byte orden { get; set; } = 1;
    }
}
