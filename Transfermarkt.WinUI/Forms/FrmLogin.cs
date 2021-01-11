using System;
using System.Windows.Forms;
using Transfermarkt.Models.Requests;
using Transfermarkt.Models.Responses;

namespace Transfermarkt.WinUI.Forms
{
    public partial class FrmLogin : Form
    {
        private readonly APIService _apiServiceUsers = new APIService("Users");

        public FrmLogin()
        {
            InitializeComponent();
            loader.Visible = false;
        }

        private async void BtnLogin_Click(object sender, EventArgs e)
        {
            loader.Visible = true;
            try
            {
                var data = await _apiServiceUsers.Insert<UserAuthenticationResult>(new
                {
                    username = TxtUsername.Text,
                    password = TxtPassword.Text
                }, "login");

                if (data == null)
                {
                    MessageBox.Show("Wrong username or password", "Information", MessageBoxButtons.OK);
                    TxtUsername.Text = TxtPassword.Text = "";
                    loader.Visible = false;
                    return;
                }

                bool isAdmin = await _apiServiceUsers.Get<bool>(new UserRoleCheck
                {
                    Username = data.Username,
                    Rolename = "Administrator"
                }, "CheckRole");

                if (!isAdmin)
                {
                    MessageBox.Show("You must be an admin to login!", "Forbidden", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TxtUsername.Text = TxtPassword.Text = "";
                    loader.Visible = false;
                    return;
                }

                if (data != null)
                {
                    APIService.Token = data.Token;
                    loader.Visible = false;
                    var frm = new FrmIndex(TxtUsername.Text);
                    frm.Show();
                    frm.FormClosing += Frm_FormClosing;
                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                loader.Visible = false;
                TxtUsername.Text = TxtPassword.Text = "";
                MessageBox.Show("Invalid username or password.", "Authentication", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Frm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Show();
            TxtUsername.Text = TxtPassword.Text = "";
        }
    }
}
