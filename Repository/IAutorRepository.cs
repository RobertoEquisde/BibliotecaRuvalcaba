using Biblioteca.Modelado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca.Repository
{
    public interface IAutorRepository
    {
        Autor creandoAutor(Autor autor);
        Autor buscandoAutorPorNombre(string nombre);
        Autor buscandoAutorPorId(Guid id);
        List<Autor> obteniendoTodosLosAutores();
        Autor actualizandoAutor(Autor autor);
    }
}
