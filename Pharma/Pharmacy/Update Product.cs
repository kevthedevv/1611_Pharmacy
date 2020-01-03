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
    public partial class Update_Product : Form
    {
        public Item update;
        ItemDatabaseAccess Ida = new ItemDatabaseAccess();
        public Update_Product()
        {
            InitializeComponent();
        }

        private void Update_Product_Load(object sender, EventArgs e)
        {
            BrandNametxt.Text = update.BrandName;
            GenericNametxt.Text = update.GenericName;
            dateTimePicker1.Value = Convert.ToDateTime(update.ExpiryDate.ToString());
           dateTimePicker2.Value = Convert.ToDateTime(update.DateArrived.ToString());
            PurchasedPricetxt.Text = update.PurchasedPrice.ToString();
            SellingPricetxt.Text = update.SellingPrice.ToString();
            BatchNumbertxt.Text = update.BatchNumber;
            Storagetxt.Text = update.Storage;
            Quantitytxt.Text = update.Quantity.ToString();
            formulationtxt.Text = update.Formulation;
        }

        private void button_Inventory_Click(object sender, EventArgs e)
        {
            if (check())
            {
                update.BrandName = BrandNametxt.Text;
                update.GenericName = GenericNametxt.Text;
                //  update.ExpiryDate = Convert.ToDateTime(ExpiryDatetxt.Text);
                //  update.DateArrived = Convert.ToDateTime(DateArrivedtxt.Text);
                update.DateArrived = dateTimePicker2.Value;
                update.ExpiryDate = dateTimePicker1.Value;
                update.PurchasedPrice = Convert.ToDouble(PurchasedPricetxt.Text);
                update.SellingPrice = Convert.ToDouble(SellingPricetxt.Text);
                update.BatchNumber = BatchNumbertxt.Text;
                update.Storage = Storagetxt.Text;
                update.Quantity = Convert.ToInt32(Quantitytxt.Text);
                update.Formulation = formulationtxt.Text;
                if (checkBox_IsVatable.Checked == true)
                    update.Vatable = 1;
                else
                    update.Vatable = 0;
                update.Threshhold = Convert.ToInt32(threshholdTxt.Text);
                if (Ida.updateItem(update))
                {

                    Refresh();
                    this.Close();
                }
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

        private void label_AddProduct_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
