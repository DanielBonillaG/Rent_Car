using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Departamento
    {
        public string Codigo_Dpto { get; set; }
        public string Nombre_Departamento { get; set; }

        public Departamento(string codigo_Dpto, string nombre_Departamento)
        {
            Codigo_Dpto = codigo_Dpto;
            Nombre_Departamento = nombre_Departamento;
        }

        public Departamento()
        {

        }
    }
}
