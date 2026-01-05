using Biblioteca.Datos;
using Biblioteca.Modelado;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca.Repository
{
    public class EjemplarRepository : IEjemplarRepository
    {
        private readonly ApplicationDBContext _context;

        public EjemplarRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public Ejemplar Actualizar(Ejemplar ejemplar)
        {
            _context.Ejemplar.Update(ejemplar);
            _context.SaveChanges();
            return ejemplar;
        }

        public Ejemplar Crear(Ejemplar ejemplar)
        {
            _context.Ejemplar.Add(ejemplar);
            _context.SaveChanges();
            return ejemplar;
        }

        public Ejemplar Eliminar(Ejemplar ejemplar)
        {
            ejemplar.activo = false;
            _context.Ejemplar.Update(ejemplar);
            return ejemplar;
        }

        public Ejemplar ObtenerPorCodigoBarras(string codigoBarras)
        {
            return _context.Ejemplar.FirstOrDefault(e => e.codigo_barras == codigoBarras);
        }

        public List<Ejemplar> ObtenerPorEstado(string estado)
        {
            return _context.Ejemplar.Where(e => e.estado == estado).ToList();
        }

        public List<Ejemplar> ObtenerPorTituloLibro(string titulo)
        {
            return _context.Ejemplar.Include(e => e.libro)
            .Where(e => e.libro.titulo == titulo).ToList();
        }

        public List<Ejemplar> ObtenerTodos()
        {
            return _context.Ejemplar.ToList();
        }

        public Ejemplar ObtenerPorId(Guid id)
        {
            return _context.Ejemplar.Find(id);
        }
    }
}
