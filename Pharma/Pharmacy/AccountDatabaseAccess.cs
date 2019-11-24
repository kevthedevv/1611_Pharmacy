using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy
{
    class AccountDatabaseAccess
    {
        SqlConnection conn;
        String connectionString = @"Data Source=.\sqlexpress;Initial Catalog=Inventory;Trusted_Connection=True;Integrated Security = true";
        public AccountDatabaseAccess()
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
        public bool addAccount(Account account) 
        {
            SqlCommand command = new SqlCommand("Insert into Accounts values(@UserType,@Username,@UserPassword,@FirstName,@LastName,@UserAddress,@Contact,@EmailAddress)", this.conn);
            SqlParameter typeParam = new SqlParameter("@UserType", SqlDbType.VarChar, 255);
            SqlParameter usernameParam = new SqlParameter("@Username", SqlDbType.VarChar, 255);
            SqlParameter passwordParam = new SqlParameter("@UserPassword", SqlDbType.VarChar, 255);
            SqlParameter firstnameParam = new SqlParameter("@FirstName", SqlDbType.VarChar, 255);
            SqlParameter lastnameeParam = new SqlParameter("@LastName", SqlDbType.VarChar, 255);
            SqlParameter addressParam = new SqlParameter("@UserAddress", SqlDbType.VarChar, 255);
            SqlParameter contactParam = new SqlParameter("@Contact", SqlDbType.VarChar, 255);
            SqlParameter emailParam = new SqlParameter("@EmailAddress", SqlDbType.VarChar, 255);
            typeParam.Value = account.UserType;
            usernameParam.Value = account.Username;
            passwordParam.Value = account.Password;
            firstnameParam.Value = account.FirstName;
            lastnameeParam.Value = account.LastName;
            addressParam.Value = account.Address;
            contactParam.Value = account.Contact;
            emailParam.Value = account.EmailAddress;
            command.Parameters.Add(typeParam);
            command.Parameters.Add(usernameParam);
            command.Parameters.Add(passwordParam);
            command.Parameters.Add(firstnameParam);
            command.Parameters.Add(lastnameeParam);
            command.Parameters.Add(addressParam);
            command.Parameters.Add(contactParam);
            command.Parameters.Add(emailParam);
            command.Prepare();
            return command.ExecuteNonQuery() == 1;
        }

        public List<Account> getAllAccounts()
        {
            SqlCommand command;
            command = new SqlCommand("Select * from Accounts", this.conn);
            List<Account> customers = new List<Account>();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Account temp = new Account();
                    temp.AccountID = (int)reader["AccountID"];
                    temp.Address = reader["UserAddress"].ToString();
                    temp.Contact = reader["Contact"].ToString();
                    temp.EmailAddress = reader["EmailAddress"].ToString();
                    temp.FirstName = reader["FirstName"].ToString();
                    temp.LastName = reader["LastName"].ToString();
                    temp.Password = reader["UserPassword"].ToString();
                    temp.Username = reader["Username"].ToString();
                    temp.UserType = reader["UserType"].ToString();
                    
                    customers.Add(temp);
                }
            }
            return customers;
        }

        public Account getByUsernameAndPassword(string username,string password) 
        {
            Account temp = new Account();
            SqlCommand command = new SqlCommand("Select * from Accounts where Username=@username and UserPassword=@password", this.conn);
            SqlParameter usernameParam = new SqlParameter("@username", SqlDbType.VarChar, 255);
            SqlParameter passwordParam = new SqlParameter("@password", SqlDbType.VarChar, 255);
            usernameParam.Value = username;
            passwordParam.Value =password;
            command.Parameters.Add(usernameParam);
            command.Parameters.Add(passwordParam);
            command.Prepare();
            using (SqlDataReader reader = command.ExecuteReader()) 
            {
                reader.Read();
                if (reader.IsDBNull(0)) 
                {
                    temp.AccountID = -1;
                    return temp;
                }
                temp.AccountID = (int)reader["AccountID"];
                temp.Address = reader["UserAddress"].ToString();
                temp.Contact = reader["Contact"].ToString();
                temp.EmailAddress = reader["EmailAddress"].ToString();
                temp.FirstName = reader["FirstName"].ToString();
                temp.LastName = reader["LastName"].ToString();
                temp.Password = reader["UserPassword"].ToString();
                temp.Username = reader["Username"].ToString();
                temp.UserType = reader["UserType"].ToString();
            }

            return temp;
        }

        public bool deleteAccount(int id)
        {
            SqlCommand command;
            command = new SqlCommand("Delete from Accounts where AccountID = @ID", this.conn);
            SqlParameter idParam = new SqlParameter("@ID", SqlDbType.Int);
            idParam.Value = id;
            command.Parameters.Add(idParam);
            command.Prepare();
            return command.ExecuteNonQuery() == 1;
        }
        public bool updateAccount(Account account) 
        {
            SqlCommand command;
            command = new SqlCommand("Update Accounts set UserType=@type, Username=@username, UserPassword=@password, FirstName=@firstname, LastName=@lastname,UserAddress=@address,Contact=@contact,EmailAddress=@email where AccountID=@id", this.conn);
            SqlParameter typeParam = new SqlParameter("@type", SqlDbType.VarChar, 255);
            SqlParameter usernameParam = new SqlParameter("@username", SqlDbType.VarChar, 255);
            SqlParameter passwordParam = new SqlParameter("@password", SqlDbType.VarChar, 255);
            SqlParameter firstnameParam = new SqlParameter("@firstname", SqlDbType.VarChar, 255);
            SqlParameter lastnameeParam = new SqlParameter("@lastname", SqlDbType.VarChar, 255);
            SqlParameter addressParam = new SqlParameter("@address", SqlDbType.VarChar, 255);
            SqlParameter contactParam = new SqlParameter("@contact", SqlDbType.VarChar, 255);
            SqlParameter emailParam = new SqlParameter("@email", SqlDbType.VarChar, 255);
            SqlParameter idParam = new SqlParameter("@id", SqlDbType.Int);
            typeParam.Value = account.UserType;
            usernameParam.Value = account.Username;
            passwordParam.Value = account.Password;
            firstnameParam.Value = account.FirstName;
            lastnameeParam.Value = account.LastName;
            addressParam.Value = account.Address;
            idParam.Value = account.AccountID;
            contactParam.Value = account.Contact;
            emailParam.Value = account.EmailAddress;
            command.Parameters.Add(typeParam);
            command.Parameters.Add(usernameParam);
            command.Parameters.Add(passwordParam);
            command.Parameters.Add(firstnameParam);
            command.Parameters.Add(lastnameeParam);
            command.Parameters.Add(addressParam);
            command.Parameters.Add(contactParam);
            command.Parameters.Add(idParam);
            command.Parameters.Add(emailParam);
            command.Prepare();
            return command.ExecuteNonQuery() == 1;
        }
    }
}
