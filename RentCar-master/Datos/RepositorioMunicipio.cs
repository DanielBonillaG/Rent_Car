using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class RepositorioMunicipio : ConexionBD, DatosDAO.ICRUD<Entidades.Municipio>
    {
        public string Actualizar(Municipio obj)
        {
            throw new NotImplementedException();
        }

        public Municipio BuscarID(string id)
        {
            try
            {
                string _sql = string.Format("select * from Municipios where Codigo_Municipio = '{0}'", id);
                var cmd = new SqlCommand(_sql, conexion);
                AbrirConnexion();
                var reader = cmd.ExecuteReader();
                reader.Read();
                var muni = new Entidades.Municipio(reader.GetString(0), reader.GetString(1), reader.GetString(2));
                CerrarConnexion();
                return muni;
            }
            catch (Exception)
            {

                return null;
            }
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
            string _sql = string.Format("select * from Municipios");
            var cmd = new SqlCommand(_sql, conexion);
            AbrirConnexion();
            var listaMuni = new List<Entidades.Municipio>();

            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var muni = new Entidades.Municipio(reader.GetString(0), reader.GetString(1), reader.GetString(2));
                listaMuni.Add(muni);
            }
            CerrarConnexion();
            return listaMuni;
        }

        public List<Municipio> TodosFiltro(string obj)
        {
            throw new NotImplementedException();
        }
    }
}
