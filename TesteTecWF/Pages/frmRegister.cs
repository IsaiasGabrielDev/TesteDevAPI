using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TesteTecWF.Interfaces;
using TesteTecWF.Models;

namespace TesteTecWF.Pages
{
    public partial class frmRegister : Form
    {
        private readonly IAuthService _authService;
        private readonly IServiceProvider _serviceProvider;
        public frmRegister(IAuthService authService, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            lnkLogin.Focus();
            _authService = authService;
            _serviceProvider = serviceProvider;
        }

        private async void btnRegister_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textName.Text) ||
                string.IsNullOrWhiteSpace(textEmail.Text) ||
                string.IsNullOrWhiteSpace(textPassword.Text))
            {
                MessageBox.Show("Preencha todos os campos!");
                return;
            }

            Register register = new(textName.Text, textEmail.Text, textPassword.Text);
            var response = await _authService.RegisterAsync(register);

            if (response.Status)
            {
                frmLogin formLogin = _serviceProvider.GetRequiredService<frmLogin>();
                formLogin.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show(response.Message);
            }
        }

        private void lnkLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLogin formLogin = _serviceProvider.GetRequiredService<frmLogin>();
            formLogin.Show();
            this.Hide();
        }
    }
}
