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
    public partial class Discounts : Form
    {
        public Discounts()
        {
            InitializeComponent();
        }
        DiscountsDBAccess discountdbaccess = new DiscountsDBAccess();
        private void label_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void ViewDiscounts()
        {
            dataGridView_Discounts.Rows.Clear();
            DataTable dt = discountdbaccess.ViewDiscounts();
            for (int index = 0; index < dt.Rows.Count; index++)
            {
                string id = dt.Rows[index]["discountid"].ToString();
                string type = dt.Rows[index]["discounttype"].ToString();
                string percentage = dt.Rows[index]["discountpercentage"].ToString();
                dataGridView_Discounts.Rows.Add(id, type, percentage);
            }
        }
        private void buttonAddDiscount_Click(object sender, EventArgs e)
        {
            
            discountdbaccess.Discounttype = textbox_DiscountType.Text.ToString();
            discountdbaccess.Percentage = double.Parse(textbox_DiscountPercentage.Text.ToString());
            discountdbaccess.SavePOSDiscounts();
            ViewDiscounts();
        }

        private void Discounts_Load(object sender, EventArgs e)
        {
            ViewDiscounts();
        }
    }
}
