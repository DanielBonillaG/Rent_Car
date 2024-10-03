using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Datos
{
    public class RepositorioDpto : ConexionBD, DatosDAO.ICRUD<Departamento>
    {
        public string Actualizar(Departamento obj)
        {
            throw new NotImplementedException();
        }

        public Departamento BuscarID(string id)
        {
            try
            {
                string _sql = string.Format("select * from Departamentos where CodigoDpto = '{0}'", id);
                var cmd = new SqlCommand(_sql, conexion);
                AbrirConnexion();
                var reader = cmd.ExecuteReader();
                reader.Read();
                var departamento = new Entidades.Departamento(reader.GetString(0), reader.GetString(1));
                CerrarConnexion();
                return departamento;
            }
            catch (Exception)
            {

                return null;
            }
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
            string _sql = string.Format("select * from Departamentos");
            var cmd = new SqlCommand(_sql, conexion);
            AbrirConnexion();
            var listaDepartamento = new List<Entidades.Departamento>();

            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var dpto = new Entidades.Departamento(reader.GetString(0), reader.GetString(1));
                listaDepartamento.Add(dpto);
            }
            CerrarConnexion();
            return listaDepartamento;
        }

        public List<Departamento> TodosFiltro(string obj)
        {
            throw new NotImplementedException();
        }
    }
}
