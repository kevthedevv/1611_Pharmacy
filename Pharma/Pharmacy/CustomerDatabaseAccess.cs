using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Pharmacy
{
    class CustomerDatabaseAccess
    {
        private SqlCommand cmd;
        private string query;
        private SqlDataAdapter sda;
        private DataTable dt;
        private SqlConnection conn = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=Inventory;Trusted_Connection=True;Integrated Security = true");

        private string custfname;
        private string custlname;
        private string custcompany;
        private string custcontact;
        private string custaddress;
        private string custemail;

      
        public string Custfname { get => custfname; set => custfname = value; }
        public string Custlname { get => custlname; set => custlname = value; }
        public string Custcompany { get => custcompany; set => custcompany = value; }
        public string Custcontact { get => custcontact; set => custcontact = value; }
        public string Custaddress { get => custaddress; set => custaddress = value; }
        public string Custemail { get => custemail; set => custemail = value; }


        public bool SaveCustomer()
        {
            try
            {
                conn.Open();
                query = "insert into Customer values('" + custfname + "','" + custlname + "','" + custcompany + "','" + custcontact + "','" + custaddress + "','" + custemail + "')";
                cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            catch
            {
                MessageBox.Show("hey");
                conn.Close();
                return false;

            }

        }
        public DataTable ViewCustomer()
        {
            conn.Open();
            query = "select customerid, firstname, lastname, company, contact, customeraddress, emailaddress from customer;";
            cmd = new SqlCommand(query, conn);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            conn.Close();
            return dt;
        }
        public DataTable SearchCustomer(string item)
        {
            conn.Open();
            query = "select * from customer where customerid like '%" + item + "%' or firstname like '%" + item + "%' or lastname like '%" + item + "%' or company like '%" + item + "%' ";
            cmd = new SqlCommand(query, conn);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            conn.Close();
            return dt;
        }
    }
}
