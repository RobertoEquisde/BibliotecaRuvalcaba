using Biblioteca.DTO;
using Biblioteca.Modelado;
using Biblioteca.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca.Service
{
    public class EjemplarService
    {
        private readonly IEjemplarRepository _ejemplarRepository;
        private readonly ILibroRepository _libroRepository;

        public EjemplarService(IEjemplarRepository ejempplarRepository, ILibroRepository libroReporistory)
        {
            _ejemplarRepository = ejempplarRepository;
            _libroRepository = libroReporistory;
        }

        public Ejemplar crear(CrearEjemplarDto ejemplar)
        {
            Libro libro = _libroRepository.ObtenerPorID(ejemplar.LibroId);
            if (libro == null)
            {
                throw new KeyNotFoundException($"No se encontro el libro con id:{ejemplar.LibroId}");
            }
            if (!libro.activo)
            {
                throw new InvalidOperationException("No se pueden crear ejemplares de libros inactivos");
            }
            if (!string.IsNullOrEmpty(ejemplar.CodigoBarras))
            {
                var ejemplarExistente = _ejemplarRepository.ObtenerPorCodigoBarras(ejemplar.CodigoBarras);
                if(ejemplarExistente != null)
                {
                    throw new Exception($"Ya existen ejemplares con codigo:{ejemplar.CodigoBarras}");
                }
            }

            var ejemplarNuevo = new Ejemplar
            {
                ejemplar_id = Guid.NewGuid(),
                libro_id = ejemplar.LibroId,
                codigo_barras = ejemplar.CodigoBarras,
                ubicacion = ejemplar.CodigoBarras,
                seccion = ejemplar.Seccion,
                condicion = ejemplar.Condicion,
                estado = ejemplar.Estado,
                notas = ejemplar.Notas,
                fecha_ingreso = DateTime.Now,
                activo = true

            };
            return _ejemplarRepository.Crear(ejemplarNuevo);
        }

        public Ejemplar ActualizarEjemplar(Guid id, ActualizarEjemplarDto ejemplar)
        {
            var ejemplarExistente = _ejemplarRepository.ObtenerPorId(id);
            if(ejemplar == null)
            {
                throw new Exception($"el ejemplar con id {id} no existe");
            }

        }
       
    }
}
