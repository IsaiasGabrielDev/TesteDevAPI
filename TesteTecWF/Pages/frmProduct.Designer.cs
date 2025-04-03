namespace TesteTecWF.Pages
{
    partial class frmProduct
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
            panel1 = new Panel();
            btnDeleteProduct = new Button();
            txtPrice = new TextBox();
            btnSalvar = new Button();
            label3 = new Label();
            txtName = new TextBox();
            label2 = new Label();
            label1 = new Label();
            cmbCategories = new ComboBox();
            lblVoltar = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(btnDeleteProduct);
            panel1.Controls.Add(txtPrice);
            panel1.Controls.Add(btnSalvar);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(txtName);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(cmbCategories);
            panel1.Location = new Point(208, 71);
            panel1.Name = "panel1";
            panel1.Size = new Size(342, 302);
            panel1.TabIndex = 0;
            // 
            // btnDeleteProduct
            // 
            btnDeleteProduct.ForeColor = SystemColors.ActiveCaptionText;
            btnDeleteProduct.Location = new Point(3, 260);
            btnDeleteProduct.Name = "btnDeleteProduct";
            btnDeleteProduct.Size = new Size(336, 29);
            btnDeleteProduct.TabIndex = 8;
            btnDeleteProduct.Text = "Deletar";
            btnDeleteProduct.UseVisualStyleBackColor = true;
            btnDeleteProduct.Visible = false;
            btnDeleteProduct.Click += btnDeleteProduct_Click;
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(3, 171);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(336, 27);
            txtPrice.TabIndex = 7;
            txtPrice.KeyPress += txtPrice_KeyPress;
            txtPrice.Leave += txtPrice_Leave;
            // 
            // btnSalvar
            // 
            btnSalvar.ForeColor = SystemColors.ActiveCaptionText;
            btnSalvar.Location = new Point(3, 225);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(336, 29);
            btnSalvar.TabIndex = 6;
            btnSalvar.Text = "Salvar";
            btnSalvar.UseVisualStyleBackColor = true;
            btnSalvar.Click += btnSalvar_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(3, 148);
            label3.Name = "label3";
            label3.Size = new Size(46, 20);
            label3.TabIndex = 4;
            label3.Text = "Preço";
            // 
            // txtName
            // 
            txtName.Location = new Point(3, 98);
            txtName.Name = "txtName";
            txtName.Size = new Size(336, 27);
            txtName.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 75);
            label2.Name = "label2";
            label2.Size = new Size(129, 20);
            label2.TabIndex = 2;
            label2.Text = "Nome do Produto";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 3);
            label1.Name = "label1";
            label1.Size = new Size(74, 20);
            label1.TabIndex = 1;
            label1.Text = "Categoria";
            // 
            // cmbCategories
            // 
            cmbCategories.FormattingEnabled = true;
            cmbCategories.Location = new Point(3, 26);
            cmbCategories.Name = "cmbCategories";
            cmbCategories.Size = new Size(336, 28);
            cmbCategories.TabIndex = 0;
            // 
            // lblVoltar
            // 
            lblVoltar.AutoSize = true;
            lblVoltar.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblVoltar.Location = new Point(719, 413);
            lblVoltar.Name = "lblVoltar";
            lblVoltar.Size = new Size(69, 28);
            lblVoltar.TabIndex = 1;
            lblVoltar.Text = "Voltar";
            lblVoltar.Click += lblVoltar_Click;
            // 
            // frmProduct
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkGray;
            ClientSize = new Size(800, 450);
            Controls.Add(lblVoltar);
            Controls.Add(panel1);
            ForeColor = SystemColors.Control;
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmProduct";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmProduct";
            Load += frmProduct_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label2;
        private Label label1;
        private ComboBox cmbCategories;
        private Label label3;
        private TextBox txtName;
        private Button btnSalvar;
        private TextBox txtPrice;
        private Label lblVoltar;
        private Button btnDeleteProduct;
    }
}