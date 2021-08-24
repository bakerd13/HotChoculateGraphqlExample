using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace HotChoculate.Infrastructure.Core.Interfaces
{
    public interface IMainDataBaseProvider
    {
        SqlConnection GetConnection(bool blnTransaction = false);

        void TransactionOpen();
        void TransactionCommit();
        void TransactionRollback();
        void TransactionClose();

        SqlCommand CreateCommand(string statement);

        SqlDataReader ExecuteReader(SqlCommand command);
        void ExecuteNonQuery(SqlCommand command);
        void Commit();
    }
}
