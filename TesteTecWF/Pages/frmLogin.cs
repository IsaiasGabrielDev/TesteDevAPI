using Microsoft.Extensions.DependencyInjection;
using TesteTecWF.Interfaces;
using TesteTecWF.Models;

namespace TesteTecWF.Pages;

public partial class frmLogin : Form
{
    private readonly IAuthService _authService;
    private readonly IServiceProvider _serviceProvider;

    public frmLogin(IAuthService authService, IServiceProvider serviceProvider)
    {
        InitializeComponent();

        lnkRegister.Focus();
        _authService = authService;
        _serviceProvider = serviceProvider;
    }

    private async void btnLogin_Click(object sender, EventArgs e)
    {
        //if (string.IsNullOrWhiteSpace(textEmail.Text) || string.IsNullOrWhiteSpace(textPassword.Text))
        //{
        //    MessageBox.Show("Preencha todos os campos!");
        //    return;
        //}

        //Login login = new(textEmail.Text, textPassword.Text);
        Login login = new("lipe.baterra@gmail.com", "5Alc1cha@");
        var response = await _authService.LoginAsync(login);

        if (response.Status)
        {
            frmListProduct frmListProduct = _serviceProvider.GetRequiredService<frmListProduct>();
            frmListProduct.Show();
            this.Hide();
        }
        else
        {
            MessageBox.Show(response.Message);
        }
    }

    private void lnkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
        var frmRegister = _serviceProvider.GetRequiredService<frmRegister>();
        frmRegister.Show();
        this.Hide();
    }
}
