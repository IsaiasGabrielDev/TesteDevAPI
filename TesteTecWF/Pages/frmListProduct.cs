using Microsoft.Extensions.DependencyInjection;
using TesteTecWF.Interfaces;
using TesteTecWF.Models;

namespace TesteTecWF.Pages;

public partial class frmListProduct : Form
{
    private readonly IProductService _productService;
    private readonly ICategoryService _categoryService;
    private readonly IServiceProvider _serviceProvider;

    private int _pageNumber = 1;
    private const int _pageSize = 20;
    private int _totalPages = 1;

    public frmListProduct(IProductService productService, ICategoryService categoryService, IServiceProvider serviceProvider)
    {
        InitializeComponent();
        _productService = productService;
        _categoryService = categoryService;
        _serviceProvider = serviceProvider;
    }

    private async void frmListProduct_Load(object sender, EventArgs e)
    {
        await LoadCategories();
        await LoadProducts();
    }

    private async Task LoadCategories()
    {
        var response = await _categoryService.GetAllCategoriesAsync();
        if (response.Status)
        {
            var categories = response.Data.ToList();

            categories.Insert(0, new Category(0, "Selecione uma categoria", null!));

            cmbCategories.DataSource = null;
            cmbCategories.DisplayMember = "Name";
            cmbCategories.ValueMember = "Id";
            cmbCategories.DataSource = categories;
        }
        else
        {
            MessageBox.Show(response.Message);
        }
    }

    private async Task LoadProducts()
    {
        var response = await _productService.GetProductsAsync(_pageNumber, _pageSize);

        if (response.Status)
        {
            ResponseProduct products = response.Data;

            dgvProducts.DataSource = products.Products;

            _totalPages = (int)Math.Ceiling((double)products.TotalRecords / _pageSize);

            lblPageNumber.Text = $"{_pageNumber} de {_totalPages}";

            btnPrevious.Enabled = _pageNumber > 1;
            btnNext.Enabled = _pageNumber < _totalPages;
        }
        else
        {
            MessageBox.Show(response.Message);
        }
    }

    private async void btnPrevious_Click(object sender, EventArgs e)
    {
        if (_pageNumber > 1)
        {
            _pageNumber--;
            await LoadProducts();
        }
    }

    private async void btnNext_Click(object sender, EventArgs e)
    {
        if (_pageNumber < _totalPages)
        {
            _pageNumber++;
            await LoadProducts();
        }
    }

    private void dgvProducts_SelectionChanged(object sender, EventArgs e)
    {
        if (dgvProducts.SelectedRows.Count > 0)
        {
            DataGridViewRow selectedRow = dgvProducts.SelectedRows[0];

            int productId = Convert.ToInt32(selectedRow.Cells["Id"].Value);
            string productName = selectedRow.Cells["NameProduct"].Value.ToString();
            decimal productPrice = Convert.ToDecimal(selectedRow.Cells["Price"].Value);
            int categoryId = Convert.ToInt32(selectedRow.Cells["CategoryId"].Value);

            Product product = new Product(productId, productName, productPrice, categoryId);

            var frmProduct = _serviceProvider.GetRequiredService<frmProduct>();
            frmProduct.SetProduct(product);
            frmProduct.Show();
            this.Hide();
        }
    }

    private async void cmbCategories_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (cmbCategories.SelectedValue is int categoryId && categoryId > 0)
        {
            await LoadProductsByCategory(categoryId);
        }
        else
        {
            await LoadProducts();
        }
    }

    private async Task LoadProductsByCategory(int categoryId)
    {
        var response = await _categoryService.GetCategoryByIdAsync(categoryId);

        if (response.Status)
        {
            Category category = response.Data;
            dgvProducts.DataSource = category.Products;
        }
    }

    private void btnAddProduct_Click(object sender, EventArgs e)
    {
        var frmProduct = _serviceProvider.GetRequiredService<frmProduct>();
        frmProduct.Show();
        this.Hide();
    }

    private void btnCategory_Click(object sender, EventArgs e)
    {
        var frmCategory = _serviceProvider.GetRequiredService<frmCategory>();
        frmCategory.Show();
        this.Hide();
    }
}
