namespace library
{
    partial class WorkwithBooks
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
            this.btnNEWbook = new System.Windows.Forms.Button();
            this.btnUNbook = new System.Windows.Forms.Button();
            this.btnSafe = new System.Windows.Forms.Button();
            this.btnAuthor = new System.Windows.Forms.Button();
            this.btnPublisher = new System.Windows.Forms.Button();
            this.btnGenre = new System.Windows.Forms.Button();
            this.btnWork = new System.Windows.Forms.Button();
            this.btnBook = new System.Windows.Forms.Button();
            this.btnExemplar = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnNEWbook
            // 
            this.btnNEWbook.Location = new System.Drawing.Point(119, 42);
            this.btnNEWbook.Name = "btnNEWbook";
            this.btnNEWbook.Size = new System.Drawing.Size(113, 23);
            this.btnNEWbook.TabIndex = 34;
            this.btnNEWbook.Text = "Прибывшие книги";
            this.btnNEWbook.UseVisualStyleBackColor = true;
            // 
            // btnUNbook
            // 
            this.btnUNbook.Location = new System.Drawing.Point(119, 13);
            this.btnUNbook.Name = "btnUNbook";
            this.btnUNbook.Size = new System.Drawing.Size(113, 23);
            this.btnUNbook.TabIndex = 33;
            this.btnUNbook.Text = "Выбывшие книги";
            this.btnUNbook.UseVisualStyleBackColor = true;
            // 
            // btnSafe
            // 
            this.btnSafe.Location = new System.Drawing.Point(12, 186);
            this.btnSafe.Name = "btnSafe";
            this.btnSafe.Size = new System.Drawing.Size(101, 23);
            this.btnSafe.TabIndex = 32;
            this.btnSafe.Text = "Книгохранилище";
            this.btnSafe.UseVisualStyleBackColor = true;
            // 
            // btnAuthor
            // 
            this.btnAuthor.Location = new System.Drawing.Point(12, 128);
            this.btnAuthor.Name = "btnAuthor";
            this.btnAuthor.Size = new System.Drawing.Size(101, 23);
            this.btnAuthor.TabIndex = 31;
            this.btnAuthor.Text = "Авторы";
            this.btnAuthor.UseVisualStyleBackColor = true;
            // 
            // btnPublisher
            // 
            this.btnPublisher.Location = new System.Drawing.Point(12, 157);
            this.btnPublisher.Name = "btnPublisher";
            this.btnPublisher.Size = new System.Drawing.Size(101, 23);
            this.btnPublisher.TabIndex = 30;
            this.btnPublisher.Text = "Издательства";
            this.btnPublisher.UseVisualStyleBackColor = true;
            // 
            // btnGenre
            // 
            this.btnGenre.Location = new System.Drawing.Point(12, 99);
            this.btnGenre.Name = "btnGenre";
            this.btnGenre.Size = new System.Drawing.Size(101, 23);
            this.btnGenre.TabIndex = 29;
            this.btnGenre.Text = "Жанры";
            this.btnGenre.UseVisualStyleBackColor = true;
            // 
            // btnWork
            // 
            this.btnWork.Location = new System.Drawing.Point(12, 70);
            this.btnWork.Name = "btnWork";
            this.btnWork.Size = new System.Drawing.Size(101, 23);
            this.btnWork.TabIndex = 28;
            this.btnWork.Text = "Произведения";
            this.btnWork.UseVisualStyleBackColor = true;
            this.btnWork.Click += new System.EventHandler(this.btnWork_Click);
            // 
            // btnBook
            // 
            this.btnBook.Location = new System.Drawing.Point(12, 41);
            this.btnBook.Name = "btnBook";
            this.btnBook.Size = new System.Drawing.Size(101, 23);
            this.btnBook.TabIndex = 27;
            this.btnBook.Text = "Книги";
            this.btnBook.UseVisualStyleBackColor = true;
            this.btnBook.Click += new System.EventHandler(this.btnBook_Click);
            // 
            // btnExemplar
            // 
            this.btnExemplar.Location = new System.Drawing.Point(12, 12);
            this.btnExemplar.Name = "btnExemplar";
            this.btnExemplar.Size = new System.Drawing.Size(101, 23);
            this.btnExemplar.TabIndex = 26;
            this.btnExemplar.Text = "Экземпляры";
            this.btnExemplar.UseVisualStyleBackColor = true;
            this.btnExemplar.Click += new System.EventHandler(this.btnExemplar_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(146, 185);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(86, 23);
            this.btnExit.TabIndex = 35;
            this.btnExit.Text = "Назад";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // WorkwithBooks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(244, 220);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnNEWbook);
            this.Controls.Add(this.btnUNbook);
            this.Controls.Add(this.btnSafe);
            this.Controls.Add(this.btnAuthor);
            this.Controls.Add(this.btnPublisher);
            this.Controls.Add(this.btnGenre);
            this.Controls.Add(this.btnWork);
            this.Controls.Add(this.btnBook);
            this.Controls.Add(this.btnExemplar);
            this.Name = "WorkwithBooks";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WorkwithBooks";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnNEWbook;
        private System.Windows.Forms.Button btnUNbook;
        private System.Windows.Forms.Button btnSafe;
        private System.Windows.Forms.Button btnAuthor;
        private System.Windows.Forms.Button btnPublisher;
        private System.Windows.Forms.Button btnGenre;
        private System.Windows.Forms.Button btnWork;
        private System.Windows.Forms.Button btnBook;
        private System.Windows.Forms.Button btnExemplar;
        private System.Windows.Forms.Button btnExit;
    }
}