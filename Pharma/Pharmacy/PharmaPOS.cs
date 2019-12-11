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
    public partial class PharmaPOS : Form
    {
        public PharmaPOS()
        {
            InitializeComponent();
        }
        POSDBAccess posDBAccess = new POSDBAccess();
        DialogResult dr = new DialogResult();

        //private int id;
        //private string brandname;
        //private string genericname;
        //private string formulation;
        //private double price;
        //private int qty;
        private double total;

        public double Total { get => total; set => total = value; }

        //private int desiredQuantity;
        //private int getid;


        //public int Id { get => id; set => id = value; }
        //public string Brandname { get => brandname; set => brandname = value; }
        //public string Genericname { get => genericname; set => genericname = value; }
        //public string Formulation { get => formulation; set => formulation = value; }
        //public double Price { get => price; set => price = value; }
        //public int Qty { get => qty; set => qty = value; }
        //public int Getid { get => getid; set => getid = value; }
        //public int DesiredQuantity { get => desiredQuantity; set => desiredQuantity = value; }

        private void button_POS_ProductInquiry_Click(object sender, EventArgs e)
        {

        }

        private void label_POS_Close_Click(object sender, EventArgs e)
        {

            if (dataGridView_POS.Rows.Count != 0)
            {
                MessageBox.Show("POS is active and cannot close the window. You may cancel the transaction");
            }
            else
            {
                Homepage homepage = new Homepage();
                homepage.Show();
                this.Close();
            }

        }

        private void button_POSProductInquiry_Click(object sender, EventArgs e)
        {
            ViewProductData();
            panel_ProductInquiry.Show();
        }

     
        public void ShowProduct()
        {
            //dataGridView_POS.Rows.Add(id, brandname, genericname, formulation, price, desiredQuantity, price + desiredQuantity);
        }

        private void PharmaPOS_Load(object sender, EventArgs e)
        {
            panel_ProductInquiry.Hide();
            panel_Quantity.Hide();
            panel_EditQuantity.Hide();
            button_POSProductInquiry.Enabled = false;
            ComboDiscount();
            comboBox_Discount.SelectedItem = "None";
            ViewPOSProduct();
            button_FinishTransaction.Enabled = false;
            button_POSRemoveItem.Enabled = false;
           
            

        }

        private void dataGridView_ProductInquiry_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {
            panel_ProductInquiry.Hide();
        }
        private void ViewProductData()
        {
            dataGridView_ProductInquiry.Rows.Clear();
            POSDBAccess product = new POSDBAccess();
            DataTable dt = product.ViewPriceInquiry();
            for (int index = 0; index < dt.Rows.Count; index++)
            {
                string id = dt.Rows[index]["itemid"].ToString();
                string brandname = dt.Rows[index]["brandname"].ToString();
                string genericname = dt.Rows[index]["genericname"].ToString();
                string sellingprice = dt.Rows[index]["formulation"].ToString();
                string formulation = dt.Rows[index]["sellingprice"].ToString();
                string quantity = dt.Rows[index]["quantity"].ToString();
               
                dataGridView_ProductInquiry.Rows.Add(id, brandname, genericname, sellingprice, formulation, quantity);
            }
        }
        private void ViewPOSProduct()
        {
            dataGridView_POS.Rows.Clear();   
            DataTable dt = posDBAccess.ViewPOS(label_POSTransactionID.Text.ToString());
            for (int index = 0; index < dt.Rows.Count; index++)
            {
                string id = dt.Rows[index]["itemid"].ToString();
                string brandname = dt.Rows[index]["brandname"].ToString();
                string genericname = dt.Rows[index]["genericname"].ToString();
                string formulation = dt.Rows[index]["formulation"].ToString();
                double sellingprice = double.Parse(dt.Rows[index]["price"].ToString());
                int quantity = int.Parse(dt.Rows[index]["quantity"].ToString());
                double total = double.Parse(dt.Rows[index]["total"].ToString());
                dataGridView_POS.Rows.Add(id, brandname, genericname, formulation, sellingprice, quantity, total);
            }
        }
        private void dataGridView_ProductInquiry_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            panel_Quantity.Show();
            textbox_DesiredQuantity.Focus();
            this.AcceptButton = button_AddtoPOS;


        }

        private void label7_Click(object sender, EventArgs e)
        {
            panel_Quantity.Hide();
            textbox_DesiredQuantity.Text = 1.ToString();
        }

        private void button_AddtoPOS_Click(object sender, EventArgs e)
        {
            
            AddtoPos();
            this.AcceptButton = button_AddtoPOS;
            panel_Quantity.Hide();
            textbox_DesiredQuantity.Text = 1.ToString();
           

            //for (int i = 0; i < dataGridView_POS.Rows.Count; i++)
            //{
            //    double total = 0;
            //    total += double.Parse(dataGridView_POS.Rows[i].Cells[6].ToString());
            //    label_BigSubTotal.Text = total.ToString();
            //}


        }

        private void ViewTotal()
        {
            
            posDBAccess.GetTotal(label_POSTransactionID.Text.ToString());
            label_Total.Text = posDBAccess.Gettotal.ToString();
            label_TotalDue.Text = posDBAccess.Gettotal.ToString();
            Calculate();
        }
        private void AddtoPos()
        {
            int id = int.Parse(dataGridView_ProductInquiry.CurrentRow.Cells[0].Value.ToString());
            if (posDBAccess.CheckIfItemAlreadyAddedToPos(label_POSTransactionID.Text, dataGridView_ProductInquiry.CurrentRow.Cells[1].Value.ToString(), dataGridView_ProductInquiry.CurrentRow.Cells[2].Value.ToString(), dataGridView_ProductInquiry.CurrentRow.Cells[3].Value.ToString()).Rows.Count != 0)
            {
                MessageBox.Show("Item already in the POS.");
            }
            else
            {
                posDBAccess.Transactionid = label_POSTransactionID.Text;
                posDBAccess.Brandname = dataGridView_ProductInquiry.CurrentRow.Cells[1].Value.ToString();
                posDBAccess.Genericname = dataGridView_ProductInquiry.CurrentRow.Cells[2].Value.ToString();
                posDBAccess.Formulation = dataGridView_ProductInquiry.CurrentRow.Cells[3].Value.ToString();
                posDBAccess.Price = double.Parse(dataGridView_ProductInquiry.CurrentRow.Cells[4].Value.ToString());
                posDBAccess.DesiredQuantity = int.Parse(textbox_DesiredQuantity.Text.ToString());
                posDBAccess.Total = double.Parse(dataGridView_ProductInquiry.CurrentRow.Cells[4].Value.ToString()) * int.Parse(textbox_DesiredQuantity.Text.ToString());
                posDBAccess.SaveTransactionTemp();
                ViewPOSProduct();
                ViewTotal();
            }
          
        }
        public void AddtoDB()
        {
            
            posDBAccess.Transactionid2 = label_POSTransactionID.Text;
            posDBAccess.Brandname2 = dataGridView_POS.CurrentRow.Cells[1].Value.ToString();
            posDBAccess.Genericname2 = dataGridView_POS.CurrentRow.Cells[2].Value.ToString();
            posDBAccess.Formulation2 = dataGridView_POS.CurrentRow.Cells[3].Value.ToString();
            posDBAccess.Price2 = double.Parse(dataGridView_POS.CurrentRow.Cells[4].Value.ToString());
            posDBAccess.DesiredQuantity2 = int.Parse(textbox_DesiredQuantity.Text.ToString());
            posDBAccess.Total2 = double.Parse(dataGridView_POS.CurrentRow.Cells[4].Value.ToString()) * int.Parse(textbox_DesiredQuantity.Text.ToString());

            posDBAccess.SaveTransaction();
            dataGridView_POS.Rows.Clear();
            ViewTotal();
            //int id = int.Parse(dataGridView_ProductInquiry.CurrentRow.Cells[0].Value.ToString());
            //string brandname = Brandname = dataGridView_ProductInquiry.CurrentRow.Cells[1].Value.ToString();
            //string genericname = Genericname = dataGridView_ProductInquiry.CurrentRow.Cells[2].Value.ToString();
            //string formulation = Formulation = dataGridView_ProductInquiry.CurrentRow.Cells[3].Value.ToString();
            //double price = Price = double.Parse(dataGridView_ProductInquiry.CurrentRow.Cells[4].Value.ToString());
            //int desiredquantity = DesiredQuantity = int.Parse(textbox_DesiredQuantity.Text.ToString());
            //dataGridView_POS.Rows.Add(id, brandname, genericname, formulation, price, desiredquantity, price * desiredquantity);
            //return true;
        }

        private void ProductIfExist()
        { 
            for(int i = 0; i<dataGridView_POS.Rows.Count; i++)
            {
                if (dataGridView_POS.Rows[i].Cells[0].Value.ToString() == dataGridView_ProductInquiry.CurrentRow.Cells[0].Value.ToString())
                {
                    MessageBox.Show("Duplicate");
                }
            }
           
        }
     
        private void dataGridView_POS_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            panel_EditQuantity.Show();
            textbox_EditDesiredQuantity.Text = dataGridView_POS.CurrentRow.Cells[5].Value.ToString();
            textbox_EditDesiredQuantity.Focus();
            this.AcceptButton = button_EditUpdateToPos;
            
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button_POSNewTransaction_Click(object sender, EventArgs e)
        {
            button_POSNewTransaction.Enabled = false;
            ClearCalculate();
            dataGridView_POS.Rows.Clear();
            posDBAccess.AutoGenerateTransactionID();
            label_POSTransactionID.Text = posDBAccess.Transactionid;
            button_POSProductInquiry.Enabled = true;
            button_FinishTransaction.Enabled = true;
            button_POSCancelTransaction.Enabled = true;
            button_POSRemoveItem.Enabled = true;

        }

        private void dataGridView_POS_Paint(object sender, PaintEventArgs e)
        {
        }
        private void FinishTransaction()
        { 
        
        }
      
        public void FinalizeTransaction(double payment)
        {
            FinishTransaction();
        }
        

        private void button_FinishTransaction_Click(object sender, EventArgs e)
        {
            if (textbox_Cash.Text == "")
            {
                MessageBox.Show("Please input payment first.");
            }
            else if (dataGridView_POS.Rows.Count == 0)
            {
                MessageBox.Show("No item added yet.");
            }
            else
            {
                dr = MessageBox.Show("Finalize payment and save transaction?", "Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (dr == DialogResult.Yes)
                {
                    for (int i = 0; i < dataGridView_POS.Rows.Count; i++)
                    {
                        int itemid = int.Parse(dataGridView_POS.Rows[i].Cells[0].Value.ToString());
                        int quantity = int.Parse(dataGridView_POS.Rows[i].Cells[5].Value.ToString());
                        posDBAccess.UpdateStocks(quantity, itemid);
                    }

                    SalesPerTransactionDBAccess salespertransaction = new SalesPerTransactionDBAccess();
                    salespertransaction.Transactionid = label_POSTransactionID.Text;
                    salespertransaction.Total = double.Parse(label_Total.Text);
                    salespertransaction.Discount = double.Parse(label_Discount.Text);
                    salespertransaction.Subtotal = double.Parse(label_SubTotal.Text);
                    salespertransaction.Vatable = double.Parse(label_Vatable.Text);
                    salespertransaction.Totaldue = double.Parse(label_TotalDue.Text);
                    salespertransaction.Cashtender = double.Parse(textbox_Cash.Text);
                    salespertransaction.Change = double.Parse(label_Change.Text);



                    posDBAccess.FinishTransaction(label_POSTransactionID.Text);
                    dataGridView_POS.Rows.Clear();

                    if (salespertransaction.SaveTotalSalesPerTransaction())
                    {
                        MessageBox.Show("Transaction saved!");
                        button_POSProductInquiry.Enabled = false;
                        button_POSNewTransaction.Enabled = true;
                        button_FinishTransaction.Enabled = false;
                        button_POSCancelTransaction.Enabled = false;
                        button_POSRemoveItem.Enabled = false;
                    }
                    else
                    {
                        dr = MessageBox.Show("An error has occured.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    return;
                }

            }
        }
       
    

        private void button_POSDiscountSettings_Click(object sender, EventArgs e)
        {
            Discounts discount = new Discounts();
            discount.Show();
        }
        private void ComboDiscount()
        {
            DiscountsDBAccess discountdbaccess = new DiscountsDBAccess();
            DataTable dt = discountdbaccess.ViewDiscounts();
            comboBox_Discount.Items.Clear();

            for (int index = 0; index < dt.Rows.Count; index++)
            {
                string discounttype = dt.Rows[index]["discounttype"].ToString();
                comboBox_Discount.Items.Add(discounttype);
            }

        }
        private void ViewSelectedDiscount()
        {
            DiscountsDBAccess discountdbaccess = new DiscountsDBAccess();
            DataTable dt = discountdbaccess.ViewSelectedDiscounts(comboBox_Discount.Text);
            for (int index = 0; index < dt.Rows.Count; index++)
            {
                label_Discount.Text = dt.Rows[index]["discountpercentage"].ToString();

            }
        }

        private void comboBox_Discount_SelectedIndexChanged(object sender, EventArgs e)
        {
            ViewSelectedDiscount();
            Calculate();
        }
        private void Calculate()
        {
            double discount = double.Parse(label_Discount.Text) * double.Parse(label_Total.Text.ToString());
            double discounted = double.Parse(discount.ToString()) ;
            label_Discounted.Text = discounted.ToString("#,0.00");

            double vat = double.Parse(label_Vatable.Text) * double.Parse(label_SubTotal.Text);
            double vatable = double.Parse(vat.ToString());



            double total = double.Parse(label_Total.Text);
            double subtotal;
            subtotal = total - discounted;
            double subtotal2;
            subtotal2 = subtotal - vatable;
            label_SubTotal.Text = subtotal.ToString("#,0.00");
            label_TotalDue.Text = subtotal2.ToString("#,0.00");
            textbox_BigTotal.Text = subtotal2.ToString("#,0.00");

            
        }
        private void ClearCalculate()
        {
            textbox_BigTotal.Text = 0.00.ToString("#,0.00") ;
            label_Total.Text = 0.00.ToString("#,0.00");
            label_Discount.Text = 0.00.ToString();
            label_Discounted.Text = 0.00.ToString("#,0.00");
            label_TotalDue.Text = 0.00.ToString("#,0.00");
            label_SubTotal.Text = 0.00.ToString("#,0.00");
            label_Change.Text = 0.00.ToString("#,0.00");
            textbox_Cash.Clear();
        }
        private void CalculateChange()
        {
            if (textbox_Cash.Text == "")
            {

            }
            else
            {
                double cash = double.Parse(textbox_Cash.Text.ToString());
                double total = double.Parse(label_TotalDue.Text);
                double change;
                change = cash - total;
                label_Change.Text = change.ToString();
            }
        }

        private void textbox_Cash_TextChanged(object sender, EventArgs e)
        {
            if (textbox_Cash.Text == "")
            {
                label_Change.Text = 0.ToString();
            }
            CalculateChange();
            
        }
        public void SearchItem()
        {
            dataGridView_ProductInquiry.Rows.Clear();
            DataTable dt = posDBAccess.SearchItem(textbox_SearchProduct.Text.ToString());
            for (int index = 0; index < dt.Rows.Count; index++)
            {
                string id = dt.Rows[index]["itemid"].ToString();
                string brandname = dt.Rows[index]["brandname"].ToString();
                string genricname = dt.Rows[index]["genericname"].ToString();
                string formulation = dt.Rows[index]["formulation"].ToString();
                string price = dt.Rows[index]["sellingprice"].ToString();
                string quantity = dt.Rows[index]["quantity"].ToString();
                dataGridView_ProductInquiry.Rows.Add(id, brandname, genricname, formulation, price, quantity);
            }
        }

        private void textbox_SearchProduct_TextChanged(object sender, EventArgs e)
        {
            SearchItem();
        }

        private void button_EditUpdateToPos_Click(object sender, EventArgs e)
        {
           
            posDBAccess.DesiredQuantity = int.Parse(textbox_EditDesiredQuantity.Text.ToString());
            posDBAccess.Total = double.Parse(dataGridView_POS.CurrentRow.Cells[4].Value.ToString()) * int.Parse(textbox_EditDesiredQuantity.Text.ToString());
            posDBAccess.UpdatePOSItemQuantity(label_POSTransactionID.Text, dataGridView_POS.CurrentRow.Cells[1].Value.ToString(), dataGridView_POS.CurrentRow.Cells[2].Value.ToString(), dataGridView_POS.CurrentRow.Cells[3].Value.ToString());
            
            ViewPOSProduct();
            ViewTotal();
            panel_EditQuantity.Hide();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            panel_EditQuantity.Hide();
        }

        private void checkBox_Vatable_CheckedChanged(object sender, EventArgs e)
        {
           
            if (checkBox_Vatable.Checked == true)
            {
                label_Vatable.Text = 0.2.ToString();
            }
            else
            {
                label_Vatable.Text = 0.ToString();
            }
            Calculate();
        }

        private void button_POSRemoveItem_Click(object sender, EventArgs e)
        {
            string transactionid = label_POSTransactionID.Text;
            string brandname = dataGridView_POS.CurrentRow.Cells[1].Value.ToString();
            string genericname = dataGridView_POS.CurrentRow.Cells[2].Value.ToString();
            string formulation = dataGridView_POS.CurrentRow.Cells[3].Value.ToString();
            posDBAccess.RemovePOSItem(transactionid, brandname, genericname, formulation);
            ViewPOSProduct();
            ViewTotal();
            if (dataGridView_POS.Rows.Count == 0)
            {
                ClearCalculate();
            }
        }

        private void button_POSCancelTransaction_Click(object sender, EventArgs e)
        {
            
                if (dataGridView_POS.Rows.Count != 0)
                {
                    dr = MessageBox.Show("Cancel current transaction?", "Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                    if (dr == DialogResult.Yes)
                    {
                        DeleteAllPOSItems();
                        Homepage homepage = new Homepage();
                        homepage.Show();
                        this.Close();
                    }
                }
                else
                {
                Homepage homepage = new Homepage();
                homepage.Show();
                this.Close();
            }
            
        }

        private void DeleteAllPOSItems()
        {
            posDBAccess.RemoveAllPOSItem(label_POSTransactionID.Text);
        }

        private void panel12_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
