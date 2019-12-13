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
    public partial class CustomerHistory : Form
    {
        public CustomerHistory()
        {
            
        }

        private void label_Accounts_Close_Click(object sender, EventArgs e)
        {
            SalesReceivables rece = new SalesReceivables();
            rece.Show();
            this.Close();
        }
    }
}