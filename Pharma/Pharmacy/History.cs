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
    public partial class History : Form
    {
        HistoryDBAccess history = new HistoryDBAccess();
        POSDBAccess posDBAccess = new POSDBAccess();
        public History()
        {
            InitializeComponent();
        }
        private int custid;
        private string fname;
        private string lname;
        private string company;

        public string Fname { get => fname; set => fname = value; }
        public string Lname { get => lname; set => lname = value; }
        public string Company { get => company; set => company = value; }
        public int Custid { get => custid; set => custid = value; }

        private void History_Load(object sender, EventArgs e)
        {
            label_CustomerId.Text = custid.ToString();
            label_Name.Text = fname.ToString() + " " + lname.ToString();
            label_Company.Text = company.ToString();
            ViewHistoryDatagrid();
            panel_Payment.Hide();


        }
        public void ViewHistoryDatagrid()
        {
           
                dataGridView_CurrentStatus.Rows.Clear();
                DataTable dt = history.ViewHistory(int.Parse(label_CustomerId.Text));
                for (int index = 0; index < dt.Rows.Count; index++)
                {
                  
                    string transid = dt.Rows[index]["transactionid"].ToString();
                    string transdate = dt.Rows[index]["transactiondate"].ToString();
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
                dataGridView_CurrentStatus.Rows.Add(transid, transdate, balance, status);
                }
            
        }

        private void label_Accounts_Close_Click(object sender, EventArgs e)
        {
            this.Close();
            SalesReceivables rece = new SalesReceivables();
            rece.Show();
        }

        private void button_PayNow_Click(object sender, EventArgs e)
        {
            panel_Payment.Show();
        }

        private void button_AddPayment_Click(object sender, EventArgs e)
        {
            if (textbox_Amount.Text == "")
            {
                MessageBox.Show("Please input amount.");
            }
            else
            {
                DialogResult dr = new DialogResult();
                dr = MessageBox.Show("Finalize payment and save transaction?", "Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (dr == DialogResult.Yes)
                {
                    posDBAccess.Transactionid3 = dataGridView_CurrentStatus.CurrentRow.Cells[0].Value.ToString();
                    posDBAccess.Customerid = label_CustomerId.Text.ToString();
                    posDBAccess.Datepaid = DateTime.Now.ToShortDateString().ToString();
                    posDBAccess.Paymentmethod = combobox_PaymentMethod.Text.ToString();
                    posDBAccess.Bankname = textbox_Bank.Text.ToString();
                    posDBAccess.Accountnumber = textbox_AccountNumber.Text.ToString();
                    posDBAccess.Checknumber = textbox_CheckNumber.Text.ToString();
                    posDBAccess.Checkname = textbox_Name.Text.ToString();
                    posDBAccess.Amount = double.Parse(textbox_Amount.Text.ToString());
                    posDBAccess.SavePayment();
                    posDBAccess.UpdatePayments(dataGridView_CurrentStatus.CurrentRow.Cells[0].Value.ToString(), double.Parse(textbox_Amount.Text));
                    MessageBox.Show("Payments successfully updated.");
                }
                else
                {
                    dr = MessageBox.Show("An error has occured.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            ViewPaymentHistory();
            ViewHistoryDatagrid();
            panel_Payment.Hide();

        }
        public void ViewPaymentHistory()
        {
            dataGridView_PaymentHistory.Rows.Clear();
            DataTable dt = history.ViewPaymentsHistory(dataGridView_CurrentStatus.CurrentRow.Cells[0].Value.ToString());
            for (int index = 0; index < dt.Rows.Count; index++)
            {
                string datepaid = dt.Rows[index]["datepaid"].ToString();
                string transid = dt.Rows[index]["transactionid"].ToString();
                string paymentmethod = dt.Rows[index]["paymentmethod"].ToString();
                string bank = dt.Rows[index]["bankname"].ToString();
                string accountno = dt.Rows[index]["accountnumber"].ToString();
                string checkno = dt.Rows[index]["checknumber"].ToString();
                string name = dt.Rows[index]["checkname"].ToString();
                double amount = double.Parse(dt.Rows[index]["amount"].ToString());
                dataGridView_PaymentHistory.Rows.Add(datepaid, transid, paymentmethod, bank, accountno, checkno, name, amount);
            }
        }

        private void dataGridView_CurrentStatus_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ViewPaymentHistory();
        }

        private void button_GenerateInvoice_Click(object sender, EventArgs e)
        {
            Invoice invoice = new Invoice();
            invoice.Transid = dataGridView_CurrentStatus.CurrentRow.Cells[0].Value.ToString();
            invoice.Show();
            
        }

        private void textbox_Amount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsPunctuation(e.KeyChar) || char.IsSymbol(e.KeyChar) || char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}