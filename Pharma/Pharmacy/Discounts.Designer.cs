namespace Pharmacy
{
    partial class Discounts
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
            this.label_Close = new System.Windows.Forms.Label();
            this.label_AddProduct_close = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.textbox_DiscountPercentage = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel12 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonAddDiscount = new System.Windows.Forms.Button();
            this.buttonDeleteDiscount = new System.Windows.Forms.Button();
            this.button_ClearDiscount = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.textbox_DiscountType = new System.Windows.Forms.TextBox();
            this.dataGridView_Discounts = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel12.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Discounts)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Controls.Add(this.label_Close);
            this.panel1.Controls.Add(this.label_AddProduct_close);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(597, 54);
            this.panel1.TabIndex = 3;
            // 
            // label_Close
            // 
            this.label_Close.AutoSize = true;
            this.label_Close.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Close.ForeColor = System.Drawing.Color.Black;
            this.label_Close.Location = new System.Drawing.Point(565, 20);
            this.label_Close.Name = "label_Close";
            this.label_Close.Size = new System.Drawing.Size(20, 20);
            this.label_Close.TabIndex = 8;
            this.label_Close.Text = "X";
            this.label_Close.Click += new System.EventHandler(this.label_Close_Click);
            // 
            // label_AddProduct_close
            // 
            this.label_AddProduct_close.AutoSize = true;
            this.label_AddProduct_close.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_AddProduct_close.ForeColor = System.Drawing.Color.Black;
            this.label_AddProduct_close.Location = new System.Drawing.Point(777, 15);
            this.label_AddProduct_close.Name = "label_AddProduct_close";
            this.label_AddProduct_close.Size = new System.Drawing.Size(20, 20);
            this.label_AddProduct_close.TabIndex = 7;
            this.label_AddProduct_close.Text = "X";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.textbox_DiscountPercentage);
            this.panel2.Location = new System.Drawing.Point(219, 213);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(286, 33);
            this.panel2.TabIndex = 6;
            // 
            // textbox_DiscountPercentage
            // 
            this.textbox_DiscountPercentage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textbox_DiscountPercentage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textbox_DiscountPercentage.Location = new System.Drawing.Point(15, 9);
            this.textbox_DiscountPercentage.Name = "textbox_DiscountPercentage";
            this.textbox_DiscountPercentage.Size = new System.Drawing.Size(255, 16);
            this.textbox_DiscountPercentage.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(44, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "DISCOUNTS";
            // 
            // panel12
            // 
            this.panel12.BackColor = System.Drawing.Color.Teal;
            this.panel12.Controls.Add(this.label3);
            this.panel12.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel12.Location = new System.Drawing.Point(0, 54);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(597, 66);
            this.panel12.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(77, 221);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "DISCOUNT(%)";
            // 
            // buttonAddDiscount
            // 
            this.buttonAddDiscount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonAddDiscount.FlatAppearance.BorderSize = 0;
            this.buttonAddDiscount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddDiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAddDiscount.ForeColor = System.Drawing.Color.White;
            this.buttonAddDiscount.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonAddDiscount.Location = new System.Drawing.Point(219, 266);
            this.buttonAddDiscount.Name = "buttonAddDiscount";
            this.buttonAddDiscount.Size = new System.Drawing.Size(85, 41);
            this.buttonAddDiscount.TabIndex = 22;
            this.buttonAddDiscount.Text = "ADD";
            this.buttonAddDiscount.UseVisualStyleBackColor = false;
            this.buttonAddDiscount.Click += new System.EventHandler(this.buttonAddDiscount_Click);
            // 
            // buttonDeleteDiscount
            // 
            this.buttonDeleteDiscount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonDeleteDiscount.FlatAppearance.BorderSize = 0;
            this.buttonDeleteDiscount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDeleteDiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDeleteDiscount.ForeColor = System.Drawing.Color.White;
            this.buttonDeleteDiscount.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonDeleteDiscount.Location = new System.Drawing.Point(420, 266);
            this.buttonDeleteDiscount.Name = "buttonDeleteDiscount";
            this.buttonDeleteDiscount.Size = new System.Drawing.Size(85, 41);
            this.buttonDeleteDiscount.TabIndex = 23;
            this.buttonDeleteDiscount.Text = "DELETE";
            this.buttonDeleteDiscount.UseVisualStyleBackColor = false;
            // 
            // button_ClearDiscount
            // 
            this.button_ClearDiscount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button_ClearDiscount.FlatAppearance.BorderSize = 0;
            this.button_ClearDiscount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_ClearDiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_ClearDiscount.ForeColor = System.Drawing.Color.White;
            this.button_ClearDiscount.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_ClearDiscount.Location = new System.Drawing.Point(319, 266);
            this.button_ClearDiscount.Name = "button_ClearDiscount";
            this.button_ClearDiscount.Size = new System.Drawing.Size(85, 41);
            this.button_ClearDiscount.TabIndex = 24;
            this.button_ClearDiscount.Text = "CLEAR";
            this.button_ClearDiscount.UseVisualStyleBackColor = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DimGray;
            this.label5.Location = new System.Drawing.Point(76, 182);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 17);
            this.label5.TabIndex = 28;
            this.label5.Text = "DISCOUNT TYPE";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.White;
            this.panel5.Controls.Add(this.textbox_DiscountType);
            this.panel5.Location = new System.Drawing.Point(218, 174);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(286, 33);
            this.panel5.TabIndex = 27;
            // 
            // textbox_DiscountType
            // 
            this.textbox_DiscountType.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textbox_DiscountType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textbox_DiscountType.Location = new System.Drawing.Point(15, 9);
            this.textbox_DiscountType.Name = "textbox_DiscountType";
            this.textbox_DiscountType.Size = new System.Drawing.Size(255, 16);
            this.textbox_DiscountType.TabIndex = 0;
            // 
            // dataGridView_Discounts
            // 
            this.dataGridView_Discounts.AllowUserToAddRows = false;
            this.dataGridView_Discounts.AllowUserToDeleteRows = false;
            this.dataGridView_Discounts.AllowUserToResizeColumns = false;
            this.dataGridView_Discounts.AllowUserToResizeRows = false;
            this.dataGridView_Discounts.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView_Discounts.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView_Discounts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Discounts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            this.dataGridView_Discounts.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dataGridView_Discounts.Location = new System.Drawing.Point(80, 340);
            this.dataGridView_Discounts.Name = "dataGridView_Discounts";
            this.dataGridView_Discounts.ReadOnly = true;
            this.dataGridView_Discounts.RowHeadersVisible = false;
            this.dataGridView_Discounts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_Discounts.Size = new System.Drawing.Size(425, 198);
            this.dataGridView_Discounts.TabIndex = 29;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 40;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Discount Type";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 150;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Discount(%)";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 150;
            // 
            // Discounts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(597, 566);
            this.Controls.Add(this.dataGridView_Discounts);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.button_ClearDiscount);
            this.Controls.Add(this.buttonDeleteDiscount);
            this.Controls.Add(this.buttonAddDiscount);
            this.Controls.Add(this.panel12);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(200, 0);
            this.Name = "Discounts";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Discounts_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel12.ResumeLayout(false);
            this.panel12.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Discounts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label_AddProduct_close;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox textbox_DiscountPercentage;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonAddDiscount;
        private System.Windows.Forms.Button buttonDeleteDiscount;
        private System.Windows.Forms.Button button_ClearDiscount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox textbox_DiscountType;
        private System.Windows.Forms.Label label_Close;
        private System.Windows.Forms.DataGridView dataGridView_Discounts;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
    }
}

