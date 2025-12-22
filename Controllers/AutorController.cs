using Biblioteca.DTO;
using Biblioteca.Modelado;
using Biblioteca.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Biblioteca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private readonly AutorService _service;
        public AutorController (AutorService service)
        {
            _service = service;
        }
        // GET: api/<ValuesController>
        [HttpGet]
        public ActionResult<List<Autor>>  GetTodos()
        {
            try
            {
                var libros = _service.obteniendoTodosLosAutores();
                return Ok(libros);
            }
            catch(Exception ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }

        // GET api/<AutorController>/nombre
        [HttpGet("{nombre}")]
        public ActionResult<Autor> GetPorNombre(string nombre)
        {
            try
            {
                var autor = _service.buscandoPorNombre(nombre);
                return Ok(autor);
            }
            catch (Exception ex)
            {
                return NotFound(new { mensaje = ex.Message });
            }
        }

        // POST api/<AutorController>
        [HttpPost]
        public ActionResult<Autor> Post([FromBody] CrearAutorDto dto)
        {
            try
            {
                var nuevoAutor = _service.crearNuevoAutor(dto);
                return CreatedAtAction(nameof(GetPorNombre), new { nombre = nuevoAutor.nombre }, nuevoAutor);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }

        // PUT api/<AutorController>/{id}
        [HttpPut("{id}")]
        public ActionResult<Autor> Put(Guid id, [FromBody] ActualizarAutorDto dto)
        {
            try
            {
                var autorActualizado = _service.ActualizandoAutor(id, dto);
                return Ok(autorActualizado);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }
    }
}
