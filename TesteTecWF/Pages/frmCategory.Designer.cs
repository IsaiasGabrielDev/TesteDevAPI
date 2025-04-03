namespace TesteTecWF.Pages
{
    partial class frmCategory
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
            components = new System.ComponentModel.Container();
            categoryBindingSource = new BindingSource(components);
            btnAddCategory = new Button();
            lblVoltar = new Label();
            dgvCategory = new DataGridView();
            Id = new DataGridViewTextBoxColumn();
            CategoryName = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)categoryBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvCategory).BeginInit();
            SuspendLayout();
            // 
            // categoryBindingSource
            // 
            categoryBindingSource.DataSource = typeof(Models.Category);
            // 
            // btnAddCategory
            // 
            btnAddCategory.BackColor = Color.Honeydew;
            btnAddCategory.ForeColor = Color.Black;
            btnAddCategory.Location = new Point(447, 48);
            btnAddCategory.Name = "btnAddCategory";
            btnAddCategory.Size = new Size(341, 29);
            btnAddCategory.TabIndex = 4;
            btnAddCategory.Text = "Adicionar Categoria";
            btnAddCategory.UseVisualStyleBackColor = false;
            btnAddCategory.Click += btnAddCategory_Click;
            // 
            // lblVoltar
            // 
            lblVoltar.AutoSize = true;
            lblVoltar.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblVoltar.ForeColor = SystemColors.Control;
            lblVoltar.Location = new Point(719, 413);
            lblVoltar.Name = "lblVoltar";
            lblVoltar.Size = new Size(69, 28);
            lblVoltar.TabIndex = 5;
            lblVoltar.Text = "Voltar";
            lblVoltar.Click += lblVoltar_Click;
            // 
            // dgvCategory
            // 
            dgvCategory.AllowUserToAddRows = false;
            dgvCategory.AllowUserToDeleteRows = false;
            dgvCategory.AutoGenerateColumns = false;
            dgvCategory.BackgroundColor = SystemColors.Control;
            dgvCategory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCategory.Columns.AddRange(new DataGridViewColumn[] { Id, CategoryName });
            dgvCategory.DataSource = categoryBindingSource;
            dgvCategory.Location = new Point(12, 48);
            dgvCategory.Name = "dgvCategory";
            dgvCategory.ReadOnly = true;
            dgvCategory.RowHeadersWidth = 51;
            dgvCategory.Size = new Size(329, 355);
            dgvCategory.TabIndex = 6;
            dgvCategory.SelectionChanged += dgvCategory_SelectionChanged;
            // 
            // Id
            // 
            Id.DataPropertyName = "Id";
            Id.HeaderText = "Cód. Categoria";
            Id.MinimumWidth = 6;
            Id.Name = "Id";
            Id.ReadOnly = true;
            Id.Width = 150;
            // 
            // CategoryName
            // 
            CategoryName.DataPropertyName = "Name";
            CategoryName.HeaderText = "Nome";
            CategoryName.MinimumWidth = 6;
            CategoryName.Name = "CategoryName";
            CategoryName.ReadOnly = true;
            CategoryName.Width = 125;
            // 
            // frmCategory
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkGray;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvCategory);
            Controls.Add(lblVoltar);
            Controls.Add(btnAddCategory);
            ForeColor = SystemColors.ActiveCaptionText;
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmCategory";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmCategory";
            Load += frmCategory_Load;
            ((System.ComponentModel.ISupportInitialize)categoryBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvCategory).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private BindingSource categoryBindingSource;
        private Button btnAddCategory;
        private Label lblVoltar;
        private DataGridView dgvCategory;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn CategoryName;
    }
}