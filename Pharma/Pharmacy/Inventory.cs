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
    public partial class Inventory : Form
    {
        public Account user;
        List<Item> items;
        ItemDatabaseAccess Ida;
        public Inventory()
        {
            InitializeComponent();
            Ida = new ItemDatabaseAccess();
            FillData();
        }
        public void FillData() 
        {
          
            items= Ida.getAllItem();
            dataGridView1.DataSource = items;
        }
     

        private void Homepage_Load(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button_Inventory_AddProduct_Click(object sender, EventArgs e)
        {
            Add_Product add_product = new Add_Product();
            add_product.Show();

        }

        private void label_Inventory_Close_Click(object sender, EventArgs e)
        {
            this.Close();
            Homepage homepage = new Homepage();
            homepage.user = user;
            homepage.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                dataGridView1.DataSource = items;
            else
            {
                dataGridView1.DataSource = sortByString(textBox1.Text);
            }
        }

        public List<Item> sortByString(string s) 
        {
            List<Item> temp = new List<Item>();
            for (int i = 0; i < items.Count; i++) 
            {
                if(ContainsString(items[i],s))
                    temp.Add(items[i]);
            }
            return temp;
        }
        public bool ContainsString(Item item,string s) 
        {
            if (item.GenericName.IndexOf(s, StringComparison.OrdinalIgnoreCase) >= 0)
                return true;
            if (item.BatchNumber.IndexOf(s, StringComparison.OrdinalIgnoreCase) >= 0)
                return true;
            if (item.BrandName.IndexOf(s, StringComparison.OrdinalIgnoreCase) >= 0)
                return true;
            if (item.DateArrived.ToString().IndexOf(s, StringComparison.OrdinalIgnoreCase) >= 0)
                return true;
            if (item.ExpiryDate.ToString().IndexOf(s, StringComparison.OrdinalIgnoreCase) >= 0)
                return true;
            if (item.ItemID.ToString().IndexOf(s, StringComparison.OrdinalIgnoreCase) >= 0)
                return true;
            if (item.PurchasedPrice.ToString().IndexOf(s, StringComparison.OrdinalIgnoreCase) >= 0)
                return true;
            if (item.Quantity.ToString().IndexOf(s, StringComparison.OrdinalIgnoreCase) >= 0)
                return true;
            if (item.SellingPrice.ToString().IndexOf(s, StringComparison.OrdinalIgnoreCase) >=0)
                return true;
            if (item.Storage.IndexOf(s, StringComparison.OrdinalIgnoreCase) >= 0)
                return true;
            return false;
        }

        private void button_Inventory_Delete_Click(object sender, EventArgs e)
        {
            string s;
            if (dataGridView1.SelectedRows.Count == 0) 
            {
                MessageBox.Show("Select item to delete");
                return;
            }
            if (dataGridView1.SelectedRows.Count > 1)
                s = "these items";
            else
                s = "this item";
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete "+s, "Delete Item", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                for (int i = 0; i < dataGridView1.SelectedRows.Count; i++) 
                {
                    Ida.deleteItem((int)dataGridView1.SelectedRows[0].Cells[0].Value);
                }
            }
            dataGridView1.DataSource = items;
            textBox1.Text = "";

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string s;
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select item to update");
                return;
            }
            Update_Product updateView = new Update_Product();
            Item temp = new Item();
            temp.ItemID = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            temp.BrandName = dataGridView1.SelectedRows[0].Cells[1].Value.ToString(); 
            temp.GenericName = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            temp.ExpiryDate = Convert.ToDateTime(dataGridView1.SelectedRows[0].Cells[3].Value);
            temp.DateArrived = Convert.ToDateTime(dataGridView1.SelectedRows[0].Cells[4].Value);
            temp.PurchasedPrice = Convert.ToDouble(dataGridView1.SelectedRows[0].Cells[5].Value);
            temp.SellingPrice =Convert.ToDouble( dataGridView1.SelectedRows[0].Cells[6].Value);
            temp.BatchNumber = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
            temp.Storage = dataGridView1.SelectedRows[0].Cells[8].Value.ToString();
            temp.Quantity =(int) dataGridView1.SelectedRows[0].Cells[9].Value;
            temp.Formulation = dataGridView1.SelectedRows[0].Cells[10].Value.ToString();
            updateView.update = temp;
            updateView.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Orders orderView = new Orders();
           
            orderView.Show();
        }
    }
}
