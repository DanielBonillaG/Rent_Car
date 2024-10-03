using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Entidades;

namespace Logica
{
    public class ServicioTipoCliente : ICRUD<TipoCliente>
    {
        public string Actualizar(TipoCliente obj)
        {
            throw new NotImplementedException();
        }

        public TipoCliente BuscarID(string id)
        {
            return new RepositorioTipoCliente().BuscarID(id);
        }

        public string Eliminar(TipoCliente obj)
        {
            throw new NotImplementedException();
        }

        public string Insertar(TipoCliente obj)
        {
            throw new NotImplementedException();
        }

        public List<TipoCliente> Todos(string obj)
        {
            return new RepositorioTipoCliente().Todos(obj);
        }

        public List<TipoCliente> TodosFiltro(string obj)
        {
            throw new NotImplementedException();
        }
    }
}
