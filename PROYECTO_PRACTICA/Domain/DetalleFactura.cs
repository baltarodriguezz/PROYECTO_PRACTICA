using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO_PRACTICA.Domain
{
    public class DetalleFactura
    {
        public Articulo Articulo { get; set; }
        public int Cantidad { get; set; }

        public double SubTotal()
        {
            return Cantidad * Articulo.Precio_unitario;
        }
        public DetalleFactura()
        {
            Articulo = new Articulo(); 
            Cantidad = 0;
        }
    }
}
