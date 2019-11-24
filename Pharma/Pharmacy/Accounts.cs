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
    public partial class Accounts : Form
    {
        public Account user;
        AccountDatabaseAccess Ada;
        List<Account> accounts;
        public Accounts()
        {
            Ada = new AccountDatabaseAccess();
            InitializeComponent();
            accounts = Ada.getAllAccounts();
            Fill();
        }


        public void refresh()
        {
            accounts = Ada.getAllAccounts();
            Fill();
        }
        private void Homepage_Load(object sender, EventArgs e)
        {

        }
        public void Fill() 
        {

            dataGridView1.DataSource = accounts;
        }
        private void label_Accounts_Close_Click(object sender, EventArgs e)
        {
            this.Close();
            Homepage homepage = new Homepage();
            homepage.user = user;
            homepage.Show();
        }

        private void button_Accounts_AddUser_Click(object sender, EventArgs e)
        {
            Add_User adduser = new Add_User();
            adduser.user = user;
            adduser.Show();
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
                s = "these accounts";
            else
                s = "this account";
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete " + s, "Delete Account", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
                {
                    Ada.deleteAccount((int)dataGridView1.SelectedRows[0].Cells[0].Value);
                }
            }
            textBox1.Text = "";
            refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Update_User update = new Update_User();
            Account Update = new Account();
            string s;
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select item to edit");
                return;
            }
            Update.AccountID = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            Update.UserType = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            Update.Username = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            Update.Password = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            Update.FirstName = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            Update.LastName = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            Update.Address = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            Update.Contact = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
            Update.EmailAddress = dataGridView1.SelectedRows[0].Cells[8].Value.ToString();
            update.temp = Update;
            update.Show();
        }
    }
}