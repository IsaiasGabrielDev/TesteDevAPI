using Microsoft.Extensions.DependencyInjection;
using TesteTecWF.Interfaces;
using TesteTecWF.Models;
using TesteTecWF.Pages;
using TesteTecWF.Strategy;

namespace TesteTecWF.Reports.ProductStockReport
{
    public partial class frmProductStock : Form
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IProductService _productService;
        private readonly IRenderReports _renderReports;
        public frmProductStock(IServiceProvider serviceProvider, IProductService productService, IRenderReports renderReports)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            _productService = productService;
            _renderReports = renderReports;
        }

        private void lblVoltar_Click(object sender, EventArgs e)
        {
            var frmListProduct = _serviceProvider.GetRequiredService<frmListProduct>();
            frmListProduct.Show();
            this.Hide();
        }

        private async void frmProductStock_Load(object sender, EventArgs e)
        {
            await RenderReport();
        }

        private async Task RenderReport()
        {
            var response = await _productService.GetProductStockAsync();
            if (response.Status)
            {
                var productStock = response.Data;
                if (productStock != null)
                {
                    RenderReportModel renderReportModel = new RenderReportModel
                    {
                        FolderName = "ProductStockReport",
                        ReportName = "ProductStock",
                        DataSetName = "DataSetProductStock",
                        Data = new List<ProductStock> { productStock }
                    };

                    _renderReports.Render(renderReportModel);
                }
                else
                {
                    MessageBox.Show("Nenhum dado encontrado.");
                }
            }
            else
            {
                MessageBox.Show(response.Message);
            }
        }
    }
}
