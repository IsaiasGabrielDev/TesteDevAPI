namespace TesteTecWF.Pages
{
    partial class frmRegister
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
            btnRegister = new Button();
            lnkLogin = new LinkLabel();
            textName = new TextBox();
            textEmail = new TextBox();
            textPassword = new TextBox();
            SuspendLayout();
            // 
            // btnRegister
            // 
            btnRegister.BackColor = Color.Honeydew;
            btnRegister.ForeColor = Color.Black;
            btnRegister.Location = new Point(256, 271);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(261, 29);
            btnRegister.TabIndex = 5;
            btnRegister.Text = "Cadastrar";
            btnRegister.UseVisualStyleBackColor = false;
            btnRegister.Click += btnRegister_Click;
            // 
            // lnkLogin
            // 
            lnkLogin.AutoSize = true;
            lnkLogin.Font = new Font("Segoe UI", 12F);
            lnkLogin.LinkColor = Color.Honeydew;
            lnkLogin.Location = new Point(256, 303);
            lnkLogin.Name = "lnkLogin";
            lnkLogin.Size = new Size(61, 28);
            lnkLogin.TabIndex = 7;
            lnkLogin.TabStop = true;
            lnkLogin.Text = "Login";
            lnkLogin.LinkClicked += lnkLogin_LinkClicked;
            // 
            // textName
            // 
            textName.Location = new Point(256, 121);
            textName.Name = "textName";
            textName.PlaceholderText = "Nome";
            textName.Size = new Size(261, 27);
            textName.TabIndex = 8;
            // 
            // textEmail
            // 
            textEmail.Location = new Point(256, 173);
            textEmail.Name = "textEmail";
            textEmail.PlaceholderText = "Email";
            textEmail.Size = new Size(261, 27);
            textEmail.TabIndex = 9;
            // 
            // textPassword
            // 
            textPassword.Location = new Point(256, 225);
            textPassword.Name = "textPassword";
            textPassword.PlaceholderText = "Senha";
            textPassword.Size = new Size(261, 27);
            textPassword.TabIndex = 10;
            textPassword.UseSystemPasswordChar = true;
            // 
            // frmRegister
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkGray;
            ClientSize = new Size(800, 450);
            Controls.Add(textPassword);
            Controls.Add(textEmail);
            Controls.Add(textName);
            Controls.Add(lnkLogin);
            Controls.Add(btnRegister);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmRegister";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmRegister";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnRegister;
        private LinkLabel lnkLogin;
        private TextBox textName;
        private TextBox textEmail;
        private TextBox textPassword;
    }
}