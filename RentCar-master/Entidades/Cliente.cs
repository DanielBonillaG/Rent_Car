using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Cliente
    {
        public Cliente(string IDC, string nombre, string tipoCliente, string departamento, string municipio)
        {
            this.IDC = IDC;
            Nombre = nombre;
            TipoCliente = tipoCliente;
            Departamento = departamento;
            Municipio = municipio;  
        }
        public Cliente()
        {

        }
        public string IDC { get; set; }
        public string Nombre { get; set; }
        public string TipoCliente { get; set; }
        public string Departamento { get; set; }
        public string Municipio { get; set; }


    }
}
