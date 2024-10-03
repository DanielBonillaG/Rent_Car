using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DatosDAO;
using Entidades;
using System.Data.SqlClient;
using System.Data;
namespace Datos
{
    public class RepositorioVehiculo : ConexionBD, ICRUD<Vehiculo>
    {
        public string Actualizar(Vehiculo obj)
        {
            try
            {
                string _sql = string.Format("UPDATE [dbo].[Vehiculos] SET [Marca] = '{0}' ,[KilometrajeActual] ='{1}' WHERE [Placa] = '{2}'", obj.Marca, obj.KilometrajeActual, obj.PlacaVehiculo);

                var cmd = new SqlCommand(_sql, conexion);
                AbrirConnexion();
                int filas = cmd.ExecuteNonQuery();
                CerrarConnexion();
                if (filas == 1)
                {
                    return "se Actualizo el registro del Vehiculo con Placas = :" + obj.PlacaVehiculo;
                }
                return "Imposible actualizar el registro del cliente cuyo id = :" + obj.PlacaVehiculo;
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public Vehiculo BuscarID(string id)
        {
            try
            {
                string _sql = string.Format("select * from Vehiculos where Placa ='{0}'", id);
                var cmd = new SqlCommand(_sql, conexion);
                AbrirConnexion();
                var reader = cmd.ExecuteReader();
                reader.Read();
                var Vehiculo = new Entidades.Vehiculo(reader.GetString(0), reader.GetString(1), reader.GetInt32(2));
                CerrarConnexion();
                return Vehiculo;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public string Eliminar(Vehiculo obj)
        {
            try
            {
                string _sql = string.Format("DELETE FROM [dbo].[Vehiculos] WHERE Placa='{0}'", obj.PlacaVehiculo);

                var cmd = new SqlCommand(_sql, conexion);
                AbrirConnexion();
                int filas = cmd.ExecuteNonQuery();
                CerrarConnexion();
                if (filas == 1)
                {
                    return "se elimino el registro del cliente cuyo id = :" + obj.PlacaVehiculo;
                }
                return "Imposible se eliminar el registro del cliente cuyo id = :" + obj.PlacaVehiculo;
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public string Insertar(Vehiculo obj)
        {
            string _sql= string.Format("INSERT [dbo].[Vehiculos] ([Placa], [Marca], [KilometrajeActual]) VALUES ('{0}', '{1}', {2})", obj.PlacaVehiculo, obj.Marca, obj.KilometrajeActual);
            var cmd = new SqlCommand(_sql, conexion);
            AbrirConnexion();
            int filas= cmd.ExecuteNonQuery();
            CerrarConnexion();
            if (filas==1)
            {
                return "se agrego el registro del vehiculo placa :" + obj.PlacaVehiculo;
            }
            return "vehiculo placa :" + obj.PlacaVehiculo + "No agregado";
        }

        public List<Vehiculo> Todos(string obj)
        {
            string _sql = string.Format("select * from Vehiculos");
            var cmd = new SqlCommand(_sql, conexion);
            AbrirConnexion();
            var listaVehiculos = new List<Entidades.Vehiculo>();

            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var vehiculo = new Entidades.Vehiculo(reader.GetString(0), reader.GetString(1), reader.GetInt32(2));
                listaVehiculos.Add(vehiculo);
            }
            CerrarConnexion();
            return listaVehiculos;
        }

        public List<Vehiculo> TodosFiltro(string condicion)
        {
            string _sql = string.Format("select * from Vehiculos where Placa like '{0}%' or Marca like '{1}%'", condicion, condicion);
            System.Data.DataTable tabla = new DataTable("Vehiculos");
            SqlDataAdapter adapter = new SqlDataAdapter(_sql, conexion);

            adapter.Fill(tabla);

            List<Vehiculo> lista = new List<Vehiculo>();

            foreach (var fila in tabla.Rows)
            {

                lista.Add(Map((DataRow)fila));
            }
            return lista;
        }

        Vehiculo Map(DataRow fila)
        {
            Vehiculo vehiculo = new Vehiculo();
            vehiculo.PlacaVehiculo = (string)fila[0];
            vehiculo.Marca = (string)fila[1];
            vehiculo.KilometrajeActual = (int)fila[2];

            return vehiculo;
        }


    }
}