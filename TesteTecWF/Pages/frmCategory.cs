using Microsoft.Extensions.DependencyInjection;
using TesteTecWF.Interfaces;
using TesteTecWF.Models;

namespace TesteTecWF.Pages;

public partial class frmCategory : Form
{
    private readonly ICategoryService _categoryService;
    private readonly IServiceProvider _serviceProvider;
    public frmCategory(ICategoryService categoryService, IServiceProvider serviceProvider)
    {
        InitializeComponent();
        _categoryService = categoryService;
        _serviceProvider = serviceProvider;
    }

    private async void frmCategory_Load(object sender, EventArgs e)
    {
        await LoadCategories();
    }

    private void btnAddCategory_Click(object sender, EventArgs e)
    {
        var frmCategoryDetails = _serviceProvider.GetRequiredService<frmCategoryDetails>();
        frmCategoryDetails.Show();
        this.Hide();
    }

    private async Task LoadCategories()
    {
        var categories = await _categoryService.GetAllCategoriesAsync();
        if (categories.Status)
        {
            dgvCategory.DataSource = categories.Data;
        }
        else
        {
            MessageBox.Show(categories.Message);
        }
    }

    private void lblVoltar_Click(object sender, EventArgs e)
    {
        var frmListProduct = _serviceProvider.GetRequiredService<frmListProduct>();
        frmListProduct.Show();
        this.Hide();
    }

    private void dgvCategory_SelectionChanged(object sender, EventArgs e)
    {
        if (dgvCategory.SelectedRows.Count > 0)
        {
            DataGridViewRow selectedRow = dgvCategory.SelectedRows[0];

            int categoryId = Convert.ToInt32(selectedRow.Cells["Id"].Value);
            string categoryName = selectedRow.Cells["CategoryName"].Value.ToString();

            Category category = new(categoryId, categoryName, null!);

            var frmCategoryDetails = _serviceProvider.GetRequiredService<frmCategoryDetails>();
            frmCategoryDetails.SetCategory(category);
            frmCategoryDetails.Show();
            this.Hide();
        }
    }
}
