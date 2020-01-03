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
    class SalesReceivablesDBAccess
    {
        private SqlCommand cmd;
        private string query;
        private SqlDataAdapter sda;
        private DataTable dt;
        private SqlConnection conn = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=Inventory;Trusted_Connection=True;Integrated Security = true");

        //private int customerid;
        //private string transactionid;
        //private string transactiondate;
        //private double totalamount;
        //private double totalpayment;

        //public int Customerid { get => customerid; set => customerid = value; }
        //public string Transactionid { get => transactionid; set => transactionid = value; }
        //public string Transactiondate { get => transactiondate; set => transactiondate = value; }
        //public double Totalamount { get => totalamount; set => totalamount = value; }
        //public double Totalpayment { get => totalpayment; set => totalpayment = value; }

        private int customerid;
        private string firstname;
        private string lastname;
        private string company;
        private string transactionid;
        private string transactiondate;
        private double totalamount;
        private double totalpayments;

        public int Customerid { get => customerid; set => customerid = value; }
        public string Firstname { get => firstname; set => firstname = value; }
        public string Lastname { get => lastname; set => lastname = value; }
        public string Company { get => company; set => company = value; }
        public string Transactionid { get => transactionid; set => transactionid = value; }
        public string Transactiondate { get => transactiondate; set => transactiondate = value; }
        public double Totalamount { get => totalamount; set => totalamount = value; }
        public double Totalpayments { get => totalpayments; set => totalpayments = value; }

        public DataTable ViewReceivables()
        {
            conn.Open();
            // query = "select customer.firstname, customer.lastname, customer.company, customer.contact, paymenthistory.customerid, paymenthistory.bankname from customer right join paymenthistory on customer.customerid=paymenthistory.customerid";
            query = "select * from receivables";
            cmd = new SqlCommand(query, conn);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            conn.Close();
            return dt;
        }
        public bool SaveReceivables()
        {
            try
            {
                conn.Open();
                query = "insert into receivables values(" + customerid + ",'" + firstname + "','" + lastname + "','" + company + "','" + transactionid + "','" + transactiondate + "'," + totalamount + ", " + totalpayments + ")";
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
    }
}
