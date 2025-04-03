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
using TesteTecWF.Strategy;

namespace TesteTecWF.Reports;

public partial class frmProductHistoryReport : Form
{
    private readonly ICategoryService _categoryService;
    private readonly IServiceProvider _serviceProvider;
    private readonly IProductHistoryService _productHistoryService;
    private readonly IRenderReports _renderReports;
    private readonly TokenService _tokenService;

    public frmProductHistoryReport(ICategoryService categoryService, IServiceProvider serviceProvider, IProductHistoryService productHistoryService, TokenService tokenService, IRenderReports renderReports)
    {
        InitializeComponent();
        _categoryService = categoryService;
        _serviceProvider = serviceProvider;
        _productHistoryService = productHistoryService;
        _tokenService = tokenService;
        _renderReports = renderReports;
    }

    private void frmProductHistoryReport_Load(object sender, EventArgs e)
    {
        cmbFiltros.DataSource = new List<string>()
        {
            "",
            "Categorias",
        };
    }

    private async void cmbFiltros_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (cmbFiltros.SelectedItem is string selectedItem)
        {
            switch (selectedItem)
            {
                case "Categorias":
                    await LoadCategories();
                    break;
                default:
                    cmbCategory.Visible = false;
                    lblCategory.Visible = false;
                    break;
            }
        }
    }

    private async Task LoadCategories()
    {
        var response = await _categoryService.GetAllCategoriesAsync();

        if (response.Status)
        {
            var categories = response.Data.ToList();
            cmbCategory.DataSource = categories;
            cmbCategory.DisplayMember = "Name";
            cmbCategory.ValueMember = "Id";
            cmbCategory.Visible = true;
            lblCategory.Visible = true;
        }
        else
        {
            MessageBox.Show("Erro ao carregar as categorias: " + response.Message);
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
                case "Categorias":
                    await GenerateCategoriesReport();
                    break;
                default:
                    await GenerateUserReport();
                    break;
            }
        }
    }

    private async Task GenerateCategoriesReport()
    {
        if (cmbCategory.SelectedValue is int categoryId && categoryId > 0)
        {
            var reportData = await _productHistoryService.GetByProductIdAsync(categoryId, 0);

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
        _renderReports.Render(new RenderReportModel
        {
            FolderName = "ProductHistory",
            ReportName = "ProductHistory",
            DataSetName = "DataSetProductHistory",
            Data = productHistories
        });
    }
}
