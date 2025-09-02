using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO_PRACTICA.Data.Utils
{
   public class DataHelper
    {
        private static DataHelper _instance;

        public static DataHelper GetInstance()
        {
            if (_instance == null)
               {
                 _instance = new DataHelper();
               }
             return _instance;
        }

        public DataTable ExecuteSPQuery(string sp, SqlConnection cnn, SqlTransaction trans)
        {
            DataTable tabla = new DataTable();

            try
            {
                var cmd = new SqlCommand(sp, cnn, trans);
                cmd.CommandType = CommandType.StoredProcedure;
                tabla.Load(cmd.ExecuteReader());
            }
            catch(SqlException)
            {
                tabla = null;
            }
            return tabla;
        }

        public DataTable ExecuteSPQueryParameter(string sp, SqlConnection cnn, SqlTransaction trans, List<ParameterSQL> param)
        {
            DataTable tabla = new DataTable();

            try
            {
                var cmd = new SqlCommand(sp, cnn, trans);
                cmd.CommandType = CommandType.StoredProcedure;
                foreach(var p in param)
                {
                    cmd.Parameters.AddWithValue(p.Nombre, p.Valor);
                }
                tabla.Load(cmd.ExecuteReader());

            }
            catch (SqlException)
            {
                tabla = null;
            }
            return tabla;
        }


        public int ExecuteSPNonQuery(string sp, SqlConnection cnn, SqlTransaction trans, List<ParameterSQL> param)
        {
            int filas = 0;
            try
            {
                var cmd = new SqlCommand(sp, cnn, trans);
                cmd.CommandType = CommandType.StoredProcedure;
                foreach (var p in param)
                {
                    cmd.Parameters.AddWithValue(p.Nombre, p.Valor);
                }
                filas = cmd.ExecuteNonQuery();

            }
            catch (SqlException)
            {
                filas = -1;
            }
            return filas;
        }

    }
}
