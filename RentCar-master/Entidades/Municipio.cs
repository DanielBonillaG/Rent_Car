using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Municipio
    {
        public string Codigo_Dpto { get; set; }
        public string Codigo_Municipio { get; set; }
        public string Nombre_Municipio { get; set; }

        public Municipio(string codigo_Dpto, string codigo_Municipio, string nombre_Municipio)
        {
            Codigo_Dpto = codigo_Dpto;
            Codigo_Municipio = codigo_Municipio;
            Nombre_Municipio = nombre_Municipio;
        }

        public Municipio()
        {

        }
    }
}
