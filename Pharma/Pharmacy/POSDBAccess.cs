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
    class POSDBAccess
    {
        private SqlCommand cmd;
        private string query;
        private SqlDataAdapter sda;
        private DataTable dt;
        private SqlConnection conn = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=Inventory;Trusted_Connection=True;Integrated Security = true");


        private string transactionid;
        private int itemid;
        private string brandname;
        private string genericname;
        private string formulation;
        private double price;
        private int desiredQuantity;
        private double total;
        private double gettotal;

        private string transactionid2;
        private string brandname2;
        private string genericname2;
        private string formulation2;
        private double price2;
        private int desiredQuantity2;
        private double total2;
        private double gettotal2;
        private string currentdate;

        private string transactionid3;
        private string customerid;
        private string datepaid;
        private string paymentmethod;
        private string bankname;
        private string accountnumber;
        private string checknumber;
        private string checkname;
        private double amount;

        public string Brandname { get => brandname; set => brandname = value; }
        public string Genericname { get => genericname; set => genericname = value; }
        public string Formulation { get => formulation; set => formulation = value; }
        public double Price { get => price; set => price = value; }
        public int DesiredQuantity { get => desiredQuantity; set => desiredQuantity = value; }
        public string Transactionid { get => transactionid; set => transactionid = value; }
        public double Total { get => total; set => total = value; }
        public double Gettotal { get => gettotal; set => gettotal = value; }
        public string Transactionid2 { get => transactionid2; set => transactionid2 = value; }
        public string Brandname2 { get => brandname2; set => brandname2 = value; }
        public string Genericname2 { get => genericname2; set => genericname2 = value; }
        public string Formulation2 { get => formulation2; set => formulation2 = value; }
        public double Price2 { get => price2; set => price2 = value; }
        public int DesiredQuantity2 { get => desiredQuantity2; set => desiredQuantity2 = value; }
        public double Total2 { get => total2; set => total2 = value; }
        public double Gettotal2 { get => gettotal2; set => gettotal2 = value; }
        public string Currentdate { get => currentdate; set => currentdate = value; }
        public string Transactionid3 { get => transactionid3; set => transactionid3 = value; }
        public string Customerid { get => customerid; set => customerid = value; }
        public string Datepaid { get => datepaid; set => datepaid = value; }
        public string Paymentmethod { get => paymentmethod; set => paymentmethod = value; }
        public string Bankname { get => bankname; set => bankname = value; }
        public string Accountnumber { get => accountnumber; set => accountnumber = value; }
        public string Checknumber { get => checknumber; set => checknumber = value; }
        public string Checkname { get => checkname; set => checkname = value; }
        public double Amount { get => amount; set => amount = value; }
        public int Itemid { get => itemid; set => itemid = value; }

        public DataTable ViewPriceInquiry()
        {
            conn.Open();
            query = "select itemID, brandname, genericname, formulation, sellingprice, quantity from item";
            cmd = new SqlCommand(query, conn);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            conn.Close();
            return dt;
        }
        public bool UpdateStocks(int quantity, int itemid)
        {
            try
            {
                conn.Open();
                query = "update item set quantity=Quantity-" + quantity + " where itemid=" + itemid + ";";
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
        public DataTable ViewPOS(string transid)
        {
            conn.Open();
            query = "select item.ItemID, postransactiontemp.brandname, postransactiontemp.genericname, postransactiontemp.formulation, postransactiontemp.price, postransactiontemp.quantity, postransactiontemp.total from item right join postransactiontemp on item.brandname=postransactiontemp.brandname where transactionid like '%" + transid + "%'";
            cmd = new SqlCommand(query, conn);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            conn.Close();
            return dt;
        }
        public DataTable Get_Item(int itemid)
        {
            conn.Open();
            query = "select * from item where itemid like '" + itemid + "'";
            cmd = new SqlCommand(query, conn);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            conn.Close();
            return dt;
        }
        public void GetTotal(string transid)
        {
            try
            {
                conn.Open();
                query = "select sum(total) from postransactiontemp where transactionid like'%" + transid + "%'";
                cmd = new SqlCommand(query, conn);
                gettotal = Convert.ToDouble(cmd.ExecuteScalar());
                conn.Close();
            }
            catch
            {
                conn.Close();
            }
        }

        public bool SaveTransactionTemp()
        {
            try
            {
                conn.Open();
                // query = "insert into postransactiontemp values("",)";
                query = "insert into postransactiontemp values("+itemid+",'" + transactionid + "','" + brandname + "','" + genericname + "','" + formulation + "'," + price + "," + desiredQuantity + "," + total + ")";
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
        public bool SaveTransaction()
        {
            try
            {
                conn.Open();
                // query = "insert into postransactiontemp values("",)";
                query = "insert into postransaction values('" + transactionid2 + "','" + brandname2 + "','" + genericname2 + "','" + formulation2 + "'," + price2 + "," + desiredQuantity2 + "," + total2 + ")";
                cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            catch
            {
                MessageBox.Show("Error");
                conn.Close();
                return false;

            }
        }

        public void AutoGenerateTransactionID()
        {
            conn.Open();
            // query = "select transactionid from postransaction group by transactionid having count(transactionid)> 1 ";
            query = "select count(DISTINCT transactionid) from postransaction";
            cmd = new SqlCommand(query, conn);
            int count = Convert.ToInt16(cmd.ExecuteScalar()) + 1;
            transactionid = "TRA-" + count.ToString("D10");
            conn.Close();
        }
        public void FinishTransaction(string transid)
        {
            conn.Open();
            query = "insert into postransaction select * from postransactiontemp where transactionid like '" + transid + "'";
            cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public DataTable SearchItem(string item)
        {
            conn.Open();
            query = "select * from item where brandname like '%" + item + "%' or genericname like '%" + item + "%' or formulation like '%" + item + "%' or sellingprice like '%" + item + "%' ";
            cmd = new SqlCommand(query, conn);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            conn.Close();
            return dt;
        }
        public DataTable CheckIfItemAlreadyAddedToPos(string transactionid, string brandname, string genericname, string formulation)
        {
            conn.Open();
            query = "select * from postransactiontemp where transactionid = '" + transactionid + "' AND brandname = '" + brandname + "' AND genericname = '" + genericname + "' AND formulation = '" + formulation + "'";
            cmd = new SqlCommand(query, conn);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            conn.Close();
            return dt;
        }
        public bool UpdatePOSItemQuantity(string transid, string brandname, string genericname, string formulation)
        {
            try
            {
                conn.Open();
                query = "update postransactiontemp set quantity ='" + desiredQuantity + "', total= '" + total + "' where transactionid = '" + transactionid + "' AND brandname = '" + brandname + "' AND genericname = '" + genericname + "' AND formulation = '" + formulation + "'";
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
        public void SalesPerTransaction(string transid)
        {
            conn.Open();
            query = "insert into postransaction select * from postransactiontemp where transactionid like '" + transid + "'";
            cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void RemovePOSItem(string transid, string brandname, string genericname, string formulation)
        {
            conn.Open();
            query = "delete from postransactiontemp where transactionid='" + transid + "' and brandname='" + brandname + "' and genericname='" + genericname + "' and formulation='" + formulation + "'";
            cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void RemoveAllPOSItem(string transid)
        {
            conn.Open();
            query = "delete from postransactiontemp where transactionid = '" + transid + "';";
            cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public bool SavePayment()
        {

            try
            {
                conn.Open();
                query = "insert into PaymentHistory values('" + transactionid3 + "', '" + customerid + "', '" + datepaid + "', '" + paymentmethod + "', '" + bankname + "', '" + accountnumber + "', '" + checknumber + "', '" + checkname + "', " + amount + ")";
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
        public bool UpdatePayments(string transid, double amount)
        {
            try
            {
                conn.Open();
                query = "update receivables set totalpayments = totalpayments + '" + amount + "' where transactionid='" + transid + "'";
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
