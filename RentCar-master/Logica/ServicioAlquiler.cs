using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Datos;

namespace Logica
{
    public class ServicioAlquiler : ICRUD<Alquiler>
    {
        public string Actualizar(Alquiler obj)
        {
            return new RepositorioAlquileres().Actualizar(obj);
        }

        public Alquiler BuscarID(string id)
        {
            return new RepositorioAlquileres().BuscarID(id);
        }

        public string Eliminar(Alquiler obj)
        {
            return new RepositorioAlquileres().Eliminar(obj);
        }

        public string Insertar(Alquiler obj)
        {
            new ServicioCliente().BuscarID(obj.IdCliente);

            return new RepositorioAlquileres().Insertar(obj);
        }   

        public List<Alquiler> Todos(string obj)
        {
            return new RepositorioAlquileres().Todos(obj);
        }

        public List<Alquiler> TodosFiltro(string condicion)
        {
            return new RepositorioAlquileres().TodosFiltro(condicion);
        }
    }
}
