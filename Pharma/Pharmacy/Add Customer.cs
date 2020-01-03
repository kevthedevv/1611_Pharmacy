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
    public partial class Add_Customer : Form
    {
        CustomerDatabaseAccess custdb = new CustomerDatabaseAccess();
        public Add_Customer()
        {
            InitializeComponent();
        }

        private void button_CustomerAdd_Click(object sender, EventArgs e)
        {

            custdb.Custfname = textbox_CustomerFirstname.Text.ToString();
            custdb.Custlname = textbox_CustomerLastname.Text.ToString();
            custdb.Custcompany = textbox_CustomerCompany.Text.ToString();
            custdb.Custcontact = textbox_CustomerContactnumber.Text.ToString();
            custdb.Custaddress = textbox_CustomerAddress.Text.ToString();
            custdb.Custemail = textbox_CustomerEmailAddress.Text.ToString();
            custdb.SaveCustomer();
        }

        private void label_CustomerClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
