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
            ExpiryDatetxt.Text = update.ExpiryDate.ToString();
            DateArrivedtxt.Text = update.DateArrived.ToString();
            PurchasedPricetxt.Text = update.PurchasedPrice.ToString();
            SellingPricetxt.Text = update.SellingPrice.ToString();
            BatchNumbertxt.Text = update.BatchNumber;
            Storagetxt.Text = update.Storage;
            Quantitytxt.Text = update.Quantity.ToString();
            formulationtxt.Text = update.Formulation;
        }

        private void button_Inventory_Click(object sender, EventArgs e)
        {
            update.BrandName=BrandNametxt.Text;
            update.GenericName= GenericNametxt.Text  ;
            update.ExpiryDate = Convert.ToDateTime(ExpiryDatetxt.Text);
            update.DateArrived =Convert.ToDateTime( DateArrivedtxt.Text);
            update.PurchasedPrice =Convert.ToDouble( PurchasedPricetxt.Text);
            update.SellingPrice =Convert.ToDouble( SellingPricetxt.Text);
             update.BatchNumber= BatchNumbertxt.Text;
            update.Storage = Storagetxt.Text;
            update.Quantity =Convert.ToInt32(Quantitytxt.Text);
            update.Formulation =  formulationtxt.Text;
            Ida.updateItem(update);
        }

        private void label_AddProduct_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
