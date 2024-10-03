using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public interface ICRUD<T>
    {
        string Insertar(T obj);
        string Eliminar(T obj);
        string Actualizar(T obj);
        T BuscarID(string id);
        List<T> Todos(string obj);
        List<T> TodosFiltro(string obj);
    }
}
