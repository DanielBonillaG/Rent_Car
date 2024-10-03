using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Datos
{
    public class RepositorioTipoCliente : ConexionBD, DatosDAO.ICRUD<TipoCliente>
    {
        public string Actualizar(TipoCliente obj)
        {
            throw new NotImplementedException();
        }

        public TipoCliente BuscarID(string id)
        {
            try
            {
                string _sql = string.Format("select * from TipoCliente where IdTipo ='{0}''", id);
                var cmd = new SqlCommand(_sql, conexion);
                AbrirConnexion();
                var reader = cmd.ExecuteReader();
                reader.Read();
                var TipoCliente = new Entidades.TipoCliente(reader.GetString(0), reader.GetString(1));
                CerrarConnexion();
                return TipoCliente;
            }
            catch (Exception)
            {

                return null;
            }
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
            string _sql = string.Format("select * from TipoCliente");
            var cmd = new SqlCommand(_sql, conexion);
            AbrirConnexion();
            var listaTipo = new List<Entidades.TipoCliente>();

            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var cliente = new Entidades.TipoCliente(reader.GetString(0), reader.GetString(1));
                listaTipo.Add(cliente);
            }
            CerrarConnexion();
            return listaTipo;
        }

        public List<TipoCliente> TodosFiltro(string obj)
        {
            throw new NotImplementedException();
        }
    }
}
