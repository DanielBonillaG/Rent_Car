using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace Datos
{
    public class ConexionBD 
    {
        protected SqlConnection conexion;
        protected string cadenaConexion;
        public ConexionBD()
        {
            string cadenaConexion = "Server=DESKTOP-G3DBTT3;Database=RentCar;Trusted_Connection=True; MultipleActiveResultSets= true";
            conexion = new SqlConnection(cadenaConexion);
        }
        public string AbrirConnexion()
        {
            if (conexion.State == System.Data.ConnectionState.Open)
            {
                CerrarConnexion();
            }
            conexion.Open();
            return conexion.State.ToString();
        }
        public void CerrarConnexion()
        {
            conexion.Close();
        }
    }
}
