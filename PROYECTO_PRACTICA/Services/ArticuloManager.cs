using PROYECTO_PRACTICA.Data.Utils;
using PROYECTO_PRACTICA.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO_PRACTICA.Services
{
    public class ArticuloManager
    {
        private readonly UnitOfWork _unitOfWork;

        public ArticuloManager(UnitOfWork unit)
        {
            _unitOfWork = unit;
        }

        public List<Articulo> GetAllArticulos()
        {
            return _unitOfWork.ArticuloRepository.GetAll();
        }
        public Articulo GetArticuloById(int id)
        {
            return _unitOfWork.ArticuloRepository.GetById(id);
        }

        public Articulo SaveArticulo(Articulo articulo)
        {
            _unitOfWork.ArticuloRepository.Save(articulo);
            return articulo;
        }
        public bool DeleteArticulo(int id)
        {
            return _unitOfWork.ArticuloRepository.Delete(id);
        }
        public void Commit()
        {
            _unitOfWork.SaveChanges();
        }

    }
}
