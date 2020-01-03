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
    public partial class SalesReceivables : Form
    {
        History history = new History();
        public SalesReceivables()
        {
            InitializeComponent();
        }

      


        SalesReceivablesDBAccess receivablesdbaccess = new SalesReceivablesDBAccess();

      

        private void label1_Click(object sender, EventArgs e)
        {
            Homepage home = new Homepage();
            this.Close();
            home.Show();
            
        }
        private void ViewReceivables()
        {
            datagridview_Receivables.Rows.Clear();
            DataTable dt = receivablesdbaccess.ViewReceivables();
            for (int index = 0; index < dt.Rows.Count; index++)
            {
                string transid = dt.Rows[index]["transactionid"].ToString();
                int custid = int.Parse(dt.Rows[index]["customerid"].ToString());
                string fname = dt.Rows[index]["firstname"].ToString();
                string lname = dt.Rows[index]["lastname"].ToString();
                string company = dt.Rows[index]["company"].ToString();
                double balance = double.Parse(dt.Rows[index]["totalamount"].ToString()) - double.Parse(dt.Rows[index]["totalpayments"].ToString());
                string status;
                if (balance == 0)
                {
                    status = "CLEARED";
                }
                else
                {
                    status = "NOT CLEARED";
                }
                datagridview_Receivables.Rows.Add(transid, custid, fname, lname, company,balance, status);
               
            }
        }

        private void datagridview_Receivables_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            history.Custid = int.Parse(datagridview_Receivables.CurrentRow.Cells[1].Value.ToString());
            history.Fname = datagridview_Receivables.CurrentRow.Cells[2].Value.ToString();
            history.Lname = datagridview_Receivables.CurrentRow.Cells[3].Value.ToString();
            history.Company = datagridview_Receivables.CurrentRow.Cells[4].Value.ToString();
            history.Show();

        }

        private void SalesReceivables_Load(object sender, EventArgs e)
        {
            ViewReceivables();
        }

        private void label_Accounts_Close_Click(object sender, EventArgs e)
        {

        }
    }
}
