using HotChoculate.Infrastructure.Core.Interfaces;
using System;
using System.Data;
using System.Data.SqlClient;

namespace HotChoculate.Infrastructure.Core.Providers
{

    public class DatabaseProvider : IDisposable, IMainDataBaseProvider
    {
        private SqlCommand _sqlCommand;
        private bool _disposedValue;
        private bool _hasInitialised;
        private readonly string _connectionString;

        public SqlConnection SqlConnection { get; set; }
        public SqlTransaction SqlTransaction { get; set; }

        public DatabaseProvider(IConnectionManager connectionManager)
        {
            _connectionString = connectionManager.ConnectionString;
        }

        public SqlConnection GetConnection(bool blnTransaction = false)
        {
            if (!_hasInitialised)
            {
                ConnectionOpen(blnTransaction);
                _hasInitialised = true;
            }
            return SqlConnection;
        }

        public void ConnectionOpen(bool blnTransaction = false)
        {
            SqlConnection = new SqlConnection(_connectionString);
            SqlConnection.Open();

            if (blnTransaction)
            {
                SqlTransaction = SqlConnection.BeginTransaction();
            }
        }


        public void TransactionOpen()
        {
            ConnectionOpen(true);
        }

        public void TransactionCommit()
        {
            if (SqlTransaction?.Connection != null)
                SqlTransaction.Commit();
        }

        public void TransactionRollback()
        {
            if (SqlTransaction?.Connection != null)
                SqlTransaction.Rollback();
        }

        public void TransactionClose()
        {
            if (SqlConnection.State != ConnectionState.Closed)
            {
                SqlConnection.Close();
            }
        }

        public SqlCommand CreateCommand(string statement)
        {
            var connection = GetConnection();
            return new SqlCommand(statement, connection, SqlTransaction);
        }

        public SqlDataReader ExecuteReader(SqlCommand command)
        {
            throw new NotImplementedException();
        }

        public void ExecuteNonQuery(SqlCommand command)
        {
            throw new NotImplementedException();
        }

        public void Commit()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            if (!_disposedValue)
            {
                if (SqlTransaction != null && SqlConnection != null &&
                    SqlConnection.State == ConnectionState.Open)
                {
                    if (SqlTransaction.Connection != null) SqlTransaction.Rollback();
                }


                SqlTransaction?.Dispose();
                SqlTransaction = null;


                if (SqlConnection != null)
                {
                    SqlConnection.Close();
                    SqlConnection.Dispose();
                }


                _sqlCommand?.Dispose();
                _sqlCommand = null;
            }
            _disposedValue = true;
        }
    }
}
