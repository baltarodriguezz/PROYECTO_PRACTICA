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
    public class ArticuloRepositoryADO : IArticuloRepository
    {
        private SqlConnection connection;
        private SqlTransaction transaction;

        public ArticuloRepositoryADO(SqlConnection connection, SqlTransaction transaction)
        {
            this.connection = connection;
            this.transaction = transaction;
        }

        public bool Delete(int id)
        {
            bool resultado = false;
            List<ParameterSQL> parametros = new List<ParameterSQL>()
            {
                new ParameterSQL() { Nombre = "@id", Valor = id }
            };
            int filas = DataHelper.GetInstance().ExecuteSPNonQuery("SP_ELIMINAR_ARTICULO", connection, transaction, parametros);
            if (filas > 0) resultado = true;
            return resultado;
        }

        public List<Articulo> GetAll()
        {
            List<Articulo> articulos = new List<Articulo>();
            DataTable dt = DataHelper.GetInstance().ExecuteSPQuery("SP_RECUPERAR_ARTICULOS", connection, transaction);

            foreach(DataRow row in dt.Rows)
            {
                var articulo = new Articulo()
                {
                    Id = Convert.ToInt32(row["id"]),
                    Nombre = row["Nombre"].ToString(),
                    Precio_unitario = Convert.ToDouble(row["pre_unitario"])
                };
                articulos.Add(articulo);
            }
            return articulos;

        }

        public Articulo GetById(int id)
        {
            List<ParameterSQL> parametros = new List<ParameterSQL>()
            {
                new ParameterSQL() { Nombre = "@id", Valor = id }
            };
            DataTable dt = DataHelper.GetInstance().ExecuteSPQueryParameter("SP_RECUPERAR_ARTICULOS_POR_ID", connection, transaction,parametros);
            Articulo a = new Articulo();
            foreach(DataRow row in dt.Rows)
            {
                a.Id = Convert.ToInt32(row["id"]);
                a.Nombre = row["nombre"].ToString();
                a.Precio_unitario = Convert.ToDouble(row["pre_unitario"]);
            }
            return a;
        }

        public bool Save(Articulo articulo)
        {
            bool resultado = false;
            List<ParameterSQL> parametros = new List<ParameterSQL>()
            {
                new ParameterSQL() { Nombre = "@id", Valor = articulo.Id },
                new ParameterSQL() { Nombre = "@nombre", Valor = articulo.Nombre },
                new ParameterSQL() { Nombre = "@pre_unitario", Valor = articulo.Precio_unitario }
            };
            int filas = DataHelper.GetInstance().ExecuteSPNonQuery("SP_GUARDAR_ARTICULO", connection, transaction, parametros);
            if (filas > 0) resultado = true;
            return resultado;
        }
    }
}
