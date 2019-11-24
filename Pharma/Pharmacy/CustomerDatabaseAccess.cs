using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;

namespace Pharmacy
{
    class CustomerDatabaseAccess
    {

        SqlConnection conn;
        String connectionString = @"Data Source=.\sqlexpress;Initial Catalog=Inventory;Trusted_Connection=True;Integrated Security = true";
        public CustomerDatabaseAccess()
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
        public List<Customer> getAllCustomers()
        {
            SqlCommand command;
            command = new SqlCommand("Select * from Customer", this.conn);
            List<Customer> customers= new List<Customer>();
            using (SqlDataReader reader = command.ExecuteReader()) 
            {
                while(reader.Read())
                {
                    Customer temp = new Customer((int)reader["CustomerID"],reader["FirstName"].ToString(),reader["LastName"].ToString(), reader["Company"].ToString(), reader["Contact"].ToString(), reader["CustomerAddress"].ToString(), reader["EmailAddress"].ToString());
                    customers.Add(temp);
                }
            }
            return customers;
        }
        public bool addCustomer(Customer customer)
        {
            SqlCommand command;
            command = new SqlCommand("Insert into Customer values(@firstname,@lastname,@company,@contact,@address,@email)", this.getConnection());
            SqlParameter lastnameParam = new SqlParameter("@lastname", SqlDbType.VarChar, 255);
            SqlParameter contactParam = new SqlParameter("@contact", SqlDbType.VarChar, 255);
            SqlParameter firstnameParam = new SqlParameter("@firstname", SqlDbType.VarChar, 255);
            SqlParameter companyParam = new SqlParameter("@company", SqlDbType.VarChar, 255);
            SqlParameter addressParam = new SqlParameter("@address", SqlDbType.VarChar, 255);
            SqlParameter emailParam = new SqlParameter("@email", SqlDbType.VarChar, 255);
            contactParam.Value = customer.Contact;
            lastnameParam.Value = customer.LastName;
            firstnameParam.Value = customer.FirstName;
            emailParam.Value = customer.EmailAddress;
            companyParam.Value = customer.Company;
            addressParam.Value = customer.CustomerAddress;
            command.Parameters.Add(emailParam);
            command.Parameters.Add(addressParam);
            command.Parameters.Add(companyParam);
            command.Parameters.Add(lastnameParam);
            command.Parameters.Add(firstnameParam);
            command.Parameters.Add(contactParam);
            command.Prepare();
            return command.ExecuteNonQuery() == 1;
        }
        public bool addCustomer(string firstname, string lastname, string company,string contact,string address, string email)
        {
            SqlCommand command;
            command = new SqlCommand("Insert into Customer values(@firstname,@lastname,@company,@contact,@address,@email)", this.getConnection());
            SqlParameter lastnameParam = new SqlParameter("@lastname", SqlDbType.VarChar, 255);
            SqlParameter contactParam = new SqlParameter("@contact", SqlDbType.VarChar, 255);
            SqlParameter firstnameParam = new SqlParameter("@firstname", SqlDbType.VarChar, 255);
            SqlParameter companyParam = new SqlParameter("@company", SqlDbType.VarChar, 255);
            SqlParameter addressParam = new SqlParameter("@address", SqlDbType.VarChar, 255);
            SqlParameter emailParam = new SqlParameter("@email", SqlDbType.VarChar, 255);
            contactParam.Value = contact;
            lastnameParam.Value = lastname;
            firstnameParam.Value = firstname;
            emailParam.Value = email;
            companyParam.Value = company;
            addressParam.Value = address;
            command.Parameters.Add(emailParam);
            command.Parameters.Add(addressParam);
            command.Parameters.Add(companyParam);
            command.Parameters.Add(lastnameParam);
            command.Parameters.Add(firstnameParam);
            command.Parameters.Add(contactParam);
            command.Prepare();
            return command.ExecuteNonQuery() == 1;
        }
        public bool updateItemByFirstName(int id, string value)
        {
            SqlCommand command;
            command = new SqlCommand("Update Customer set FirstName=@value where CustomerID = @ID", this.conn);
            SqlParameter valueParam = new SqlParameter("@value", SqlDbType.VarChar, 255);
            SqlParameter idParam = new SqlParameter("@ID", SqlDbType.Int);
            valueParam.Value = value;
            idParam.Value = id;
            command.Parameters.Add(valueParam);
            command.Parameters.Add(idParam);
            command.Prepare();
            return command.ExecuteNonQuery() == 1;
        }

