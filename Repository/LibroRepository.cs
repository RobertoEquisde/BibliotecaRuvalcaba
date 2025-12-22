using Biblioteca.Datos;
using Biblioteca.Modelado;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca.Repository
{
    public class LibroRepository:ILibroRepository
    {
        private readonly ApplicationDBContext _context;
        public LibroRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public void Actualizar(Libro libro)
        {
            _context.Libro.Update(libro);
            _context.SaveChanges();
        }

        public List<Libro> BuscandoPorTitulo(string titulo)
        {
            return _context.Libro
                .Include(l => l.Editorial)
                .Include(l => l.LibroAutores)
                    .ThenInclude(la => la.Autor)
                .Where(l => l.titulo.Contains(titulo) && l.activo)
                .ToList();
        }

        public Libro CrearLibro(Libro libro)
        {
            libro.libro_id = Guid.NewGuid();
            libro.fecha_registro = DateTime.Now;
            libro.activo = true;

            _context.Libro.Add(libro);
            _context.SaveChanges();
            return libro;
        }

        public void Eliminar(Libro libro)
        {
            libro.activo = false;
            _context.Libro.Update(libro);
            _context.SaveChanges();
        }

        public Libro ObtenerPorID(Guid id)
        {
            return _context.Libro
                .Include(l => l.Editorial)
                .Include(l => l.LibroAutores)
                    .ThenInclude(la => la.Autor)
                .Where(l => l.libro_id == id)
                .FirstOrDefault();
        }

        public List<Libro> ObtenerTodos()
        {
            return _context.Libro
                .Include(l => l.Editorial)
                .Include(l => l.LibroAutores)
                    .ThenInclude(la => la.Autor)
                .Where(l => l.activo)
                .ToList();
        }

        public Libro ObtenerPorIsbn(string isbn)
        {
            return _context.Libro
                .Include(l => l.Editorial)
                .Include(l => l.LibroAutores)
                    .ThenInclude(la => la.Autor)
                .Where(l => l.isbn == isbn && l.activo)
                .FirstOrDefault();
        }
    }
}
