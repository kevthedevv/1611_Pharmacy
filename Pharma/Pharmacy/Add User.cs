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
    public partial class Add_User : Form
    {
        public Account user;
        public Add_User()
        {
            InitializeComponent();
        }

     

        private void Homepage_Load(object sender, EventArgs e)
        {

        }

        private void label_AddUser_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_Inventory_Click(object sender, EventArgs e)
        {
            AccountDatabaseAccess Ada = new AccountDatabaseAccess();
            Account user = new Account();
            user.FirstName = firstNametxt.Text;
            user.LastName = lastNametxt.Text;
            user.Username = usernametxt.Text;
            user.Password = passwordtxt.Text;
            user.UserType = usertypetxt.Text;
            user.Address = addresstxt.Text;
            user.EmailAddress = emailtxt.Text;
            user.Contact = contacttxt.Text;
            Ada.addAccount(user);
        }
    }
}
