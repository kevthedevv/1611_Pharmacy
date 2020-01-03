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
    public partial class Sales : Form
    {
        public Sales()
        {
            InitializeComponent();
          
        }
        private SqlCommand cmd;
        private string query;
        private SqlDataAdapter sda;
        private DataTable dt;
        private SqlConnection conn = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=Inventory;Trusted_Connection=True;Integrated Security = true");

        private void button_ViewSalesReport_Click(object sender, EventArgs e)
        {
            conn.Open();
            //  cmd = new SqlCommand("select stud_id, stud_gradelevel, stud_section, stud_firstname,stud_age, stud_middlename, stud_lastname, stud_gender, stud_datetime from table_student where convert (datetime,stud_datetime) >= '" + dateTimePicker1.Value.ToShortDateString() + "' and convert (datetime,stud_datetime) <= '" + dateTimePicker2.Value.ToShortDateString() + "';", conn);
            cmd = new SqlCommand("select transactionid, total, discount, subtotal, vatable, totaldue, cashtender, change, dateandtime from postotalsalepertransaction where dateandtime >='"+ dtp_SalesFrom.Value.ToString() + "' and dateandtime <= '" + dtp_SalesTo.Value.ToString() + "';", conn);
            cmd.CommandType = CommandType.Text;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);

            SalesReport salesreport = new SalesReport();
            salesreport.SetDataSource(dt);
            SalesReportViewer.ReportSource = salesreport;
            SalesReportViewer.Refresh();
            conn.Close();

        }

        private void label_Homepage_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Sales_Load(object sender, EventArgs e)
        {

        }
    }
}
