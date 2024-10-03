using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public  class Alquiler
    {
        public int IdAlquiler { get; set; }
        public string IdCliente { get; set; }
        public string PlacaVehiculo { get; set; }
        public DateTime FechaDeEntrega { get; set; } 
        public DateTime FechaDeRecepcion { get; set; } = DateTime.Now.Date;
        public double KmEntrega { get; set; }
        public double KmRecepcion { get; set; }
        public double KmRecorridos { get; set; }
        public double ValorKm { get; set; }
        public double Descuento { get; set; }
        public double Total { get; set; }

        public Alquiler()
        {

        }

        public Alquiler( string idCliente, string placaVehiculo, DateTime fechaDeEntrega, 
            DateTime fechaDeRecepcion, double kmEntrega, 
            double kmRecepcion, double kmRecorridos, double valorKm, double descuento, double total)
        {
           
            IdCliente = idCliente;
            PlacaVehiculo = placaVehiculo;
            FechaDeEntrega = fechaDeEntrega;
            FechaDeRecepcion = fechaDeRecepcion;
            KmEntrega = kmEntrega;
            KmRecepcion = kmRecepcion;
            KmRecorridos = kmRecorridos;
            ValorKm = valorKm;
            Descuento = descuento;
            Total = total;
        }

        public Alquiler(string idCliente, string placaVehiculo, DateTime fechaDeRecepcion, double kmRecepcion, double valorKm)
        {
            IdCliente = idCliente;
            PlacaVehiculo = placaVehiculo;
            FechaDeRecepcion = fechaDeRecepcion;
            KmRecepcion = kmRecepcion;
            ValorKm = valorKm;
        }
        public Alquiler(int idAlquiler, string idCliente, string placaVehiculo, DateTime fechaDeRecepcion, double kmRecepcion, double valorKm, double descuento)
        {
            IdAlquiler = idAlquiler;
            IdCliente = idCliente;
            PlacaVehiculo = placaVehiculo;
            FechaDeRecepcion = fechaDeRecepcion;
            KmRecepcion = kmRecepcion;
            Descuento = descuento;
            ValorKm = valorKm;
        }

        void ProcesoDeEntregaVehiculo()
        {


        }

        void ProcesoDeRecepcionVehiculo()
        {


        }

        public void CalcularAlquiler()
        {  
            var total = KmRecorridos * ValorKm;
            Total = total - (total) * Descuento/100;
        }
        public void GetRecorrido()
        {
            KmRecorridos = KmEntrega - KmRecepcion;
        }


    }
}
