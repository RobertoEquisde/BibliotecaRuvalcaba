using Biblioteca.DTO;
using Biblioteca.Modelado;
using Biblioteca.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca.Service
{
    public class EditorialService
    {
        private readonly IEditorialRepository _editorialRepository;
        public EditorialService(IEditorialRepository editorialRepository)
        {
            _editorialRepository = editorialRepository;
        }

        public Editorial creandoEditorial(CrearEditorialDto dto)
        {
            if(string.IsNullOrEmpty(dto.nombre))
            {
                throw new Exception("es necesario el nombre");
            }

            var editorial = new Editorial
            {
                nombre = dto.nombre,
                pais = dto.pais,
                ciudad = dto.ciudad,
                sitio_web = dto.sitio_web
            };

            return _editorialRepository.crearNuevaEditorial(editorial);
        }

        public Editorial buscarPorNombre(string nombre)
        {
            var editorial = _editorialRepository.buscarEditorialPorNombre(nombre);
            if(editorial == null)
            {
                throw new Exception("no existe la editorial");
            }
            return editorial;
        }

        public List<Editorial> listaDeEditoriales()
        {
            return _editorialRepository.todasLasEditoriales();
        }

        public Editorial ActualizandoEditorial(Guid id, ActualizarEditorialDto dto)
        {
            // Buscar la editorial existente usando el ID de la URL
            var editorialExistente = _editorialRepository.buscarEditorialPorId(id);

            if (editorialExistente == null)
            {
                throw new Exception("Editorial no encontrada");
            }

            // Actualizar solo los campos que vienen con valores
            if (!string.IsNullOrWhiteSpace(dto.nombre))
            {
                editorialExistente.nombre = dto.nombre;
            }

            if (!string.IsNullOrWhiteSpace(dto.pais))
            {
                editorialExistente.pais = dto.pais;
            }

            if (!string.IsNullOrWhiteSpace(dto.ciudad))
            {
                editorialExistente.ciudad = dto.ciudad;
            }

            if (!string.IsNullOrWhiteSpace(dto.sitio_web))
            {
                editorialExistente.sitio_web = dto.sitio_web;
            }

            return _editorialRepository.ActualizarEditorial(editorialExistente);
        }
    }
}
