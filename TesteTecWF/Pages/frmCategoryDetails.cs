using Microsoft.Extensions.DependencyInjection;
using TesteTecWF.Interfaces;
using TesteTecWF.Models;

namespace TesteTecWF.Pages;

public partial class frmCategoryDetails : Form
{
    private readonly ICategoryService _categoryService;
    private readonly IServiceProvider _serviceProvider;
    private Category _categoryEdit = null!;
    public frmCategoryDetails(ICategoryService categoryService, IServiceProvider serviceProvider)
    {
        InitializeComponent();
        _categoryService = categoryService;
        _serviceProvider = serviceProvider;
    }

    public void SetCategory(Category category)
    {
        _categoryEdit = category;
        txtName.Text = category.Name;
    }

    private void frmCategoryDetails_Load(object sender, EventArgs e)
    {
        if (_categoryEdit is not null)
            btnDeleteProduct.Visible = true;
    }

    private void lblVoltar_Click(object sender, EventArgs e)
    {
        var frmCategory = _serviceProvider.GetRequiredService<frmCategory>();
        frmCategory.Show();
        this.Hide();
    }

    private async void btnSalvar_Click(object sender, EventArgs e)
    {

        if (_categoryEdit is null)
            await AddCategory();
        else
            await UpdateCategory();
    }

    private async Task AddCategory()
    {
        Category category = new(null!, txtName.Text, null!);

        var response = await _categoryService.CreateCategoryAsync(category);
        if (response.Status)
        {
            MessageBox.Show("Categoria adicionada com sucesso");

            RedirectToList();
        }
        else
        {
            MessageBox.Show(response.Message);
            return;
        }
    }

    private async Task UpdateCategory()
    {
        Category category = new(_categoryEdit.Id, txtName.Text, null!);
        var response = await _categoryService.UpdateCategoryAsync(category);

        if (response.Status)
        {
            MessageBox.Show("Categoria atualizada com sucesso");

            RedirectToList();
        }
        else
        {
            MessageBox.Show(response.Message);
            return;
        }
    }

    private void RedirectToList()
    {
        var frmCategory = _serviceProvider.GetRequiredService<frmCategory>();
        frmCategory.Show();
        this.Hide();
    }

    private async void btnDeleteProduct_Click(object sender, EventArgs e)
    {
        var response = await _categoryService.DeleteCategoryAsync(_categoryEdit.Id!.Value);
        if (response.Status)
        {
            MessageBox.Show("Categoria deletada com sucesso");
            RedirectToList();
        }
        else
        {
            MessageBox.Show(response.Message);
            return;
        }
    }
}
