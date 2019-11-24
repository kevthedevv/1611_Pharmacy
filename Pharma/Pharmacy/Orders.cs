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
    public partial class Orders : Form
    {
        public Account user;
        OrderDatabaseAccess Oda;
        List<Order> orders;
        public void RefreshOrders() 
        {
            FillData();
        }
        public Orders()
        {
            InitializeComponent();
            Oda = new OrderDatabaseAccess();
            FillData();
        }
        public void FillData()
        {

            orders = Oda.getAllOrders();
            dataGridView1.DataSource = orders;
        }


        private void Orders_Load(object sender, EventArgs e)
        {

        }

        private void button_Orders_AddOrder_Click(object sender, EventArgs e)
        {
            Add_Order temp = new Add_Order();
            temp.Show();
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
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete " + s, "Delete Item", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
                {
                    Oda.deleteOrder((int)dataGridView1.SelectedRows[0].Cells[0].Value);
                }
            }
            RefreshOrders();
            textBox1.Text = "";
        }

        private void Orders_Enter(object sender, EventArgs e)
        {
            RefreshOrders();
        }

        private void label_Accounts_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}