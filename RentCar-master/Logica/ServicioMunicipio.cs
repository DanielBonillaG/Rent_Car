using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Logica
{
    public class ServicioMunicipio : ICRUD<Entidades.Municipio>
    {
        public string Actualizar(Municipio obj)
        {
            throw new NotImplementedException();
        }

        public Municipio BuscarID(string id)
        {
            return new RepositorioMunicipio().BuscarID(id);
        }

        public string Eliminar(Municipio obj)
        {
            throw new NotImplementedException();
        }

        public string Insertar(Municipio obj)
        {
            throw new NotImplementedException();
        }

        public List<Municipio> Todos(string obj)
        {
            return new RepositorioMunicipio().Todos(obj);
        }

        public List<Municipio> TodosFiltro(string obj)
        {
            throw new NotImplementedException();
        }
    }
}
