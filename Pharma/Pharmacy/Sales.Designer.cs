namespace Pharmacy
{
    partial class Sales
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dtp_SalesTo = new System.Windows.Forms.DateTimePicker();
            this.button_ViewSalesReport = new System.Windows.Forms.Button();
            this.panel9 = new System.Windows.Forms.Panel();
            this.dtp_SalesFrom = new System.Windows.Forms.DateTimePicker();
            this.label_Homepage_close = new System.Windows.Forms.Label();
            this.SalesReportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel9.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.button_ViewSalesReport);
            this.panel1.Controls.Add(this.panel9);
            this.panel1.Controls.Add(this.label_Homepage_close);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1366, 130);
            this.panel1.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.dtp_SalesTo);
            this.panel2.Location = new System.Drawing.Point(313, 49);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(263, 33);
            this.panel2.TabIndex = 68;
            // 
            // dtp_SalesTo
            // 
            this.dtp_SalesTo.Location = new System.Drawing.Point(9, 6);
            this.dtp_SalesTo.Name = "dtp_SalesTo";
            this.dtp_SalesTo.Size = new System.Drawing.Size(244, 20);
            this.dtp_SalesTo.TabIndex = 67;
            // 
            // button_ViewSalesReport
            // 
            this.button_ViewSalesReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button_ViewSalesReport.FlatAppearance.BorderSize = 0;
            this.button_ViewSalesReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_ViewSalesReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_ViewSalesReport.ForeColor = System.Drawing.Color.White;
            this.button_ViewSalesReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_ViewSalesReport.Location = new System.Drawing.Point(598, 47);
            this.button_ViewSalesReport.Name = "button_ViewSalesReport";
            this.button_ViewSalesReport.Size = new System.Drawing.Size(203, 41);
            this.button_ViewSalesReport.TabIndex = 36;
            this.button_ViewSalesReport.Text = "View Report";
            this.button_ViewSalesReport.UseVisualStyleBackColor = false;
            this.button_ViewSalesReport.Click += new System.EventHandler(this.button_ViewSalesReport_Click);
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.White;
            this.panel9.Controls.Add(this.dtp_SalesFrom);
            this.panel9.Location = new System.Drawing.Point(28, 49);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(263, 33);
            this.panel9.TabIndex = 32;
            // 
            // dtp_SalesFrom
            // 
            this.dtp_SalesFrom.Location = new System.Drawing.Point(9, 6);
            this.dtp_SalesFrom.Name = "dtp_SalesFrom";
            this.dtp_SalesFrom.Size = new System.Drawing.Size(244, 20);
            this.dtp_SalesFrom.TabIndex = 67;
            // 
            // label_Homepage_close
            // 
            this.label_Homepage_close.AutoSize = true;
            this.label_Homepage_close.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Homepage_close.ForeColor = System.Drawing.Color.White;
            this.label_Homepage_close.Location = new System.Drawing.Point(1334, 11);
            this.label_Homepage_close.Name = "label_Homepage_close";
            this.label_Homepage_close.Size = new System.Drawing.Size(20, 20);
            this.label_Homepage_close.TabIndex = 7;
            this.label_Homepage_close.Text = "X";
            this.label_Homepage_close.Click += new System.EventHandler(this.label_Homepage_close_Click);
            // 
            // SalesReportViewer
            // 
            this.SalesReportViewer.ActiveViewIndex = -1;
            this.SalesReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SalesReportViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.SalesReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SalesReportViewer.Location = new System.Drawing.Point(0, 130);
            this.SalesReportViewer.Name = "SalesReportViewer";
            this.SalesReportViewer.Size = new System.Drawing.Size(1366, 638);
            this.SalesReportViewer.TabIndex = 3;
            // 
            // Sales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1366, 768);
            this.Controls.Add(this.SalesReportViewer);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Sales";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label_Homepage_close;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer SalesReportViewer;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DateTimePicker dtp_SalesTo;
        private System.Windows.Forms.Button button_ViewSalesReport;
        private System.Windows.Forms.DateTimePicker dtp_SalesFrom;
    }
}

