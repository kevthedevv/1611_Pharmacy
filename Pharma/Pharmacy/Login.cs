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
    public partial class Login : Form
    {
        AccountDatabaseAccess Ada;
        Account user;
        public Login()
        {
            InitializeComponent();
            Ada = new AccountDatabaseAccess();
            user = new Account();
        }



        private void Homepage_Load(object sender, EventArgs e)
        {
            textBox1.Focus();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (login() == true)
            {
                Homepage home = new Homepage();
                home.user = this.user;
                home.Show();
                this.Hide();
            }

        }
        public bool login() 
        {
            user=Ada.getByUsernameAndPassword(textBox1.Text, textBox2.Text);
            if (user.AccountID == -1)
                return false;
            return true;
        }

        private void label_Login_close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
