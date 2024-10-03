using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data.SqlClient;
using System.Data;

namespace Datos
{
    public class RepositorioAlquileres : ConexionBD, DatosDAO.ICRUD<Alquiler>
    {
        public string Actualizar(Alquiler obj)
        {
            try
            {
                string _sql = string.Format("UPDATE [dbo].[Alquileres] SET [Fecha_Entrega] = '{0}' ,[KmRecorridos] = {1}, [Total] = {2},[KmEntrega]={3} WHERE [IdAlquiler] = '{4}'", obj.FechaDeEntrega.Date.ToString("dd/M/yyyy"), obj.KmRecorridos, obj.Total, obj.KmEntrega, obj.IdAlquiler);

                var cmd = new SqlCommand(_sql, conexion);
                AbrirConnexion();
                int filas = cmd.ExecuteNonQuery();
                CerrarConnexion();
                if (filas == 1)
                {
                    return "se Actualizo el registro del cliente :" + obj.IdCliente;
                }
                return "Imposible actualizar el registro del cliente cuyo id = :" + obj.IdCliente;
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public Alquiler BuscarID(string id)
        {
            try
            {
                string _sql = string.Format("select * from Alquileres where IdAlquiler ='{0}'", id);
                var cmd = new SqlCommand(_sql, conexion);
                AbrirConnexion();
                var reader = cmd.ExecuteReader();
                reader.Read();

                var Alquiler = new Entidades.Alquiler();
                Alquiler.IdAlquiler = reader.GetInt32(0);
                Alquiler.IdCliente = reader.GetString(1);
                Alquiler.PlacaVehiculo = reader.GetString(2);
                Alquiler.FechaDeRecepcion = reader.GetDateTime(4);
                Alquiler.KmRecepcion = double.Parse(reader.GetDecimal(6).ToString());
                Alquiler.ValorKm = double.Parse(reader.GetDecimal(8).ToString());
                Alquiler.Descuento = double.Parse(reader.GetDecimal(9).ToString());

                CerrarConnexion();
                return Alquiler;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public string Eliminar(Alquiler obj)
        {
            try
            {
                string _sql = string.Format("DELETE FROM [dbo].[Alquileres] WHERE IdCliente='{0}'", obj.IdCliente);

                var cmd = new SqlCommand(_sql, conexion);
                AbrirConnexion();
                int filas = cmd.ExecuteNonQuery();
                CerrarConnexion();
                if (filas == 1)
                {
                    return "se elimino el registro del cliente cuyo id = :" + obj.IdCliente;
                }
                return "Imposible se eliminar el registro del cliente cuyo id = :" + obj.IdCliente;
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public string Insertar(Alquiler obj)
        {
            try
            {
                string _sql = string.Format("INSERT INTO [Alquileres] ([IdCliente], [Placa], [Fecha_Recepcion],[KmRecepcion],[ValorKm],[Descuento]) VALUES ('{0}','{1}','{2}','{3}','{4}',{5})",
                    obj.IdCliente, obj.PlacaVehiculo, obj.FechaDeRecepcion.Date.ToString("dd/M/yyyy"), obj.KmRecepcion, obj.ValorKm, obj.Descuento);

                var cmd = new SqlCommand(_sql, conexion);
                AbrirConnexion();
                int filas = cmd.ExecuteNonQuery();
                CerrarConnexion();
                if (filas == 1)
                {
                    return string.Format("se guardó correctamente el alquiler {0} asignado a {1} :", obj.IdAlquiler, obj.IdCliente);
                }
                return "Alquiler :" + obj.IdAlquiler + "No agregado";
            } catch (Exception e)
            {
                return e.Message;
            }


        }

        public List<Alquiler> Todos(string obj)
        {
            string _sql = string.Format("select * from Alquileres");
            var cmd = new SqlCommand(_sql, conexion);
            AbrirConnexion();
            var listaAlquileres = new List<Entidades.Alquiler>();

            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var alquiler = new Entidades.Alquiler();
                alquiler.IdAlquiler = reader.GetInt32(0);
                alquiler.IdCliente = reader.GetString(1);
                alquiler.PlacaVehiculo = reader.GetString(2);
                alquiler.FechaDeRecepcion = (reader.IsDBNull(4)) ? DateTime.Now : reader.GetDateTime(4);
                alquiler.KmRecepcion = (reader.IsDBNull(6)) ? 0 : double.Parse(reader.GetDecimal(6).ToString());
                alquiler.ValorKm = double.Parse(reader.GetDecimal(8).ToString());
                alquiler.Descuento = (reader.IsDBNull(9)) ? 0 : double.Parse(reader.GetDecimal(9).ToString());
                alquiler.FechaDeEntrega = (reader.IsDBNull(3))?DateTime.Now:reader.GetDateTime(3);
                alquiler.KmEntrega = (reader.IsDBNull(5)) ? 0:double.Parse(reader.GetDecimal(5).ToString());
                alquiler.KmRecorridos = (reader.IsDBNull(7)) ? 0:double.Parse(reader.GetDecimal(7).ToString());
                alquiler.Total = (reader.IsDBNull(10)) ? 0: double.Parse(reader.GetDecimal(10).ToString());
                listaAlquileres.Add(alquiler);
            }
            CerrarConnexion();
            return listaAlquileres;
        }
        public List<Alquiler> TodosFiltro(string condicion)
        {
            string _sql = string.Format("select * from Alquileres where Placa like '{0}%' or IdCliente like '{1}%'", condicion, condicion);
            System.Data.DataTable tabla = new DataTable("Alquileres");
            SqlDataAdapter adapter = new SqlDataAdapter(_sql, conexion);

            adapter.Fill(tabla);

            List<Alquiler> lista = new List<Alquiler>();

            foreach (var fila in tabla.Rows)
            {

                lista.Add(Map((DataRow)fila));
            }
            return lista;
        }

        Alquiler Map(DataRow fila)
        {
            Alquiler alquiler = new Alquiler();
            alquiler.IdAlquiler = (int)fila[0];
            alquiler.IdCliente = (string)fila[1];
            alquiler.PlacaVehiculo = (string)fila[2];
            alquiler.FechaDeEntrega = (DateTime)fila[3];
            alquiler.FechaDeRecepcion = (DateTime)fila[4];
            alquiler.KmEntrega = (double)fila[5];
            alquiler.KmRecorridos = (double)fila[6];
            alquiler.KmRecepcion = (double)fila[7];
            alquiler.ValorKm = (double)fila[8];
            alquiler.Total = (double)fila[9];


            return alquiler;
        }
    }
}
