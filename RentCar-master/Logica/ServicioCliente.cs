using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class ServicioCliente : ICRUD<Cliente>
    {
        public string Actualizar(Cliente obj)
        {
            return new RepositorioClientes().Actualizar(obj);
        }

        public Cliente BuscarID(string id)
        {
            return new RepositorioClientes().BuscarID(id);
        }

        public string Eliminar(Cliente obj)
        {
            return new RepositorioClientes().Eliminar(obj);
        }

        public string Insertar(Cliente obj)
        {
            return new RepositorioClientes().Insertar(obj);
        }

        public List<Cliente> Todos(string obj)
        {
            return new RepositorioClientes().Todos(obj);
        }

        public List<Cliente> TodosFiltro(string condicion)
        {
            return new RepositorioClientes().TodosFiltro(condicion);
        }
    }
}
