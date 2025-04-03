namespace TesteTecWF.Reports.ProductStockReport
{
    partial class frmProductStock
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
            reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            SuspendLayout();
            // 
            // lblVoltar
            // 
            lblVoltar.AutoSize = true;
            lblVoltar.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblVoltar.ForeColor = SystemColors.Control;
            lblVoltar.Location = new Point(719, 413);
            lblVoltar.Name = "lblVoltar";
            lblVoltar.Size = new Size(69, 28);
            lblVoltar.TabIndex = 9;
            lblVoltar.Text = "Voltar";
            lblVoltar.Click += lblVoltar_Click;
            // 
            // reportViewer1
            // 
            reportViewer1.Location = new Point(0, 0);
            reportViewer1.Name = "ReportViewer";
            reportViewer1.ServerReport.BearerToken = null;
            reportViewer1.Size = new Size(396, 246);
            reportViewer1.TabIndex = 0;
            // 
            // frmProductStock
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkGray;
            ClientSize = new Size(800, 450);
            Controls.Add(lblVoltar);
            ForeColor = SystemColors.Control;
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmProductStock";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmProductStock";
            Load += frmProductStock_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblVoltar;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    }
}