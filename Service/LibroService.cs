using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.DTO;
using Biblioteca.Modelado;
using Biblioteca.Repository;
using Microsoft.EntityFrameworkCore.Storage;

namespace Biblioteca.Service
{
    public class LibroService
    {
        private readonly ILibroRepository _libroRepository;
        public LibroService(ILibroRepository libroRepository)
        {
            _libroRepository = libroRepository;
        }

        public Libro CrearNuevoLibro(CrearLibroDto dto)
        {
            if(string.IsNullOrWhiteSpace(dto.titulo))
            {
                throw new ArgumentException("titulo obligatorio");
            }

            if(dto.valoracion.HasValue && (dto.valoracion > 5 || dto.valoracion < 0))
            {
                throw new ArgumentException("La valoracion no puede ser mayor a 5 o menor a 0");
            }

            if(!string.IsNullOrEmpty(dto.isbn))
            {
                 var libroExistente = _libroRepository.ObtenerPorIsbn(dto.isbn);
                 if(libroExistente != null)
                 {
                    throw new InvalidOperationException($"Ya existe el libro con el isbn {dto.isbn}");
                 }
            }

            if(dto.editorial_id == Guid.Empty)
            {
                throw new ArgumentException("Debe seleccionar una editorial");
            }

            if(dto.autores == null || dto.autores.Count == 0)
            {
                throw new ArgumentException("Debe incluir al menos un autor");
            }

            var libro = new Libro
            {
                isbn = dto.isbn,
                titulo = dto.titulo,
                subtitulo = dto.subtitulo,
                anio_publicacion = dto.anio_publicacion,
                anio_original = dto.anio_original,
                paginas = dto.paginas,
                idioma = dto.idioma,
                formato = dto.formato,
                sinopsis = dto.sinopsis,
                portada_url = dto.portada_url,
                notas_personales = dto.notas_personales,
                valoracion = dto.valoracion,
                estado_lectura = dto.estado_lectura,
                fecha_adquisicion = dto.fecha_adquisicion ?? DateTime.Now,
                editorial_id = dto.editorial_id,
                LibroAutores = new List<Libro_Autor>()
            };

            // Agregar autores
            foreach(var autorDto in dto.autores)
            {
                libro.LibroAutores.Add(new Libro_Autor
                {
                    autor_id = autorDto.autor_id,
                    rol = autorDto.rol,
                    orden = autorDto.orden
                });
            }

            return _libroRepository.CrearLibro(libro);
        }

        public Libro ObtenerPorId(Guid id)
        {
            var libro = _libroRepository.ObtenerPorID(id);
            if(libro == null)
            {
                throw new Exception($"Libro con ID{id} no encontrado");
            }
            return libro;
        }

        public List<Libro> ObtenerTodos()
        {
            return _libroRepository.ObtenerTodos();
        }

        public List<LibroResponseDto> ObtenerTodosDto()
        {
            var libros = _libroRepository.ObtenerTodos();
            return libros.Select(l => ConvertirADto(l)).ToList();
        }

        public LibroResponseDto ObtenerPorIdDto(Guid id)
        {
            var libro = ObtenerPorId(id);
            return ConvertirADto(libro);
        }

        private LibroResponseDto ConvertirADto(Libro libro)
        {
            return new LibroResponseDto
            {
                libro_id = libro.libro_id,
                isbn = libro.isbn,
                titulo = libro.titulo,
                subtitulo = libro.subtitulo,
                anio_publicacion = libro.anio_publicacion,
                anio_original = libro.anio_original,
                paginas = libro.paginas,
                idioma = libro.idioma,
                formato = libro.formato,
                sinopsis = libro.sinopsis,
                portada_url = libro.portada_url,
                notas_personales = libro.notas_personales,
                valoracion = libro.valoracion,
                estado_lectura = libro.estado_lectura,
                fecha_adquisicion = libro.fecha_adquisicion,
                fecha_registro = libro.fecha_registro,
                activo = libro.activo,
                editorial = new EditorialSimpleDto
                {
                    editorial_id = libro.Editorial.editorial_id,
                    nombre = libro.Editorial.nombre,
                    pais = libro.Editorial.pais,
                    ciudad = libro.Editorial.ciudad
                },
                autores = libro.LibroAutores.Select(la => new AutorLibroResponseDto
                {
                    autor_id = la.Autor.autor_id,
                    nombre_completo = la.Autor.nombre_completo,
                    rol = la.rol,
                    orden = la.orden
                }).OrderBy(a => a.orden).ToList()
            };
        }

        public List<Libro> BuscandoPorTitulo(string titulo)
        {
            if(string.IsNullOrWhiteSpace(titulo))
            {
                throw new Exception($"no se aceptan vacios");
            }

            var libros = _libroRepository.BuscandoPorTitulo(titulo);
            if(libros == null || libros.Count == 0)
            {
                throw new ArgumentException($"No se encontraron libros con el titulo {titulo}");
            }
            return libros;
        }

        public Libro ObtenerPorIsbn(string isbn)
        {
            if(string.IsNullOrWhiteSpace(isbn))
            {
                throw new Exception("no se aceptan vacios");
            }
            var libro = _libroRepository.ObtenerPorIsbn(isbn);
            if(libro == null)
            {
                throw new Exception(" no se encontro libro");
            }
            return libro;
        }

        public void Actualizar(Libro libro)
        {
            if(string.IsNullOrWhiteSpace(libro.titulo))
            {
                throw new ArgumentException("El título es obligatorio");
            }

            if(libro.valoracion > 5 || libro.valoracion < 0)
            {
                throw new ArgumentException("La valoración debe estar entre 0 y 5");
            }
            var libroExistente = _libroRepository.ObtenerPorID(libro.libro_id);
            if(libroExistente == null)
            {
                throw new Exception("El libro no existe");
            }

            _libroRepository.Actualizar(libro);
        }

        public void Eliminar(string isbn)
        {
            if(string.IsNullOrWhiteSpace(isbn))
            {
                throw new ArgumentException("no se aceptan vacios");
            }
            var libroExistente = ObtenerPorIsbn(isbn);

            _libroRepository.Eliminar(libroExistente);
        }
    }
}
