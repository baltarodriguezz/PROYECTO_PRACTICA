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
            DataTable dt = DataHelper.GetInstance().ExecuteSPQuery("SP_RECUPERAR_FACTURAS", connection, transaction);

            foreach(DataRow row in dt.Rows)
            {
                var factura = new Factura()
                {
                    Nro = Convert.ToInt32(row["nro_factura"]),
                    Fecha = Convert.ToDateTime(row["fecha"]),
                    Cliente = row["cliente"].ToString(),
                    FormaPago = new FormaPago()
                    {
                        Id = Convert.ToInt32(row["id_forma_pago"]),
                        Nombre = row["nombre_forma"].ToString()
                    }
                };
                facturas.Add(factura);
            }
            return facturas;
        }

        public Factura GetById(int id)
        {
            List<ParameterSQL> parametros = new List<ParameterSQL>()
            {
                new ParameterSQL() { Nombre = "@nro_factura", Valor = id }
            };
            DataTable dt = DataHelper.GetInstance().ExecuteSPQueryParameter("SP_RECUPERAR_FACTURA_POR_NRO", connection, transaction, parametros);
            Factura f = new Factura();
            foreach (DataRow row in dt.Rows)
            {
                f.Nro = Convert.ToInt32(row["nro_factura"]);
                f.Fecha = Convert.ToDateTime(row["fecha"]);
                f.Cliente = row["cliente"].ToString();
                f.FormaPago = new FormaPago()
                {
                    Id = Convert.ToInt32(row["id_forma_pago"]),
                    Nombre = row["nombre_forma"].ToString()
                };
            }
            return f;
        }

        public bool Save(Factura factura)
        {
            throw new NotImplementedException();
        }
    }
}
