namespace TesteTecWF.Pages
{
    partial class frmCategoryDetails
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
            lblVoltar = new Label();
            panel1 = new Panel();
            btnDeleteProduct = new Button();
            btnSalvar = new Button();
            txtName = new TextBox();
            label2 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // lblVoltar
            // 
            lblVoltar.AutoSize = true;
            lblVoltar.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblVoltar.Location = new Point(719, 413);
            lblVoltar.Name = "lblVoltar";
            lblVoltar.Size = new Size(69, 28);
            lblVoltar.TabIndex = 2;
            lblVoltar.Text = "Voltar";
            lblVoltar.Click += lblVoltar_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnDeleteProduct);
            panel1.Controls.Add(btnSalvar);
            panel1.Controls.Add(txtName);
            panel1.Controls.Add(label2);
            panel1.Location = new Point(216, 142);
            panel1.Name = "panel1";
            panel1.Size = new Size(342, 167);
            panel1.TabIndex = 3;
            // 
            // btnDeleteProduct
            // 
            btnDeleteProduct.ForeColor = SystemColors.ActiveCaptionText;
            btnDeleteProduct.Location = new Point(2, 128);
            btnDeleteProduct.Name = "btnDeleteProduct";
            btnDeleteProduct.Size = new Size(336, 29);
            btnDeleteProduct.TabIndex = 8;
            btnDeleteProduct.Text = "Deletar";
            btnDeleteProduct.UseVisualStyleBackColor = true;
            btnDeleteProduct.Visible = false;
            btnDeleteProduct.Click += btnDeleteProduct_Click;
            // 
            // btnSalvar
            // 
            btnSalvar.ForeColor = SystemColors.ActiveCaptionText;
            btnSalvar.Location = new Point(2, 93);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(336, 29);
            btnSalvar.TabIndex = 6;
            btnSalvar.Text = "Salvar";
            btnSalvar.UseVisualStyleBackColor = true;
            btnSalvar.Click += btnSalvar_Click;
            // 
            // txtName
            // 
            txtName.Location = new Point(0, 26);
            txtName.Name = "txtName";
            txtName.Size = new Size(336, 27);
            txtName.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(2, 3);
            label2.Name = "label2";
            label2.Size = new Size(140, 20);
            label2.TabIndex = 2;
            label2.Text = "Nome da Categoria";
            // 
            // frmCategoryDetails
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkGray;
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            Controls.Add(lblVoltar);
            ForeColor = SystemColors.Control;
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmCategoryDetails";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmCategoryDetails";
            Load += frmCategoryDetails_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblVoltar;
        private Panel panel1;
        private Button btnDeleteProduct;
        private Button btnSalvar;
        private TextBox txtName;
        private Label label2;
    }
}