﻿using System;
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
                item.DateArrived = Convert.ToDateTime(DateArrivedtxt.Text);
                item.ExpiryDate = Convert.ToDateTime(ExpiryDatetxt.Text);
                item.GenericName = GenericNametxt.Text;
                item.PurchasedPrice = Convert.ToDouble(PurchasedPricetxt.Text);
                item.SellingPrice = Convert.ToDouble(SellingPricetxt.Text);
                item.Storage = Storagetxt.Text;
                item.Quantity = Convert.ToInt32(Quantitytxt.Text);
                item.Formulation = formulationtxt.Text;
                item.Threshhold = Convert.ToInt32(threshholdTxt.Text);
                if (checkBox_IsVatable.Checked == true)
                {
                    item.Vatable = Convert.ToByte(1);
                    item.SellingPrice -= item.SellingPrice * .12;
                    SellingPricetxt.Text=item.SellingPrice.ToString();
                }
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
            if (BrandNametxt.Text == "")
                return false;
            if (GenericNametxt.Text == "")
                return false;
            if (PurchasedPricetxt.Text == "" || !Double.TryParse(PurchasedPricetxt.Text, out temp) || temp < 0)
                return false;
            if (SellingPricetxt.Text == "" || !Double.TryParse(SellingPricetxt.Text, out temp) || temp < 0)
                return false;
            if (Quantitytxt.Text == "" || !Double.TryParse(Quantitytxt.Text, out temp) || temp < 0)
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
    }
}
