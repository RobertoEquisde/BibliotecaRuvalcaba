using Biblioteca.Modelado;
using System;
using System.Collections.Generic;

namespace Biblioteca.Repository
{
    public interface IEditorialRepository
    {
        Editorial crearNuevaEditorial(Editorial editorial);
        Editorial ActualizarEditorial(Editorial editorial);
        Editorial buscarEditorialPorNombre(string nombre);
        Editorial buscarEditorialPorId(Guid id);
        List<Editorial> todasLasEditoriales();
    }
}
