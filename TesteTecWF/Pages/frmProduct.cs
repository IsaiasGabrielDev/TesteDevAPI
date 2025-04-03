using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using TesteTecWF.Interfaces;
using TesteTecWF.Models;

namespace TesteTecWF.Pages;

public partial class frmProduct : Form
{
    private readonly IProductService _productService;
    private readonly ICategoryService _categoryService;
    private readonly IServiceProvider _serviceProvider;
    private Product _productEdit = null!;
    public frmProduct(IProductService productService, IServiceProvider serviceProvider, ICategoryService categoryService)
    {
        InitializeComponent();
        _productService = productService;
        _serviceProvider = serviceProvider;
        _categoryService = categoryService;
    }

    public void SetProduct(Product product)
    {
        _productEdit = product;
    }

    private async void frmProduct_Load(object sender, EventArgs e)
    {
        await LoadCategories();

        if (_productEdit != null)
        {
            txtName.Text = _productEdit.Name;
            txtPrice.Text = _productEdit.Price.ToString();
            cmbCategories.SelectedValue = _productEdit.CategoryId;

            btnDeleteProduct.Visible = true;
        }
    }

    private async Task LoadCategories()
    {
        var response = await _categoryService.GetAllCategoriesAsync();
        if (response.Status)
        {
            var categories = response.Data.ToList();

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

    private void lblVoltar_Click(object sender, EventArgs e)
    {
        RedirectToList();
    }

    private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',' && e.KeyChar != '.')
        {
            e.Handled = true;
        }

        if ((e.KeyChar == ',') && (sender as TextBox).Text.Contains(","))
        {
            e.Handled = true;
        }
    }

    private void txtPrice_Leave(object sender, EventArgs e)
    {
        if (decimal.TryParse(txtPrice.Text, out decimal valor))
        {
            txtPrice.Text = valor.ToString("n2");
        }
        else
        {
            MessageBox.Show("Valor inválido");
            txtPrice.Focus();
        }
    }

    private async void btnSalvar_Click(object sender, EventArgs e)
    {
        if (_productEdit is null)
            await AddProduct();
        else
            await UpdateProduct();
    }

    private async Task AddProduct()
    {
        Product product = new(null!, txtName.Text, Convert.ToDecimal(txtPrice.Text), Convert.ToInt32(cmbCategories.SelectedValue));

        var response = await _productService.AddProductAsync(product);
        if (response.Status)
        {
            MessageBox.Show("Produto adicionado com sucesso");

            RedirectToList();
        }
        else
        {
            MessageBox.Show(response.Message);
            return;
        }
    }

    private async Task UpdateProduct()
    {
        Product product = new(_productEdit.Id, txtName.Text, Convert.ToDecimal(txtPrice.Text), Convert.ToInt32(cmbCategories.SelectedValue));
        var response = await _productService.UpdateProductAsync(product);

        if (response.Status)
        {
            MessageBox.Show("Produto atualizado com sucesso");

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
        var frmListProduct = _serviceProvider.GetRequiredService<frmListProduct>();
        frmListProduct.Show();
        this.Hide();
    }

    private async void btnDeleteProduct_Click(object sender, EventArgs e)
    {
        if(_productEdit is null)
        {
            MessageBox.Show("Selecione um produto para excluir");
            RedirectToList();
        }

        if (MessageBox.Show("Você tem certeza que deseja excluir o produto?", "Excluir Produto", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
        {
            return;
        }

        bool response = await _productService.DeleteProductAsync(_productEdit!.Id!.Value);

        if(response)
        {
            MessageBox.Show("Produto excluído com sucesso");
            RedirectToList();
        }
        else
        {
            MessageBox.Show("Erro ao excluir o produto");
            return;
        }
    }
}
