using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Biblioteca.Datos;
using Biblioteca.Modelado;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
namespace Biblioteca.Repository
{
    public class AutorRepository : IAutorRepository
    {
        private readonly ApplicationDBContext _context;

        public AutorRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public Autor creandoAutor(Autor autor)
        {
            autor.autor_id = Guid.NewGuid();
            autor.activo = true;

            _context.Autor.Add(autor);
            _context.SaveChanges();
            return autor;
        }
        public Autor buscandoAutorPorNombre(string nombre)
        {
            return _context.Autor
                .Where(a =>
                    (a.nombre_completo.Contains(nombre) ||
                     a.nombre_ordenacion.Contains(nombre)) &&
                    a.activo)
                .FirstOrDefault();
        }

        public Autor buscandoAutorPorId(Guid id)
        {
            return _context.Autor
                .Where(a => a.autor_id == id && a.activo)
                .FirstOrDefault();
        }

        public List<Autor> obteniendoTodosLosAutores()
        {
            return _context.Autor
                .Where(a => a.activo)
                .ToList();
        }
        public Autor actualizandoAutor(Autor autor)
        {
                _context.Autor.Update(autor);
                _context.SaveChanges();
                return autor;
        }

    }
}
