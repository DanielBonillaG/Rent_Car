using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Datos;

namespace Logica
{
    public class ServicioDepartamento : ICRUD<Departamento>
    {
        public string Actualizar(Departamento obj)
        {
            throw new NotImplementedException();
        }

        public Departamento BuscarID(string id)
        {
            return new RepositorioDpto().BuscarID(id);
        }

        public string Eliminar(Departamento obj)
        {
            throw new NotImplementedException();
        }

        public string Insertar(Departamento obj)
        {
            throw new NotImplementedException();
        }

        public List<Departamento> Todos(string obj)
        {
            return new RepositorioDpto().Todos(obj);
        }

        public List<Departamento> TodosFiltro(string obj)
        {
            throw new NotImplementedException();
        }
    }
}
