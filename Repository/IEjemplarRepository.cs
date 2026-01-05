using Biblioteca.Modelado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca.Repository
{
    public interface IEjemplarRepository
    {
        Ejemplar Crear(Ejemplar ejemplar);
        List<Ejemplar> ObtenerPorTituloLibro(string titulo);
        Ejemplar ObtenerPorCodigoBarras(string codigoBarras);
        List<Ejemplar> ObtenerPorEstado(string estado);

        Ejemplar ObtenerPorId(Guid id);

        Ejemplar Actualizar(Ejemplar ejemplar);
        List<Ejemplar> ObtenerTodos();
        Ejemplar Eliminar(Ejemplar ejemplar);

    }
}
