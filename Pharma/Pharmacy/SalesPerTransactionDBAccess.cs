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
    class SalesPerTransactionDBAccess
    {  
        private SqlCommand cmd;
        private string query;
        private SqlDataAdapter sda;
        private DataTable dt;
        private SqlConnection conn = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=Inventory;Trusted_Connection=True;Integrated Security = true");

        private string transactionid;
        private double total;
        private double discount;
        private double subtotal;
        private double vatable;
        private double totaldue;
        private double cashtender;
        private double change;
        
        string currentdate = DateTime.Now.ToShortDateString().ToString();
        public string Transactionid { get => transactionid; set => transactionid = value; }
        public double Discount { get => discount; set => discount = value; }
        public double Subtotal { get => subtotal; set => subtotal = value; }
        public double Vatable { get => vatable; set => vatable = value; }
        public double Totaldue { get => totaldue; set => totaldue = value; }
        public double Cashtender { get => cashtender; set => cashtender = value; }
        public double Change { get => change; set => change = value; }
        public double Total { get => total; set => total = value; }

        public bool SaveTotalSalesPerTransaction()
        {
            try
            {
                conn.Open();
                query = "insert into postotalsalepertransaction values('" + transactionid + "'," + total + "," + discount + "," + subtotal + "," + vatable + "," + totaldue + "," + cashtender + "," + change + ", '"+currentdate+"')";
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
