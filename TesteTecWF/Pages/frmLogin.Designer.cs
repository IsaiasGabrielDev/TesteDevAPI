namespace TesteTecWF.Pages
{
    partial class frmLogin
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
            btnLogin = new Button();
            lnkRegister = new LinkLabel();
            textEmail = new TextBox();
            textPassword = new TextBox();
            SuspendLayout();
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.Honeydew;
            btnLogin.ForeColor = Color.Black;
            btnLogin.Location = new Point(259, 246);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(261, 29);
            btnLogin.TabIndex = 2;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // lnkRegister
            // 
            lnkRegister.AutoSize = true;
            lnkRegister.Font = new Font("Segoe UI", 12F);
            lnkRegister.LinkColor = Color.Honeydew;
            lnkRegister.Location = new Point(259, 278);
            lnkRegister.Name = "lnkRegister";
            lnkRegister.Size = new Size(115, 28);
            lnkRegister.TabIndex = 3;
            lnkRegister.TabStop = true;
            lnkRegister.Text = "Registrar-se";
            lnkRegister.LinkClicked += lnkRegister_LinkClicked;
            // 
            // textEmail
            // 
            textEmail.Location = new Point(259, 119);
            textEmail.Name = "textEmail";
            textEmail.PlaceholderText = "Email";
            textEmail.Size = new Size(261, 27);
            textEmail.TabIndex = 4;
            // 
            // textPassword
            // 
            textPassword.Location = new Point(259, 187);
            textPassword.Name = "textPassword";
            textPassword.PlaceholderText = "Senha";
            textPassword.Size = new Size(261, 27);
            textPassword.TabIndex = 5;
            textPassword.UseSystemPasswordChar = true;
            // 
            // frmLogin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkGray;
            ClientSize = new Size(800, 450);
            Controls.Add(textPassword);
            Controls.Add(textEmail);
            Controls.Add(lnkRegister);
            Controls.Add(btnLogin);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmLogin";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnLogin;
        private LinkLabel lnkRegister;
        private TextBox textEmail;
        private TextBox textPassword;
    }
}