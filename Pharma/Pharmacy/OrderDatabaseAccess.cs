using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy
{
    class OrderDatabaseAccess
    {
        SqlConnection conn;
        String connectionString = @"Data Source=.\sqlexpress;Initial Catalog=Inventory;Trusted_Connection=True;Integrated Security = true";
        public OrderDatabaseAccess()
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
        public List<Order> getAllOrders()
        {
            List<Order> items = new List<Order>();
            SqlCommand command;
            command = new SqlCommand("Select * from Orders", this.conn);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Order temp = new Order((int)reader["OrderID"], reader["Client"].ToString(), reader["BrandName"].ToString(), reader["GenericName"].ToString(), reader["Formulation"].ToString(), (DateTime)reader["DateOrdered"], (double)reader["Amount"], (int)reader["Quantity"]);
                    items.Add(temp);
                }
            }
            return items;
        }


        public bool addOrder(Order order)
        {
            SqlCommand command;
            command = new SqlCommand("Insert into Orders values(@Client,@BrandName,@GenericName,@Formulation,@DateOrdered,@Amount,@Quantity)", this.getConnection());
            SqlParameter BrandParam = new SqlParameter("@BrandName", SqlDbType.VarChar, 255);
            SqlParameter GenericParam = new SqlParameter("@GenericName", SqlDbType.VarChar, 255);
            SqlParameter DateParam = new SqlParameter("@DateOrdered", SqlDbType.DateTime);
            SqlParameter ClientParam = new SqlParameter("@Client", SqlDbType.VarChar, 255);
            SqlParameter SPParam = new SqlParameter("@Amount", SqlDbType.Float);
            SqlParameter QuantityParam = new SqlParameter("@Quantity", SqlDbType.Int);
            SqlParameter FormulationParam = new SqlParameter("@Formulation", SqlDbType.VarChar, 255);
            BrandParam.Value = order.BrandName;
            GenericParam.Value = order.GenericName;
            DateParam.Value = order.DateOrdered;
            ClientParam.Value = order.Client;
            SPParam.Value = order.Amount;
            QuantityParam.Value = order.Quantity;
            FormulationParam.Value = order.Formulation;
            command.Parameters.Add(BrandParam);
            command.Parameters.Add(GenericParam);
            command.Parameters.Add(DateParam);
            command.Parameters.Add(ClientParam);
            command.Parameters.Add(SPParam);
            command.Parameters.Add(QuantityParam);
            command.Parameters.Add(FormulationParam);
            command.Prepare();
            return command.ExecuteNonQuery() == 1;
        }
        public bool deleteOrder(int id)
        {
            SqlCommand command;
            command = new SqlCommand("Delete from Orders where OrderID = @ID", this.conn);
            SqlParameter idParam = new SqlParameter("@ID", SqlDbType.Int);
            idParam.Value = id;
            command.Parameters.Add(idParam);
            command.Prepare();
            return command.ExecuteNonQuery() == 1;
        }

    }
}
