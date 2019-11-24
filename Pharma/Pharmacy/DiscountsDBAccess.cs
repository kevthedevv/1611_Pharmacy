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
    class DiscountsDBAccess
    {

        private SqlCommand cmd;
        private string query;
        private SqlDataAdapter sda;
        private DataTable dt;
        private SqlConnection conn = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=Inventory;Trusted_Connection=True;Integrated Security = true");

        private string discounttype;
        private double percentage;

        public string Discounttype { get => discounttype; set => discounttype = value; }
        public double Percentage { get => percentage; set => percentage = value; }

        public bool SavePOSDiscounts()
        {
            try
            {
                conn.Open();
                // query = "insert into postransactiontemp values("",)";
                query = "insert into posdiscounts values('" + discounttype + "'," + percentage +")";
                cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            catch
            {
                conn.Close();
                return false;
            }
        }
        public DataTable ViewDiscounts()
        {
            conn.Open();
            query = "select * from POSdiscounts";
            cmd = new SqlCommand(query, conn);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            conn.Close();
            return dt;
        }
        public DataTable ViewSelectedDiscounts(string discounttype)
        {
            conn.Open();
            query = "select * from POSdiscounts where discounttype like '"+discounttype+"'";
            cmd = new SqlCommand(query, conn);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            conn.Close();
            return dt;
        }
    }
}
