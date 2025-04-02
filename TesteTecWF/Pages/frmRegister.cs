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
        public frmRegister(IAuthService authService)
        {
            InitializeComponent();
            lnkLogin.Focus();
            _authService = authService;
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
                frmLogin formLogin = new(_authService);
                formLogin.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show(response.Message);
            }
        }

        private void lnkLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLogin formLogin = new(_authService);
            formLogin.Show();
            this.Hide();
        }
    }
}
