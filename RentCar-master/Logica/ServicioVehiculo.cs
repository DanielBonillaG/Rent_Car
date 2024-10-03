using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class ServicioVehiculo : ICRUD<Vehiculo>
    {
        public string Actualizar(Vehiculo obj)
        {
            return new RepositorioVehiculo().Actualizar(obj);
        }

        public Vehiculo BuscarID(string id)
        {
            return new RepositorioVehiculo().BuscarID(id);
        }

        public string Eliminar(Vehiculo obj)
        {
            return new RepositorioVehiculo().Eliminar(obj);
        }

        public string Insertar(Vehiculo obj)
        {
            return new RepositorioVehiculo().Insertar(obj);
        }

        public List<Vehiculo> Todos(string obj)
        {
            return new RepositorioVehiculo().Todos(obj);
        }

        public List<Vehiculo> TodosFiltro(string condicion)
        {
            return new RepositorioVehiculo().TodosFiltro(condicion);
        }
    }
}
