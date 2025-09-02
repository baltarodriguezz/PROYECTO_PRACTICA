using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO_PRACTICA.Domain
{
    public class FormaPago
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public FormaPago()
        {
            Id = 0;
            Nombre = string.Empty;
        }


    }
}
