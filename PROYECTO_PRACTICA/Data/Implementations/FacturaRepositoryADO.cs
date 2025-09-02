using Microsoft.Data.SqlClient;
using PROYECTO_PRACTICA.Data.Interfaces;
using PROYECTO_PRACTICA.Data.Utils;
using PROYECTO_PRACTICA.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO_PRACTICA.Data.Implementations
{
    public class FacturaRepositoryADO : IFacturaRepository
    {
        private SqlConnection connection;
        private SqlTransaction transaction;

        public FacturaRepositoryADO(SqlConnection connection, SqlTransaction transaction)
        {
            this.connection = connection;
            this.transaction = transaction;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Factura> GetAll()
        {
            List<Factura> facturas = new List<Factura>();
            DataTable dt = DataHelper.GetInstance().ExecuteSPQuery("SP_RECUPERAR_ARTICULOS", connection, transaction);

            foreach(DataRow row in dt.Rows)
            {
                var factura = new Factura();
                factura.Nro = Convert.ToInt32(row["Nro"]);
            }
            return facturas;
        }

        public Factura GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Save(Factura factura)
        {
            throw new NotImplementedException();
        }
    }
}
