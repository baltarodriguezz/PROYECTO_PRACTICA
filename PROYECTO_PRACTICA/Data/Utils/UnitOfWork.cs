using Microsoft.Data.SqlClient;
using PROYECTO_PRACTICA.Data.Implementations;
using PROYECTO_PRACTICA.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO_PRACTICA.Data.Utils
{
    public class UnitOfWork
    {
        private readonly SqlConnection _connection;
        private SqlTransaction _transaction;
        private IArticuloRepository articuloRepository;
        private IFacturaRepository facturaRepository;

        public UnitOfWork(string connectionString)
        {
            _connection = new SqlConnection(connectionString);
            _connection.Open();
            _transaction = _connection.BeginTransaction();
        }

        public IArticuloRepository ArticuloRepository
        {
            get
            {
                if (articuloRepository == null)
                {
                    articuloRepository = new ArticuloRepositoryADO(_connection, _transaction);
                }
                return articuloRepository;
            }
        }

        public IFacturaRepository FacturaRepository
        {
            get
            {
                if (facturaRepository == null)
                {
                    facturaRepository = new FacturaRepositoryADO(_connection, _transaction);
                }
                return facturaRepository;
            }
        }

        public void SaveChanges()
        {
            try
            {
                _transaction.Commit();
            }
            catch
            {
                _transaction.Rollback();
                throw;
            }
        }
        public void Dispose()
        {
            _transaction?.Dispose();
            if (_connection.State == System.Data.ConnectionState.Open)
            {
                _connection.Close();
            }
            _connection.Dispose();
        }


    }
}
