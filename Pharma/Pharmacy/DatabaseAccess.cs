using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Pharmacy
{
    class DatabaseAccess
    {
        SqlConnection conn;
        String connectionString = @"Data Source=.\sqlexpress;Initial Catalog=Inventory;Trusted_Connection=True;Integrated Security = true";
        public DatabaseAccess()
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
      
        public bool updateCustomerbyFirstName(int id, string FirstName)
        {
            SqlCommand command;
            command = new SqlCommand("Update Customer set FirstName=@FirstName where CustomerID = @ID",this.conn);
            SqlParameter first = new SqlParameter("@FirstName", SqlDbType.VarChar, 255);
            SqlParameter idParam = new SqlParameter("@ID", SqlDbType.Int);
            first.Value = FirstName;
            idParam.Value= id;
            command.Parameters.Add(first);
            command.Parameters.Add(idParam);
            command.Prepare();
            return command.ExecuteNonQuery() == 1;

        }
       
        public bool addCustomer(String firstname, String lastname, string contact)
        {
            SqlCommand command;
            command = new SqlCommand("Insert into Customer values(@val,@val1,@val2)", this.getConnection());
            SqlParameter lastnameParam = new SqlParameter("@val", SqlDbType.VarChar, 255);
            SqlParameter contactParam = new SqlParameter("@val2", SqlDbType.VarChar, 255);
            SqlParameter firstnameParam = new SqlParameter("@val1", SqlDbType.VarChar, 255);
            contactParam.Value = contact;
            lastnameParam.Value = lastname;
            firstnameParam.Value = firstname;
            command.Parameters.Add(lastnameParam);
            command.Parameters.Add(firstnameParam);
            command.Parameters.Add(contactParam);
            command.Prepare();
            return command.ExecuteNonQuery() == 1;
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
    }
}
