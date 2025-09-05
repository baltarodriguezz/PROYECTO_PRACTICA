using PROYECTO_PRACTICA.Services;
using System.ComponentModel;
using PROYECTO_PRACTICA.Properties;
using PROYECTO_PRACTICA.Domain;
using PROYECTO_PRACTICA.Data.Utils; 

string Cadena = PROYECTO_PRACTICA.Properties.Resources.cnn;
UnitOfWork unit = new UnitOfWork(Cadena);
FacturaManager facturaManager = new FacturaManager(unit);



var factura = facturaManager.GetFacturaById(1);
Console.WriteLine(factura.ToString());
foreach (var detail in factura.Detalles)
{
    Console.WriteLine($"\t{detail.ToString()}");
}

