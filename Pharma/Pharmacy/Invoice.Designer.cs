namespace Pharmacy
{
    partial class Invoice
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
            this.label_Homepage_close = new System.Windows.Forms.Label();
            this.InvoiceReportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.label_Homepage_close);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1366, 130);
            this.panel1.TabIndex = 2;
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
            // InvoiceReportViewer
            // 
            this.InvoiceReportViewer.ActiveViewIndex = -1;
            this.InvoiceReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.InvoiceReportViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.InvoiceReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InvoiceReportViewer.Location = new System.Drawing.Point(0, 130);
            this.InvoiceReportViewer.Name = "InvoiceReportViewer";
            this.InvoiceReportViewer.Size = new System.Drawing.Size(1366, 638);
            this.InvoiceReportViewer.TabIndex = 3;
            // 
            // Invoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1366, 768);
            this.Controls.Add(this.InvoiceReportViewer);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Invoice";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Invoice_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label_Homepage_close;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer InvoiceReportViewer;
    }
}

