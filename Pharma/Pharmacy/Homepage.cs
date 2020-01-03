using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pharmacy
{
    public partial class Homepage : Form
    {
       public Account user;
        ItemDatabaseAccess Ida = new ItemDatabaseAccess();
        List<Item> items;
        public Homepage()
        {
            InitializeComponent();
            items = Ida.getAllItemThreshHold();
            if (items.Count == 0)
            {
                StockLabel.Visible = true;
                dataGridStocks.Visible = false;
            }
            else 
            {
                StockLabel.Visible = false;
                dataGridStocks.Visible = true;
                FillData();
            }
        }
     

        public void FillData()
        {

         //   items = Ida.getAllItemThreshHold();
            dataGridStocks.DataSource = items;
        }
        private void Homepage_Load(object sender, EventArgs e)
        {
   //         label2.Text = "Welcome, "+user.FirstName;
        }

        private void button_Inventory_MouseEnter(object sender, EventArgs e)
        {
            panel_inventory.BackColor = Color.SteelBlue;
        }

        private void button_Inventory_MouseLeave(object sender, EventArgs e)
        {
            panel_inventory.BackColor = Color.FromArgb(64, 64, 64);
        }

        private void button_Sales_MouseEnter(object sender, EventArgs e)
        {
            panel_sales.BackColor = Color.SteelBlue;
        }

        private void button_Sales_MouseLeave(object sender, EventArgs e)
        {
            panel_sales.BackColor = Color.FromArgb(64, 64, 64);
        }

        private void button_Pos_MouseEnter(object sender, EventArgs e)
        {
            panel_pos.BackColor = Color.SteelBlue;
        }

        private void button_Pos_MouseLeave(object sender, EventArgs e)
        {
            panel_pos.BackColor = Color.FromArgb(64, 64, 64);
        }

        private void button_Accounts_MouseEnter(object sender, EventArgs e)
        {
            panel_accounts.BackColor = Color.SteelBlue;
        }

        private void button_Accounts_MouseLeave(object sender, EventArgs e)
        {
            panel_accounts.BackColor = Color.FromArgb(64, 64, 64);
        }

        private void button_Inventory_Click(object sender, EventArgs e)
        {
            Inventory inventory = new Inventory();
            inventory.user = user;
            inventory.Show();
            
            this.Hide();
        }

        private void panel13_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label_Homepage_minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        // MINIMIZING FLICKER - REDUCING THE FLICKER WHEN OPENING FORMS, PANEL, ETC.
        int originalExStyle = -1;
        bool enableFormLevelDoubleBuffering = true;

        protected override CreateParams CreateParams
        {
            get
            {
                if (originalExStyle == -1)
                    originalExStyle = base.CreateParams.ExStyle;

                CreateParams cp = base.CreateParams;
                if (enableFormLevelDoubleBuffering)
                    cp.ExStyle |= 0x02000000;   // WS_EX_COMPOSITED
                else
                    cp.ExStyle = originalExStyle;

                return cp;
            }
        }
        // END - MINIMIZING FLICKER


        private void label_Homepage_close_MouseEnter(object sender, EventArgs e)
        {
        }

        private void button_Pos_Click(object sender, EventArgs e)
        {
            PharmaPOS pharmapos = new PharmaPOS();
            pharmapos.Show();
            this.Hide();

            

        }

        private void button_Accounts_Click(object sender, EventArgs e)
        {
            Accounts accounts = new Accounts();
            accounts.Show();
            accounts.user = user;
            this.Hide();
        }

        private void button_Sales_Click(object sender, EventArgs e)
        {
            SalesReceivables sales = new SalesReceivables();
            sales.Show();
            
        }

        private void label_POS_Close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button_Receivables_Click(object sender, EventArgs e)
        {
            SalesReceivables receivables = new SalesReceivables();
            receivables.Show();
            this.Hide();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridStocks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public static void SendMail(string recipient, string subject, string body, string attachmentFilename,string from,string password,string to,string server)
        {
            SmtpClient smtpClient = new SmtpClient();
            NetworkCredential basicCredential = new NetworkCredential(from, password);
            MailMessage message = new MailMessage();
            MailAddress fromAddress = new MailAddress(to);

            // setup up the host, increase the timeout to 5 minutes
            smtpClient.Host = server;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = basicCredential;
            smtpClient.Timeout = (60 * 5 * 1000);

            message.From = fromAddress;
            message.Subject = subject;
            message.IsBodyHtml = false;
            message.Body = body;
            message.To.Add(recipient);

            if (attachmentFilename != null)
                message.Attachments.Add(new Attachment(attachmentFilename));

            smtpClient.Send(message);
        }
    }
}
