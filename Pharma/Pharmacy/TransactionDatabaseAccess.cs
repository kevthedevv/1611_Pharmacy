using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace Pharmacy
{
    class TransactionDatabaseAccess
    {
        SqlConnection conn;
        String connectionString = @"Data Source=.\sqlexpress;Initial Catalog=Inventory;Trusted_Connection=True;Integrated Security = true";
        public TransactionDatabaseAccess()
        {
            conn = new SqlConnection(connectionString);
            conn.ConnectionString = this.connectionString;
            conn.Open();
        }
        public SqlConnection getConnection()
        {
            return this.conn;
        }
        public void Close()
        {
            conn.Close();
        }

        
        public bool addTransaction(int CustomerID, DateTime DatePurchased)
        {
            SqlCommand command = new SqlCommand("Insert into Transactions values(@CustomerID,@DatePurchased)", this.getConnection());
            SqlParameter CustomerParam = new SqlParameter("@CustomerID", SqlDbType.Int);
            SqlParameter DateParam = new SqlParameter("@DatePurchased", SqlDbType.DateTime);
            CustomerParam.Value = CustomerID;
            DateParam.Value = DatePurchased;
            command.Parameters.Add(CustomerParam);
            command.Parameters.Add(DateParam);
            command.Prepare();
            return command.ExecuteNonQuery() == 1;
        }

        public bool updateTransactionByCustomer(int id, int value)
        {
            SqlCommand command;
            command = new SqlCommand("Update Transactions set CustomerID=@value where TransactionID = @ID", this.conn);
            SqlParameter valueParam = new SqlParameter("@value", SqlDbType.Int);
            SqlParameter idParam = new SqlParameter("@ID", SqlDbType.Int);
            valueParam.Value = value;
            idParam.Value = id;
            command.Parameters.Add(valueParam);
            command.Parameters.Add(idParam);
            command.Prepare();
            return command.ExecuteNonQuery() == 1;
        }
        public bool updateTransactionByDate(int id, DateTime value)
        {
            SqlCommand command;
            command = new SqlCommand("Update Transactions set DatePurchased=@value where TransactionID = @ID", this.conn);
            SqlParameter valueParam = new SqlParameter("@value", SqlDbType.DateTime);
            SqlParameter idParam = new SqlParameter("@ID", SqlDbType.Int);
            valueParam.Value = value;
            idParam.Value = id;
            command.Parameters.Add(valueParam);
            command.Parameters.Add(idParam);
            command.Prepare();
            return command.ExecuteNonQuery() == 1;
        }
    }
}
