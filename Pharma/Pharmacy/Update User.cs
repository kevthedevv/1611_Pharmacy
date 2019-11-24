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
    public partial class Update_User : Form
    {
        public Account temp;
        AccountDatabaseAccess Ada;
        public Update_User()
        {
            InitializeComponent();
            Ada = new AccountDatabaseAccess();
           
        }

        private void Update_User_Load(object sender, EventArgs e)
        {
            addresstxt.Text = temp.Address;
            contacttxt.Text = temp.Contact;
            emailtxt.Text = temp.EmailAddress;
           firstNametxt.Text = temp.FirstName;
            lastNametxt.Text = temp.LastName;
            passwordtxt.Text = temp.Password;
            usernametxt.Text = temp.Username;
            usertypetxt.Text = temp.UserType;
        }

        private void label_AddUser_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_Inventory_Click(object sender, EventArgs e)
        {
            temp.Address = addresstxt.Text;
            temp.Contact = contacttxt.Text;
            temp.EmailAddress = emailtxt.Text;
            temp.FirstName = firstNametxt.Text;
            temp.LastName = lastNametxt.Text;
            temp.Password = passwordtxt.Text;
            temp.Username = usernametxt.Text;
            temp.UserType = usertypetxt.Text;
            Ada.updateAccount(temp);
        }

        private void firstNametxt_TextChanged(object sender, EventArgs e)
        {
          
        }
    }
}
