using System;
using System.Collections.Generic;

namespace Biblioteca.DTO
{
    public class LibroResponseDto
    {
        public Guid libro_id { get; set; }
        public string isbn { get; set; }
        public string titulo { get; set; }
        public string subtitulo { get; set; }
        public short? anio_publicacion { get; set; }
        public short? anio_original { get; set; }
        public short? paginas { get; set; }
        public string idioma { get; set; }
        public string formato { get; set; }
        public string sinopsis { get; set; }
        public string portada_url { get; set; }
        public string notas_personales { get; set; }
        public byte? valoracion { get; set; }
        public string estado_lectura { get; set; }
        public DateTime fecha_adquisicion { get; set; }
        public DateTime fecha_registro { get; set; }
        public bool activo { get; set; }

        // Editorial simplificada
        public EditorialSimpleDto editorial { get; set; }

        // Autores aplanados
        public List<AutorLibroResponseDto> autores { get; set; }
    }

    public class EditorialSimpleDto
    {
        public Guid editorial_id { get; set; }
        public string nombre { get; set; }
        public string pais { get; set; }
        public string ciudad { get; set; }
    }

    public class AutorLibroResponseDto
    {
        public Guid autor_id { get; set; }
        public string nombre_completo { get; set; }
        public string rol { get; set; }
        public byte orden { get; set; }
    }
}
