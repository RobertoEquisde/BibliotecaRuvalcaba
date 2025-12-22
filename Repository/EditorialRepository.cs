using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Biblioteca.Datos;
using Biblioteca.Modelado;

namespace Biblioteca.Repository
{
    public class EditorialRepository:IEditorialRepository
    {
        private readonly ApplicationDBContext _context;
        public EditorialRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public Editorial crearNuevaEditorial(Editorial editorial)
        {
            editorial.editorial_id = Guid.NewGuid();
            editorial.activo = true;
            _context.Editorial.Add(editorial);
            _context.SaveChanges();
            return editorial;
        }

        public Editorial ActualizarEditorial(Editorial editorial)
        {
             _context.Editorial.Update(editorial);
             _context.SaveChanges();
             return editorial;
        }
        public Editorial buscarEditorialPorNombre(string nombre)
        {
            return _context.Editorial
                .Where(e =>
                    e.nombre.Contains(nombre)&&
                    e.activo)
                    .FirstOrDefault();
        }
        public List<Editorial> todasLasEditoriales()
        {
            return _context.Editorial
                .Where(e => e.activo)
                .ToList();
        }

        public Editorial buscarEditorialPorId(Guid id)
        {
            return _context.Editorial
                .Where(e => e.editorial_id == id && e.activo)
                .FirstOrDefault();
        }
    }
}
