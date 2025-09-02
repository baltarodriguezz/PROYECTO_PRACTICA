using PROYECTO_PRACTICA.Services;
using System.ComponentModel;
using PROYECTO_PRACTICA.Properties;
using PROYECTO_PRACTICA.Domain;

string Cadena = PROYECTO_PRACTICA.Properties.Resources.cnn;
ArticuloManager oAM = new ArticuloManager(Cadena);

FacturaManager oFM = new FacturaManager(Cadena);

oFM.GetFacturaById(1);

Console.WriteLine(oFM.GetFacturaById(1).ToString());