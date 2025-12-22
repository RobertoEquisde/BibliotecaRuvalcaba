using Biblioteca.DTO;
using Biblioteca.Modelado;
using Biblioteca.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Biblioteca.Controllers
{
    /// <summary>
    /// API para gestión de libros en la biblioteca
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class LibroController : ControllerBase
    {
        private readonly LibroService _libroService;

        public LibroController(LibroService libroService)
        {
            _libroService = libroService;
        }

        /// <summary>
        /// Obtiene todos los libros activos de la biblioteca
        /// </summary>
        /// <returns>Lista de libros</returns>
        /// <response code="200">Retorna la lista de libros</response>
        /// <response code="400">Si ocurre un error en la solicitud</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<List<LibroResponseDto>> GetTodos()
        {
            try
            {
                var libros = _libroService.ObtenerTodosDto();
                return Ok(libros);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }

        /// <summary>
        /// Obtiene un libro específico por su ID
        /// </summary>
        /// <param name="id">ID único del libro (GUID)</param>
        /// <returns>El libro solicitado</returns>
        /// <response code="200">Retorna el libro encontrado</response>
        /// <response code="404">Si el libro no existe</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<LibroResponseDto> GetPorId(Guid id)
        {
            try
            {
                var libro = _libroService.ObtenerPorIdDto(id);
                return Ok(libro);
            }
            catch (Exception ex)
            {
                return NotFound(new { mensaje = ex.Message });
            }
        }

        /// <summary>
        /// Busca libros por título (búsqueda parcial)
        /// </summary>
        /// <param name="titulo">Texto a buscar en el título del libro</param>
        /// <returns>Lista de libros que coinciden con el título</returns>
        /// <response code="200">Retorna la lista de libros encontrados</response>
        /// <response code="400">Si el título está vacío o no se encuentran resultados</response>
        [HttpGet("buscar/{titulo}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<List<Modelado.Libro>> BuscarPorTitulo(string titulo)
        {
            try
            {
                var libros = _libroService.BuscandoPorTitulo(titulo);
                return Ok(libros);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }

        /// <summary>
        /// Obtiene un libro por su código ISBN
        /// </summary>
        /// <param name="isbn">Código ISBN del libro (13 dígitos)</param>
        /// <returns>El libro con el ISBN especificado</returns>
        /// <response code="200">Retorna el libro encontrado</response>
        /// <response code="404">Si no existe un libro con ese ISBN</response>
        [HttpGet("isbn/{isbn}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Modelado.Libro> GetPorIsbn(string isbn)
        {
            try
            {
                var libro = _libroService.ObtenerPorIsbn(isbn);
                return Ok(libro);
            }
            catch (Exception ex)
            {
                return NotFound(new { mensaje = ex.Message });
            }
        }

        /// <summary>
        /// Crea un nuevo libro en la biblioteca
        /// </summary>
        /// <param name="dto">Datos del libro a crear</param>
        /// <returns>El libro recién creado</returns>
        /// <remarks>
        /// Ejemplo de solicitud:
        ///
        ///     POST /api/Libro
        ///     {
        ///        "titulo": "Don Quijote de la Mancha",
        ///        "subtitulo": "El ingenioso hidalgo",
        ///        "isbn": "9788420412146",
        ///        "editorial_id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        ///        "autores": [
        ///           {
        ///              "autor_id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        ///              "rol": "Autor",
        ///              "orden": 1
        ///           }
        ///        ],
        ///        "anio_publicacion": 1605,
        ///        "paginas": 863,
        ///        "idioma": "es",
        ///        "formato": "Tapa dura",
        ///        "valoracion": 5,
        ///        "estado_lectura": "Leído"
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Retorna el libro creado</response>
        /// <response code="400">Si los datos del libro son inválidos</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Modelado.Libro> Crear([FromBody] CrearLibroDto dto)
        {
            try
            {
                var nuevoLibro = _libroService.CrearNuevoLibro(dto);
                return CreatedAtAction(nameof(GetPorId), new { id = nuevoLibro.libro_id }, nuevoLibro);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }

        /// <summary>
        /// Actualiza un libro existente
        /// </summary>
        /// <param name="id">ID del libro a actualizar</param>
        /// <param name="libro">Datos actualizados del libro</param>
        /// <returns>Sin contenido</returns>
        /// <response code="204">Si la actualización fue exitosa</response>
        /// <response code="400">Si los datos son inválidos o el libro no existe</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Actualizar(Guid id, [FromBody] Modelado.Libro libro)
        {
            try
            {
                libro.libro_id = id;
                _libroService.Actualizar(libro);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }

        /// <summary>
        /// Elimina un libro (eliminación lógica)
        /// </summary>
        /// <param name="isbn">ISBN del libro a eliminar</param>
        /// <returns>Sin contenido</returns>
        /// <remarks>
        /// Nota: Esta operación realiza una eliminación lógica.
        /// El libro se marca como inactivo pero no se elimina de la base de datos.
        /// </remarks>
        /// <response code="204">Si la eliminación fue exitosa</response>
        /// <response code="400">Si el ISBN está vacío o el libro no existe</response>
        [HttpDelete("isbn/{isbn}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Eliminar(string isbn)
        {
            try
            {
                _libroService.Eliminar(isbn);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }
    }
}
