using Biblioteca.DTO;
using Biblioteca.Modelado;
using Biblioteca.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Biblioteca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EditorialController : ControllerBase
    {
        private readonly EditorialService _service;
        public EditorialController(EditorialService service)
        {
            _service = service;
        }

        // GET: api/<EditorialController>
        [HttpGet]
        public ActionResult<List<Editorial>> GetTodos()
        {
            try
            {
                var editoriales = _service.listaDeEditoriales();
                return Ok(editoriales);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }

        // GET api/<EditorialController>/nombre
        [HttpGet("{nombre}")]
        public ActionResult<Editorial> GetPorNombre(string nombre)
        {
            try
            {
                var editorial = _service.buscarPorNombre(nombre);
                return Ok(editorial);
            }
            catch (Exception ex)
            {
                return NotFound(new { mensaje = ex.Message });
            }
        }

        // POST api/<EditorialController>
        [HttpPost]
        public ActionResult<Editorial> Post([FromBody] CrearEditorialDto dto)
        {
            try
            {
                var nuevaEditorial = _service.creandoEditorial(dto);
                return CreatedAtAction(nameof(GetPorNombre), new { nombre = nuevaEditorial.nombre }, nuevaEditorial);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }

        // PUT api/<EditorialController>/{id}
        [HttpPut("{id}")]
        public ActionResult<Editorial> Put(Guid id, [FromBody] ActualizarEditorialDto dto)
        {
            try
            {
                var editorialActualizada = _service.ActualizandoEditorial(id, dto);
                return Ok(editorialActualizada);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }
    }
}
