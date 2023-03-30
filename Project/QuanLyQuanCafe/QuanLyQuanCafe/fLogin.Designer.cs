namespace QuanLyQuanCafe
{
    partial class fLogin
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txbPassWord = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txbLogin = new System.Windows.Forms.TextBox();
            this.lbLogin = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnLogin);
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(672, 199);
            this.panel1.TabIndex = 0;
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.GreenYellow;
            this.btnLogin.Location = new System.Drawing.Point(397, 131);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(94, 29);
            this.btnLogin.TabIndex = 3;
            this.btnLogin.Text = "Đăng nhập";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Red;
            this.btnExit.Location = new System.Drawing.Point(524, 131);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(94, 29);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "Thoát";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txbPassWord);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Location = new System.Drawing.Point(3, 67);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(664, 58);
            this.panel3.TabIndex = 2;
            // 
            // txbPassWord
            // 
            this.txbPassWord.Location = new System.Drawing.Point(168, 12);
            this.txbPassWord.Name = "txbPassWord";
            this.txbPassWord.Size = new System.Drawing.Size(489, 27);
            this.txbPassWord.TabIndex = 2;
            this.txbPassWord.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(3, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mật khẩu:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txbLogin);
            this.panel2.Controls.Add(this.lbLogin);
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(664, 58);
            this.panel2.TabIndex = 0;
            // 
            // txbLogin
            // 
            this.txbLogin.Location = new System.Drawing.Point(168, 12);
            this.txbLogin.Name = "txbLogin";
            this.txbLogin.Size = new System.Drawing.Size(489, 27);
            this.txbLogin.TabIndex = 1;
            // 
            // lbLogin
            // 
            this.lbLogin.AutoSize = true;
            this.lbLogin.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbLogin.Location = new System.Drawing.Point(3, 12);
            this.lbLogin.Name = "lbLogin";
            this.lbLogin.Size = new System.Drawing.Size(159, 24);
            this.lbLogin.TabIndex = 0;
            this.lbLogin.Text = "Tên đăng nhập:";
            // 
            // fLogin
            // 
            this.AcceptButton = this.btnLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(687, 219);
            this.Controls.Add(this.panel1);
            this.Name = "fLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng nhập";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fLogin_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Panel panel3;
        private TextBox txbPassWord;
        private Label label1;
        private Panel panel2;
        private TextBox txbLogin;
        private Label lbLogin;
        private Button btnLogin;
        private Button btnExit;
    }
}