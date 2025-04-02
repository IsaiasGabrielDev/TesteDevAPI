using TesteTecWF.Interfaces;
using TesteTecWF.Models;

namespace TesteTecWF.Pages;

public partial class frmLogin : Form
{
    private readonly IAuthService _authService;
    public frmLogin(IAuthService authService)
    {
        InitializeComponent();

        lnkRegister.Focus();
        _authService = authService;
    }

    private async void btnLogin_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(textEmail.Text) || string.IsNullOrWhiteSpace(textPassword.Text))
        {
            MessageBox.Show("Preencha todos os campos!");
            return;
        }

        Login login = new(textEmail.Text, textPassword.Text);
        var response = await _authService.LoginAsync(login);

        if (response.Status)
        {
            MessageBox.Show("Login efetuado com sucesso!");
        }
        else
        {
            MessageBox.Show(response.Message);
        }
    }

    private void lnkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
        frmRegister frmRegister = new(_authService);
        frmRegister.Show();
        this.Hide();
    }
}
