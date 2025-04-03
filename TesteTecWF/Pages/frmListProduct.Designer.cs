namespace TesteTecWF.Pages
{
    partial class frmListProduct
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
            dgvProducts = new DataGridView();
            Id = new DataGridViewTextBoxColumn();
            NameProduct = new DataGridViewTextBoxColumn();
            Price = new DataGridViewTextBoxColumn();
            CategoryId = new DataGridViewTextBoxColumn();
            productBindingSource = new BindingSource(components);
            btnAddProduct = new Button();
            lblPageNumber = new Label();
            btnNext = new Label();
            btnPrevious = new Label();
            cmbCategories = new ComboBox();
            btnCategory = new Button();
            btnProductHistoryReport = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
            ((System.ComponentModel.ISupportInitialize)productBindingSource).BeginInit();
            SuspendLayout();
            // 
            // dgvProducts
            // 
            dgvProducts.AllowUserToAddRows = false;
            dgvProducts.AllowUserToDeleteRows = false;
            dgvProducts.AutoGenerateColumns = false;
            dgvProducts.BackgroundColor = SystemColors.Control;
            dgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProducts.Columns.AddRange(new DataGridViewColumn[] { Id, NameProduct, Price, CategoryId });
            dgvProducts.DataSource = productBindingSource;
            dgvProducts.Location = new Point(12, 62);
            dgvProducts.Name = "dgvProducts";
            dgvProducts.ReadOnly = true;
            dgvProducts.RowHeadersWidth = 51;
            dgvProducts.Size = new Size(429, 355);
            dgvProducts.TabIndex = 0;
            dgvProducts.SelectionChanged += dgvProducts_SelectionChanged;
            // 
            // Id
            // 
            Id.DataPropertyName = "Id";
            Id.HeaderText = "Cod. Produto";
            Id.MinimumWidth = 6;
            Id.Name = "Id";
            Id.ReadOnly = true;
            Id.Width = 125;
            // 
            // NameProduct
            // 
            NameProduct.DataPropertyName = "Name";
            NameProduct.HeaderText = "Nome";
            NameProduct.MinimumWidth = 6;
            NameProduct.Name = "NameProduct";
            NameProduct.ReadOnly = true;
            NameProduct.Width = 125;
            // 
            // Price
            // 
            Price.DataPropertyName = "Price";
            Price.HeaderText = "Preço";
            Price.MinimumWidth = 6;
            Price.Name = "Price";
            Price.ReadOnly = true;
            Price.Width = 125;
            // 
            // CategoryId
            // 
            CategoryId.DataPropertyName = "CategoryId";
            CategoryId.HeaderText = "CategoryId";
            CategoryId.MinimumWidth = 6;
            CategoryId.Name = "CategoryId";
            CategoryId.ReadOnly = true;
            CategoryId.Visible = false;
            CategoryId.Width = 125;
            // 
            // productBindingSource
            // 
            productBindingSource.DataSource = typeof(Models.Product);
            // 
            // btnAddProduct
            // 
            btnAddProduct.BackColor = Color.Honeydew;
            btnAddProduct.ForeColor = Color.Black;
            btnAddProduct.Location = new Point(447, 97);
            btnAddProduct.Name = "btnAddProduct";
            btnAddProduct.Size = new Size(341, 29);
            btnAddProduct.TabIndex = 3;
            btnAddProduct.Text = "Adicionar Produto";
            btnAddProduct.UseVisualStyleBackColor = false;
            btnAddProduct.Click += btnAddProduct_Click;
            // 
            // lblPageNumber
            // 
            lblPageNumber.AutoSize = true;
            lblPageNumber.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblPageNumber.ForeColor = SystemColors.Control;
            lblPageNumber.Location = new Point(349, 420);
            lblPageNumber.Name = "lblPageNumber";
            lblPageNumber.Size = new Size(52, 20);
            lblPageNumber.TabIndex = 4;
            lblPageNumber.Text = "1 de 1";
            // 
            // btnNext
            // 
            btnNext.AutoSize = true;
            btnNext.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnNext.ForeColor = SystemColors.Control;
            btnNext.Location = new Point(409, 420);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(20, 20);
            btnNext.TabIndex = 5;
            btnNext.Text = ">";
            btnNext.Click += btnNext_Click;
            // 
            // btnPrevious
            // 
            btnPrevious.AutoSize = true;
            btnPrevious.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnPrevious.ForeColor = SystemColors.Control;
            btnPrevious.Location = new Point(323, 421);
            btnPrevious.Name = "btnPrevious";
            btnPrevious.Size = new Size(20, 20);
            btnPrevious.TabIndex = 6;
            btnPrevious.Text = "<";
            btnPrevious.Click += btnPrevious_Click;
            // 
            // cmbCategories
            // 
            cmbCategories.FormattingEnabled = true;
            cmbCategories.Location = new Point(12, 28);
            cmbCategories.Name = "cmbCategories";
            cmbCategories.Size = new Size(429, 28);
            cmbCategories.TabIndex = 7;
            cmbCategories.SelectedIndexChanged += cmbCategories_SelectedIndexChanged;
            // 
            // btnCategory
            // 
            btnCategory.BackColor = Color.Honeydew;
            btnCategory.ForeColor = Color.Black;
            btnCategory.Location = new Point(447, 62);
            btnCategory.Name = "btnCategory";
            btnCategory.Size = new Size(341, 29);
            btnCategory.TabIndex = 8;
            btnCategory.Text = "Gerenciar Categorias";
            btnCategory.UseVisualStyleBackColor = false;
            btnCategory.Click += btnCategory_Click;
            // 
            // btnProductHistoryReport
            // 
            btnProductHistoryReport.BackColor = Color.Honeydew;
            btnProductHistoryReport.ForeColor = Color.Black;
            btnProductHistoryReport.Location = new Point(447, 132);
            btnProductHistoryReport.Name = "btnProductHistoryReport";
            btnProductHistoryReport.Size = new Size(341, 29);
            btnProductHistoryReport.TabIndex = 9;
            btnProductHistoryReport.Text = "Relatório Histórico de Produto";
            btnProductHistoryReport.UseVisualStyleBackColor = false;
            // 
            // frmListProduct
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkGray;
            ClientSize = new Size(800, 450);
            Controls.Add(btnProductHistoryReport);
            Controls.Add(btnCategory);
            Controls.Add(cmbCategories);
            Controls.Add(btnPrevious);
            Controls.Add(btnNext);
            Controls.Add(lblPageNumber);
            Controls.Add(btnAddProduct);
            Controls.Add(dgvProducts);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmListProduct";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmListProduct";
            Load += frmListProduct_Load;
            ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
            ((System.ComponentModel.ISupportInitialize)productBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvProducts;
        private BindingSource productBindingSource;
        private Button btnAddProduct;
        private Label lblPageNumber;
        private Label btnNext;
        private Label btnPrevious;
        private ComboBox cmbCategories;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn NameProduct;
        private DataGridViewTextBoxColumn Price;
        private DataGridViewTextBoxColumn CategoryId;
        private Button btnCategory;
        private Button btnProductHistoryReport;
    }
}