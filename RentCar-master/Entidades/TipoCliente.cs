using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class TipoCliente
    {
        public string IdCliente { get; set; }
        public string Tipo { get; set; }

        public TipoCliente(string idCliente, string tipo)
        {
            IdCliente = idCliente;
            Tipo = tipo;
        }

        public TipoCliente()
        {

        }
    }
}
