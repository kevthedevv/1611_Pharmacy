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
    class HistoryDBAccess
    {
        private SqlCommand cmd;
        private string query;
        private SqlDataAdapter sda;
        private DataTable dt;
        private SqlConnection conn = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=Inventory;Trusted_Connection=True;Integrated Security = true");

        private int customerid;
        private string fname;
        private string lname;
        private string company;
        private string transactionid;
        private string transactiondate;
        private double totalamount;
        private double totalpayments;

        public int Customerid { get => customerid; set => customerid = value; }
        public string Fname { get => fname; set => fname = value; }
        public string Lname { get => lname; set => lname = value; }
        public string Company { get => company; set => company = value; }
        public string Transactionid { get => transactionid; set => transactionid = value; }
        public string Transactiondate { get => transactiondate; set => transactiondate = value; }
        public double Totalamount { get => totalamount; set => totalamount = value; }
        public double Totalpayments { get => totalpayments; set => totalpayments = value; }

        public DataTable ViewHistory(int custid)
        {
            conn.Open();
            query = "select * from Receivables where customerid= "+ custid +"";
            cmd = new SqlCommand(query, conn);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            conn.Close();
            return dt;
        }
        public DataTable ViewPaymentsHistory(string transid)
        {
            conn.Open();
            query = "select * from PaymentHistory where transactionid= '" + transid + "'";
            cmd = new SqlCommand(query, conn);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            conn.Close();
            return dt;
        }


    }
}
