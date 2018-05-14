namespace library
{
    partial class ListWork
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
            this.label5 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvListBook = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListBook)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Найти произведение:";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(131, 9);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(392, 20);
            this.textBox1.TabIndex = 17;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(102, 188);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(324, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Нажмите два раза на произведение, которое хотите выбрать:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // dgvListBook
            // 
            this.dgvListBook.AllowUserToAddRows = false;
            this.dgvListBook.AllowUserToDeleteRows = false;
            this.dgvListBook.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListBook.Location = new System.Drawing.Point(12, 35);
            this.dgvListBook.Name = "dgvListBook";
            this.dgvListBook.ReadOnly = true;
            this.dgvListBook.Size = new System.Drawing.Size(511, 150);
            this.dgvListBook.TabIndex = 15;
            this.dgvListBook.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListBook_CellContentClick);
            // 
            // ListWork
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(529, 210);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvListBook);
            this.Name = "ListWork";
            this.Text = "ListWork";
            this.Load += new System.EventHandler(this.ListWork_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListBook)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvListBook;
    }
}