namespace library
{
    partial class ListBooks
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
            this.components = new System.ComponentModel.Container();
            this.dgvListBook = new System.Windows.Forms.DataGridView();
            this.bsWork = new System.Windows.Forms.BindingSource(this.components);
            this.library5DataSet = new library.library5DataSet();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.worksTableAdapter = new library.library5DataSetTableAdapters.WorksTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListBook)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsWork)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.library5DataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvListBook
            // 
            this.dgvListBook.AllowUserToAddRows = false;
            this.dgvListBook.AllowUserToDeleteRows = false;
            this.dgvListBook.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListBook.Location = new System.Drawing.Point(8, 34);
            this.dgvListBook.Name = "dgvListBook";
            this.dgvListBook.ReadOnly = true;
            this.dgvListBook.Size = new System.Drawing.Size(496, 150);
            this.dgvListBook.TabIndex = 0;
            this.dgvListBook.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // bsWork
            // 
            this.bsWork.DataMember = "Works";
            this.bsWork.DataSource = this.library5DataSet;
            // 
            // library5DataSet
            // 
            this.library5DataSet.DataSetName = "library5DataSet";
            this.library5DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(92, 187);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(281, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Нажмите два раза на книгу, которую хотите выбрать:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Найти книгу:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(127, 8);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(377, 20);
            this.textBox1.TabIndex = 13;
            // 
            // worksTableAdapter
            // 
            this.worksTableAdapter.ClearBeforeFill = true;
            // 
            // ListBooks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 209);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvListBook);
            this.Name = "ListBooks";
            this.Text = "ListBooks";
            this.Load += new System.EventHandler(this.ListBooks_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListBook)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsWork)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.library5DataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvListBook;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.BindingSource bsWork;
        private library5DataSet library5DataSet;
        private library5DataSetTableAdapters.WorksTableAdapter worksTableAdapter;
    }
}