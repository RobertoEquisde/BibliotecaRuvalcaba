using Biblioteca.DTO;
using Biblioteca.Modelado;
using Biblioteca.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca.Service
{
    public class AutorService
    {
        private readonly IAutorRepository _autorRepository;
        public AutorService(IAutorRepository autorRepository)
        {
            _autorRepository=autorRepository;
        }

        public Autor crearNuevoAutor(CrearAutorDto dto)
        {
            if(string.IsNullOrWhiteSpace(dto.nombre))
            {
                throw new ArgumentException("Nombre obligatorio");
            }

            var autor = new Autor
            {
                nombre = dto.nombre,
                apellidos = dto.apellidos,
                nacionalidad = dto.nacionalidad,
                anio_nacimiento = dto.anio_nacimiento,
                anio_fallecimiento = dto.anio_fallecimiento,
                biografia = dto.biografia
            };

            autor.nombre_completo = string.IsNullOrWhiteSpace(autor.apellidos)
                ? autor.nombre
                : $"{autor.nombre} {autor.apellidos}";

            autor.nombre_ordenacion = string.IsNullOrWhiteSpace(autor.apellidos)
                ? autor.nombre
                : $"{autor.apellidos}, {autor.nombre}";

            return _autorRepository.creandoAutor(autor);
        }
        public Autor buscandoPorNombre(string nombre)
        {
            var autor = _autorRepository.buscandoAutorPorNombre(nombre);
            if(autor == null)
            {
                throw new Exception("Autor no encontrado");
            }
            return autor;
        }
        public List<Autor> obteniendoTodosLosAutores()
        {
            return  _autorRepository.obteniendoTodosLosAutores();
        }
        public Autor ActualizandoAutor(Guid id, ActualizarAutorDto dto)
        {
            // Buscar el autor existente usando el ID de la URL
            var autorExistente = _autorRepository.buscandoAutorPorId(id);

            if (autorExistente == null)
            {
                throw new Exception("Autor no encontrado");
            }

            // Actualizar solo los campos que vienen con valores
            if (!string.IsNullOrWhiteSpace(dto.nombre))
            {
                autorExistente.nombre = dto.nombre;
            }

            if (!string.IsNullOrWhiteSpace(dto.apellidos))
            {
                autorExistente.apellidos = dto.apellidos;
            }

            if (!string.IsNullOrWhiteSpace(dto.nacionalidad))
            {
                autorExistente.nacionalidad = dto.nacionalidad;
            }

            if (dto.anio_nacimiento.HasValue)
            {
                autorExistente.anio_nacimiento = dto.anio_nacimiento;
            }

            if (dto.anio_fallecimiento.HasValue)
            {
                autorExistente.anio_fallecimiento = dto.anio_fallecimiento;
            }

            if (!string.IsNullOrWhiteSpace(dto.biografia))
            {
                autorExistente.biografia = dto.biografia;
            }

            // Reconstruir nombre_completo y nombre_ordenacion
            autorExistente.nombre_completo = string.IsNullOrWhiteSpace(autorExistente.apellidos)
                ? autorExistente.nombre
                : $"{autorExistente.nombre} {autorExistente.apellidos}";

            autorExistente.nombre_ordenacion = string.IsNullOrWhiteSpace(autorExistente.apellidos)
                ? autorExistente.nombre
                : $"{autorExistente.apellidos}, {autorExistente.nombre}";

            return _autorRepository.actualizandoAutor(autorExistente);
        }
    }
}
