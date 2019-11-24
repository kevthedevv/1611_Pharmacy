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
    public partial class Add_Order : Form
    {
        Account user;
        OrderDatabaseAccess Oda = new OrderDatabaseAccess();
        public Add_Order()
        {
            InitializeComponent();
        }

        private void button_Inventory_Click(object sender, EventArgs e)
        {
            Order temp = new Order();
            temp.BrandName = BrandNametxt.Text;
            temp.GenericName = GenericNametxt.Text;
            temp.Client = textBox1.Text;
            temp.Amount = Convert.ToDouble( PurchasedPricetxt.Text);
            temp.Quantity = Convert.ToInt32(Quantitytxt.Text);
            temp.DateOrdered = Convert.ToDateTime(ExpiryDatetxt.Text);
            temp.Formulation = formulationtxt.Text;
            Oda.addOrder(temp);
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label_AddProduct_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label_AddProduct_close_Leave(object sender, EventArgs e)
        {
            
        }
    }
}
