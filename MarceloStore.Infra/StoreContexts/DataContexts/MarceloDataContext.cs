using MarceloStore.Shared;
using System;
using System.Data;
using System.Data.SqlClient;


namespace MarceloStore.Infra.StoreContexts.DataContexts
{
    public class MarceloDataContext : IDisposable
    {
        public SqlConnection Connection { get; set; }

        public MarceloDataContext()
        {
            Connection = new SqlConnection(Settings.ConnectionString);
        }
        public void Dispose()
        {
            if (Connection.State != ConnectionState.Closed)
                Connection.Close();
        }
    }
}
