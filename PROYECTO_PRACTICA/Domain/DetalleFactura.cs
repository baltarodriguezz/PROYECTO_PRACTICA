using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO_PRACTICA.Domain
{
    public class DetalleFactura
    {
        public int idDetalle {  get; set; }
        public int idFactura { get; set; } 
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
            idDetalle = 0;
            idFactura = 0;
        }

        public override string ToString()
        {
            return $"Id Detalle: {idDetalle}, Articulo: {Articulo.Nombre},Precio Articulo {Articulo.Precio_unitario}, Cantidad: {Cantidad}, SubTotal: {SubTotal():C}";
        }
    }
}
