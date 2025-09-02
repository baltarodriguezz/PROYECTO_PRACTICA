using PROYECTO_PRACTICA.Services;
using System.ComponentModel;
using PROYECTO_PRACTICA.Properties;
using PROYECTO_PRACTICA.Domain;

string Cadena = PROYECTO_PRACTICA.Properties.Resources.cnn;
ArticuloManager oAM = new ArticuloManager(Cadena);

var lista = oAM.GetAllArticulos();
foreach (var item in lista)
{
    Console.WriteLine(item);
}


oAM.DeleteArticulo(5);
var lista2 = oAM.GetAllArticulos();
foreach (var item in lista2)
{
    Console.WriteLine(item);
}
oAM.Commit();


