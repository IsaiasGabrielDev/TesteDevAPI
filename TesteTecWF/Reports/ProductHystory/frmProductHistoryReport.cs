using Microsoft.Extensions.DependencyInjection;
using Microsoft.Reporting.WinForms;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Windows.Forms;
using TesteTecWF.Interfaces;
using TesteTecWF.Models;
using TesteTecWF.Pages;
using TesteTecWF.Services;

namespace TesteTecWF.Reports;

public partial class frmProductHistoryReport : Form
{
    private readonly IProductService _productService;
    private readonly IServiceProvider _serviceProvider;
    private readonly IProductHistoryService _productHistoryService;
    private readonly TokenService _tokenService;
    public frmProductHistoryReport(IProductService productService, IServiceProvider serviceProvider, TokenService tokenService, IProductHistoryService productHistoryService)
    {
        InitializeComponent();
        _productService = productService;
        _serviceProvider = serviceProvider;
        _tokenService = tokenService;
        _productHistoryService = productHistoryService;
    }

    private void frmProductHistoryReport_Load(object sender, EventArgs e)
    {
        cmbFiltros.DataSource = new List<string>()
        {
            "",
            "Produtos",
        };
    }

    private async void cmbFiltros_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (cmbFiltros.SelectedItem is string selectedItem)
        {
            switch (selectedItem)
            {
                case "Produtos":
                    await LoadProducts();
                    break;
                default:
                    cmbProduct.Visible = false;
                    lblProduct.Visible = false;
                    break;
            }
        }
    }

    private async Task LoadProducts()
    {
        var response = await _productService.GetProductsAsync(1, int.MaxValue);

        if (response.Status)
        {
            var products = response.Data.Products.ToList();
            cmbProduct.DataSource = products;
            cmbProduct.DisplayMember = "Name";
            cmbProduct.ValueMember = "Id";
            cmbProduct.Visible = true;
            lblProduct.Visible = true;
        }
        else
        {
            MessageBox.Show("Erro ao carregar produtos: " + response.Message);
        }
    }

    private void lblVoltar_Click(object sender, EventArgs e)
    {
        var frmListProduct = _serviceProvider.GetRequiredService<frmListProduct>();
        frmListProduct.Show();
        this.Hide();
    }

    private async void btnGenereteReport_Click(object sender, EventArgs e)
    {
        if (cmbFiltros.SelectedItem is string selectedItem)
        {
            switch (selectedItem)
            {
                case "Produtos":
                    await GenerateProductReport();
                    break;
                default:
                    await GenerateUserReport();
                    break;
            }
        }
    }

    private async Task GenerateProductReport()
    {
        if (cmbProduct.SelectedValue is int productId && productId > 0)
        {
            var reportData = await _productHistoryService.GetByProductIdAsync(productId, 0);

            if (reportData.Status)
            {
                IEnumerable<ProductHistory> productHistories = reportData.Data;

                RenderReport(productHistories);
            }
            else
            {
                MessageBox.Show("Erro ao gerar relatório de produto: " + reportData.Message);
            }
        }
        else
        {
            MessageBox.Show("Selecione um produto válido.");
        }
    }

    private async Task GenerateUserReport()
    {
        var token = _tokenService.GetToken();

        if (string.IsNullOrEmpty(token))
        {
            MessageBox.Show("Token inválido. Faça login novamente.");
            return;
        }

        var handler = new JwtSecurityTokenHandler();
        var jwtToken = handler.ReadJwtToken(token);

        var email = jwtToken.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
        var userResponse = await _productHistoryService.GetUserByEmail(email);

        if (userResponse.Status && userResponse.Data != null)
        {
            var userId = userResponse.Data.Id;
            var reportData = await _productHistoryService.GetByProductIdAsync(0, userId);

            if (reportData.Status)
            {
                IEnumerable<ProductHistory> productHistories = reportData.Data;

                RenderReport(productHistories);
            }
            else
            {
                MessageBox.Show("Erro ao gerar relatório de produto: " + reportData.Message);
            }
        }
        else
        {
            MessageBox.Show("Usuário não encontrado.");
        }
    }

    private void RenderReport(IEnumerable<ProductHistory> productHistories)
    {
        string reportPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Reports", "ProductHystory", "ProductHistory.rdlc");

        if (!File.Exists(reportPath))
        {
            MessageBox.Show("Arquivo de relatório não encontrado.");
            return;
        }

        using FileStream reportDefinition = new FileStream(reportPath, FileMode.Open, FileAccess.Read);

        LocalReport report = new LocalReport();
        report.LoadReportDefinition(reportDefinition);
        report.DataSources.Add(new ReportDataSource("DataSetProductHistory", productHistories));
        byte[] pdf = report.Render("PDF");

        string tempFilePath = Path.Combine(Path.GetTempPath(), "historico_produto.pdf");
        File.WriteAllBytes(tempFilePath, pdf);

        Process.Start(new ProcessStartInfo(tempFilePath) { UseShellExecute = true });
    }
}
