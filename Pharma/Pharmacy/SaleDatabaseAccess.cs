using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy
{
    class SaleDatabaseAccess
    {

        SqlConnection conn;
        String connectionString = @"Data Source=.\sqlexpress;Initial Catalog=Inventory;Trusted_Connection=True;Integrated Security = true";
        public SaleDatabaseAccess()
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

        public List<Sale> getSaleByTransactionID(int TransactionID)
        {
            List<Sale> sales = new List<Sale>();
            SqlCommand command;
            command = new SqlCommand("Select * from Sale where TransactionID=@ID",this.conn);
            SqlParameter idParam = new SqlParameter("@ID", SqlDbType.Int);
            idParam.Value = TransactionID;
            command.Parameters.Add(idParam);
            using (SqlDataReader reader = command.ExecuteReader())
            {
               while(reader.Read())
                {
                    Sale sale = new Sale();
                    sale.Balance = (double)reader["Balance"];
                    sale.DatePurchased = (DateTime)reader["DatePurchased"];
                    sale.ItemID = (int)reader["ItemID"];
                    sale.Quantity = (int)reader["Quantity"];
                    sale.SaleID = (int)reader["SaleID"];
                    sale.SellingPrice = (double)reader["SellingPrice"];
                    sale.TransactionID = (int)reader["TransactionID"];
                    sales.Add(sale);
                }
            }
            return sales;
        }
        public bool addSale(Sale sale) 
        {
            SqlCommand command;
            command = new SqlCommand("Insert into Sale values(@ItemID,@Balance,@Quantity,@Transaction,@datePurchased,@SellingPrice)", this.getConnection());
            SqlParameter ItemParam = new SqlParameter("@ItemID", SqlDbType.Int);
            SqlParameter BalanceParam = new SqlParameter("@Balance", SqlDbType.Float);
            SqlParameter QuantityParam = new SqlParameter("@Quantity", SqlDbType.Int);
            SqlParameter TransactionParam = new SqlParameter("@Transaction", SqlDbType.Int);
            SqlParameter SellingPriceParam = new SqlParameter("@SellingPrice", SqlDbType.Float);
            SqlParameter dateParam = new SqlParameter("@datePurchased", SqlDbType.DateTime);

            ItemParam.Value = sale.ItemID;
            BalanceParam.Value = sale.Balance;
            QuantityParam.Value = sale.Quantity;
            TransactionParam.Value = sale.TransactionID;
            SellingPriceParam.Value = sale.SellingPrice;
            dateParam.Value = sale.DatePurchased;

            command.Parameters.Add(ItemParam);
            command.Parameters.Add(TransactionParam);
            command.Parameters.Add(SellingPriceParam);
            command.Parameters.Add(dateParam);
            command.Parameters.Add(BalanceParam);
            command.Parameters.Add(QuantityParam);

            command.Prepare();
            return command.ExecuteNonQuery() == 1;
        }
        public bool addSale(int ItemID, double balance, int quantity, int Transaction, DateTime datePurchased, double SellingPrice)
        {
            SqlCommand command;
            command = new SqlCommand("Insert into Sale values(@ItemID,@Balance,@Quantity,@Transaction,@datePurchased,@SellingPrice)", this.getConnection());
            SqlParameter ItemParam = new SqlParameter("@ItemID", SqlDbType.Int);
            SqlParameter BalanceParam = new SqlParameter("@Balance", SqlDbType.Float);
            SqlParameter QuantityParam = new SqlParameter("@Quantity", SqlDbType.Int);
            SqlParameter TransactionParam = new SqlParameter("@Transaction", SqlDbType.Int);
            SqlParameter SellingPriceParam = new SqlParameter("@SellingPrice", SqlDbType.Float);
            SqlParameter dateParam = new SqlParameter("@datePurchased", SqlDbType.DateTime);

            ItemParam.Value = ItemID;
            BalanceParam.Value = balance;
            QuantityParam.Value = quantity;
            TransactionParam.Value = Transaction;
            SellingPriceParam.Value = SellingPrice;
            dateParam.Value = datePurchased;

            command.Parameters.Add(ItemParam);
            command.Parameters.Add(TransactionParam);
            command.Parameters.Add(SellingPriceParam);
            command.Parameters.Add(dateParam);
            command.Parameters.Add(BalanceParam);
            command.Parameters.Add(QuantityParam);

            command.Prepare();
            return command.ExecuteNonQuery() == 1;
        }

        public bool updateSaleByItemID(int id, int value) {

            SqlCommand command;
            command = new SqlCommand("Update Sale set ItemID=@value where SaleID = @ID", this.conn);
            SqlParameter valueParam = new SqlParameter("@value", SqlDbType.VarChar, 255);
            SqlParameter idParam = new SqlParameter("@ID", SqlDbType.Int);
            valueParam.Value = value;
            idParam.Value = id;
            command.Parameters.Add(valueParam);
            command.Parameters.Add(idParam);
            command.Prepare();
            return command.ExecuteNonQuery() == 1;
        }
        public bool updateSaleByTransaction(int id, int value)
        {

            SqlCommand command;
            command = new SqlCommand("Update Sale set TransactionID=@value where SaleID = @ID", this.conn);
            SqlParameter valueParam = new SqlParameter("@value", SqlDbType.VarChar, 255);
            SqlParameter idParam = new SqlParameter("@ID", SqlDbType.Int);
            valueParam.Value = value;
            idParam.Value = id;
            command.Parameters.Add(valueParam);
            command.Parameters.Add(idParam);
            command.Prepare();
            return command.ExecuteNonQuery() == 1;
        }
        public bool updateSaleBySellingPrice(int id, double value)
        {

            SqlCommand command;
            command = new SqlCommand("Update Sale set SellingPrice=@value where SaleID = @ID", this.conn);
            SqlParameter valueParam = new SqlParameter("@value", SqlDbType.VarChar, 255);
            SqlParameter idParam = new SqlParameter("@ID", SqlDbType.Int);
            valueParam.Value = value;
            idParam.Value = id;
            command.Parameters.Add(valueParam);
            command.Parameters.Add(idParam);
            command.Prepare();
            return command.ExecuteNonQuery() == 1;
        }
        public bool updateSaleByDateParam(int id, DateTime value)
        {

            SqlCommand command;
            command = new SqlCommand("Update Sale set DatePurchased=@value where SaleID = @ID", this.conn);
            SqlParameter valueParam = new SqlParameter("@value", SqlDbType.VarChar, 255);
            SqlParameter idParam = new SqlParameter("@ID", SqlDbType.Int);
            valueParam.Value = value;
            idParam.Value = id;
            command.Parameters.Add(valueParam);
            command.Parameters.Add(idParam);
            command.Prepare();
            return command.ExecuteNonQuery() == 1;
        }
        public bool updateSaleByBalance(int id, double value)
        {

            SqlCommand command;
            command = new SqlCommand("Update Sale set Balance=@value where SaleID = @ID", this.conn);
            SqlParameter valueParam = new SqlParameter("@value", SqlDbType.VarChar, 255);
            SqlParameter idParam = new SqlParameter("@ID", SqlDbType.Int);
            valueParam.Value = value;
            idParam.Value = id;
            command.Parameters.Add(valueParam);
            command.Parameters.Add(idParam);
            command.Prepare();
            return command.ExecuteNonQuery() == 1;
        }
        public bool updateSaleByQuantity(int id, int value)
        {

            SqlCommand command;
            command = new SqlCommand("Update Sale set Quantity=@value where SaleID = @ID", this.conn);
            SqlParameter valueParam = new SqlParameter("@value", SqlDbType.VarChar, 255);
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
