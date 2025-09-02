using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO_PRACTICA.Domain
{
    public class Articulo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public double Precio_unitario { get; set; }

        public Articulo()
        {
            Nombre = string.Empty;
            Precio_unitario = 0;
            Id = 0;
        }

        public override string ToString()
        {
            return $"Id: {Id}, Nombre: {Nombre}, Precio Unitario: {Precio_unitario}";
        }

    }
}
