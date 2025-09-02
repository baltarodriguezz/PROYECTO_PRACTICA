using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO_PRACTICA.Domain
{
    public  class Factura
    {
        public  int Nro { get; set; }
        public DateTime Fecha { get; set; }
        public string Cliente { get; set; }
        public FormaPago FormaPago { get; set; }

        public List<DetalleFactura> Detalles { get; set; }

        public Factura()
        {
            Nro = 0;
            Fecha = DateTime.Now;
            Cliente = string.Empty;
            FormaPago = new FormaPago(); // Por lo menos una forma de pago vacia
            Detalles = new List<DetalleFactura>(); // Por lo menos un detalle vacio
        }

        public double Total()
        {
            double total = 0;
            foreach (DetalleFactura detalle in Detalles)
            {
                total += detalle.SubTotal();
            }
            return total;
        }

        public void AddDetalle(DetalleFactura detalle)
        {
            Detalles.Add(detalle);
        }   

        public void RemoveDetalle(DetalleFactura detalle)
        {
            Detalles.Remove(detalle);
        }

        public override string ToString()
        {
            return $"Factura Nro: {Nro}, Fecha: {Fecha.ToShortDateString()}, Cliente: {Cliente}, Forma de Pago: {FormaPago.Nombre}, Total: {Total():C}";
        }


    }
}
