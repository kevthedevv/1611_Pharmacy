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
    public partial class Add_Product : Form
    {
        Account user;
        public Add_Product()
        {
            InitializeComponent();
        }



        private void Homepage_Load(object sender, EventArgs e)
        {

        }

        private void label_AddProduct_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_Inventory_Click(object sender, EventArgs e)
        {
            if (check())
            {
                Item item = new Item();
                item.BatchNumber = BatchNumbertxt.Text;
                item.BrandName = BrandNametxt.Text;
                item.DateArrived = dateTimePicker2.Value;
                item.ExpiryDate = dateTimePicker1.Value;
                item.GenericName = GenericNametxt.Text;
                item.PurchasedPrice = Convert.ToDouble(PurchasedPricetxt.Text);
                item.SellingPrice = Convert.ToDouble(SellingPricetxt.Text);
                item.Storage = Storagetxt.Text;
                item.Quantity = Convert.ToInt32(Quantitytxt.Text);
                item.Formulation = formulationtxt.Text;
                item.Threshhold = Convert.ToInt32(threshholdTxt.Text);
                if (checkBox_IsVatable.Checked == true)
                    item.Vatable = Convert.ToByte(1);
                else item.Vatable = Convert.ToByte(0);
                ItemDatabaseAccess Ida = new ItemDatabaseAccess();

               if(Ida.addItem(item)) { this.Close(); }
            }
            else
            {
                MessageBox.Show("Error: Please fill in all required fields");
            }
        }

        public bool check()
        {

            //this methods checks whether all the fields are filled in and is in desired format
            double temp;
            int inttemp;
            if (BrandNametxt.Text == "")
                return false;
            if (GenericNametxt.Text == "")
                return false;
            if (PurchasedPricetxt.Text == "" || !Double.TryParse(PurchasedPricetxt.Text, out temp) || temp < 0)
                return false;
            if (SellingPricetxt.Text == "" || !Double.TryParse(SellingPricetxt.Text, out temp) || temp < 0)
                return false;
            if (Quantitytxt.Text == "" || !int.TryParse(Quantitytxt.Text, out inttemp) || inttemp < 0)
                return false;
            if (Storagetxt.Text == "")
                return false;
            if (BatchNumbertxt.Text == "")
                return false;
            if (formulationtxt.Text == "")
                return false;
            if (threshholdTxt.Text == "" || !int.TryParse(threshholdTxt.Text, out inttemp) || inttemp < 0)
                return false;
            return true;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void BatchNumbertxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void checkBox_IsVatable_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
