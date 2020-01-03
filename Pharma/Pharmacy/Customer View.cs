using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pharmacy
{
    public partial class Customer_View : Form
    {
        
        public Customer_View()
        {
            InitializeComponent();
        }
        CustomerDatabaseAccess custdb = new CustomerDatabaseAccess();
        private void button_Accounts_AddUser_Click(object sender, EventArgs e)
        {
            Add_Customer cust = new Add_Customer();
            cust.Show();
        }

        private void label_Accounts_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ViewCustomer()
        {
            dataGridView_Customers.Rows.Clear();
            DataTable dt = custdb.ViewCustomer();
            for (int index = 0; index < dt.Rows.Count; index++)
            {
                string fname = dt.Rows[index]["firstname"].ToString();
                string lname = dt.Rows[index]["lastname"].ToString();
                string company = dt.Rows[index]["company"].ToString();
                string contact = dt.Rows[index]["contact"].ToString();
                string add = dt.Rows[index]["customerAddress"].ToString();
                string emailadd = dt.Rows[index]["emailaddress"].ToString();

                dataGridView_Customers.Rows.Add(fname, lname, company, contact, add, emailadd);
            }
        }

        private void Customer_View_Load(object sender, EventArgs e)
        {
            ViewCustomer();
        }
    }
}