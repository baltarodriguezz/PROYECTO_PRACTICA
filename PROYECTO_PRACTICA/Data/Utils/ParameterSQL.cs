using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO_PRACTICA.Data.Utils
{
    public class ParameterSQL
    {
        public string Nombre { get; set; }
        public object Valor { get; set; }

        public ParameterSQL(string nombre, object valor)
        {
            Nombre = nombre;
            Valor = valor;
        }

        public ParameterSQL()
        {
        }
    }
}
