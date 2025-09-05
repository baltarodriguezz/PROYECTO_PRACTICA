using PROYECTO_PRACTICA.Data.Interfaces;
using PROYECTO_PRACTICA.Data.Utils;
using PROYECTO_PRACTICA.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO_PRACTICA.Services
{
    public class FacturaManager
    {
        private readonly UnitOfWork _unitOfWork;

        public FacturaManager(UnitOfWork unit)
        {
            _unitOfWork = unit;
        }
        public List<Factura> ObtenerFacturas()
        {
            return _unitOfWork.FacturaRepository.GetAll();
        }
        public Factura GetFacturaById(int id)
        {
            return _unitOfWork.FacturaRepository.GetById(id);
        }
    }
}
