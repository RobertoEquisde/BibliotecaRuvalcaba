using Biblioteca.Modelado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca.Repository
{
    public interface ILibroRepository
    {
        Libro ObtenerPorID(Guid id);
        List<Libro> ObtenerTodos();
        List<Libro> BuscandoPorTitulo(string titulo);
        Libro CrearLibro(Libro libro);
        void Actualizar(Libro libro);
        void Eliminar(Libro libro);
        Libro ObtenerPorIsbn(string isbn);
    }
}