        public bool updateItemByLastName(int id, string value)
        {
            SqlCommand command;
            command = new SqlCommand("Update Customer set LastName=@value where CustomerID = @ID", this.conn);
            SqlParameter valueParam = new SqlParameter("@value", SqlDbType.VarChar, 255);
            SqlParameter idParam = new SqlParameter("@ID", SqlDbType.Int);
            valueParam.Value = value;
            idParam.Value = id;
            command.Parameters.Add(valueParam);
            command.Parameters.Add(idParam);
            command.Prepare();
            return command.ExecuteNonQuery() == 1;
        }
        public bool updateItemByCompany(int id, string value)
        {
            SqlCommand command;
            command = new SqlCommand("Update Customer set Company=@value where CustomerID = @ID", this.conn);
            SqlParameter valueParam = new SqlParameter("@value", SqlDbType.VarChar, 255);
            SqlParameter idParam = new SqlParameter("@ID", SqlDbType.Int);
            valueParam.Value = value;
            idParam.Value = id;
            command.Parameters.Add(valueParam);
            command.Parameters.Add(idParam);
            command.Prepare();
            return command.ExecuteNonQuery() == 1;
        }

        public bool updateItemByContact(int id, string value)
        {
            SqlCommand command;
            command = new SqlCommand("Update Customer set Contact=@value where CustomerID = @ID", this.conn);
            SqlParameter valueParam = new SqlParameter("@value", SqlDbType.VarChar, 255);
            SqlParameter idParam = new SqlParameter("@ID", SqlDbType.Int);
            valueParam.Value = value;
            idParam.Value = id;
            command.Parameters.Add(valueParam);
            command.Parameters.Add(idParam);
            command.Prepare();
            return command.ExecuteNonQuery() == 1;
        }

        public bool updateItemByAddress(int id, string value)
        {
            SqlCommand command;
            command = new SqlCommand("Update Customer set CustomerAddress=@value where CustomerID = @ID", this.conn);
            SqlParameter valueParam = new SqlParameter("@value", SqlDbType.VarChar, 255);
            SqlParameter idParam = new SqlParameter("@ID", SqlDbType.Int);
            valueParam.Value = value;
            idParam.Value = id;
            command.Parameters.Add(valueParam);
            command.Parameters.Add(idParam);
            command.Prepare();
            return command.ExecuteNonQuery() == 1;
        }

        public bool updateItemByEmail(int id, string value)
        {
            SqlCommand command;
            command = new SqlCommand("Update Customer set EmailAddress=@value where CustomerID = @ID", this.conn);
            SqlParameter valueParam = new SqlParameter("@value", SqlDbType.VarChar, 255);
            SqlParameter idParam = new SqlParameter("@ID", SqlDbType.Int);
            valueParam.Value = value;
            idParam.Value = id;
            command.Parameters.Add(valueParam);
            command.Parameters.Add(idParam);
            command.Prepare();
            return command.ExecuteNonQuery() == 1;
        }

        public bool deleteCustomer(int id)
        {
            SqlCommand command;
            command = new SqlCommand("Delete from Customer where CustomerID = @ID", this.conn);
            SqlParameter idParam = new SqlParameter("@ID", SqlDbType.Int);
            idParam.Value = id;
            command.Parameters.Add(idParam);
            command.Prepare();
            return command.ExecuteNonQuery() == 1;
        }
    }
}
