using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace Pharmacy
{
    public partial class Invoice : Form
    {
        public Invoice()
        {
            InitializeComponent();
          
        }
        private SqlCommand cmd;
        private string query;
        private SqlDataAdapter sda;
        private DataTable dt;
        private SqlConnection conn = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=Inventory;Trusted_Connection=True;Integrated Security = true");

        private string transid;

        public string Transid { get => transid; set => transid = value; }

        private void label_Homepage_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

        private void Invoice_Load(object sender, EventArgs e)
        {
            conn.Open();
            //  cmd = new SqlCommand("select stud_id, stud_gradelevel, stud_section, stud_firstname,stud_age, stud_middlename, stud_lastname, stud_gender, stud_datetime from table_student where convert (datetime,stud_datetime) >= '" + dateTimePicker1.Value.ToShortDateString() + "' and convert (datetime,stud_datetime) <= '" + dateTimePicker2.Value.ToShortDateString() + "';", conn);
            //cmd = new SqlCommand("select Receivables.transactionid, receivables.customerid, receivables.firstname, receivables.lastname, receivables.company, postransaction.quantity, postransaction.brandname, POSTransaction.genericname, POSTransaction.price, POSTransaction.total from receivables inner join postransaction on receivables.transactionid=postransaction.transactionID where receivables.transactionid='" + transid + "';", conn);
            cmd = new SqlCommand("select * from receivables;", conn);

            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);

            InvoiceReport invoicereport = new InvoiceReport();
            invoicereport.SetDataSource(dt);
            InvoiceReportViewer.ReportSource = invoicereport;
            InvoiceReportViewer.Refresh();
            conn.Close();
        }
    }
}
