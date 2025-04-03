namespace TesteTecWF.Reports
{
    partial class frmProductHistoryReport
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
            panelFilter = new Panel();
            btnGenereteReport = new Button();
            lblVoltar = new Label();
            label4 = new Label();
            lblProduct = new Label();
            cmbProduct = new ComboBox();
            cmbFiltros = new ComboBox();
            label1 = new Label();
            reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            panelFilter.SuspendLayout();
            SuspendLayout();
            // 
            // panelFilter
            // 
            panelFilter.Controls.Add(btnGenereteReport);
            panelFilter.Controls.Add(lblVoltar);
            panelFilter.Controls.Add(label4);
            panelFilter.Controls.Add(lblProduct);
            panelFilter.Controls.Add(cmbProduct);
            panelFilter.Controls.Add(cmbFiltros);
            panelFilter.Controls.Add(label1);
            panelFilter.Location = new Point(12, 12);
            panelFilter.Name = "panelFilter";
            panelFilter.Size = new Size(776, 426);
            panelFilter.TabIndex = 0;
            // 
            // btnGenereteReport
            // 
            btnGenereteReport.Location = new Point(0, 144);
            btnGenereteReport.Name = "btnGenereteReport";
            btnGenereteReport.Size = new Size(321, 29);
            btnGenereteReport.TabIndex = 8;
            btnGenereteReport.Text = "Gerar Relatório";
            btnGenereteReport.UseVisualStyleBackColor = true;
            btnGenereteReport.Click += btnGenereteReport_Click;
            // 
            // lblVoltar
            // 
            lblVoltar.AutoSize = true;
            lblVoltar.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblVoltar.ForeColor = SystemColors.Control;
            lblVoltar.Location = new Point(704, 397);
            lblVoltar.Name = "lblVoltar";
            lblVoltar.Size = new Size(69, 28);
            lblVoltar.TabIndex = 7;
            lblVoltar.Text = "Voltar";
            lblVoltar.Click += lblVoltar_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = SystemColors.Control;
            label4.Location = new Point(328, 69);
            label4.Name = "label4";
            label4.Size = new Size(49, 20);
            label4.TabIndex = 6;
            label4.Text = "Filtros";
            // 
            // lblProduct
            // 
            lblProduct.AutoSize = true;
            lblProduct.ForeColor = SystemColors.Control;
            lblProduct.Location = new Point(328, 103);
            lblProduct.Name = "lblProduct";
            lblProduct.Size = new Size(62, 20);
            lblProduct.TabIndex = 4;
            lblProduct.Text = "Produto";
            lblProduct.Visible = false;
            // 
            // cmbProduct
            // 
            cmbProduct.FormattingEnabled = true;
            cmbProduct.Location = new Point(0, 100);
            cmbProduct.Name = "cmbProduct";
            cmbProduct.Size = new Size(322, 28);
            cmbProduct.TabIndex = 2;
            cmbProduct.Visible = false;
            // 
            // cmbFiltros
            // 
            cmbFiltros.FormattingEnabled = true;
            cmbFiltros.Location = new Point(0, 66);
            cmbFiltros.Name = "cmbFiltros";
            cmbFiltros.Size = new Size(322, 28);
            cmbFiltros.TabIndex = 1;
            cmbFiltros.SelectedIndexChanged += cmbFiltros_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.Control;
            label1.Location = new Point(256, 1);
            label1.Name = "label1";
            label1.Size = new Size(260, 28);
            label1.TabIndex = 0;
            label1.Text = "HISTÓRICO DE PRODUTOS";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // reportViewer1
            // 
            reportViewer1.Location = new Point(0, 0);
            reportViewer1.Name = "ReportViewer";
            reportViewer1.ServerReport.BearerToken = null;
            reportViewer1.Size = new Size(396, 246);
            reportViewer1.TabIndex = 0;
            // 
            // frmProductHistoryReport
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkGray;
            ClientSize = new Size(800, 450);
            Controls.Add(panelFilter);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmProductHistoryReport";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmProductHystoryReport";
            Load += frmProductHistoryReport_Load;
            panelFilter.ResumeLayout(false);
            panelFilter.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelFilter;
        private ComboBox cmbFiltros;
        private Label label1;
        private Label label4;
        private Label lblProduct;
        private ComboBox cmbProduct;
        private Label lblVoltar;
        private Button btnGenereteReport;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    }
}