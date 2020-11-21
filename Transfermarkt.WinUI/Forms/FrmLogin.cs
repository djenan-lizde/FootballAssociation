using Flurl.Http;
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

        private void BtnCreateAcc_Click(object sender, EventArgs e)
        {
            FrmRegister frm = new FrmRegister();
            frm.Show();
            //Close();
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

                bool isAdmin = await _apiServiceUsers.Get<bool>(new UserRoleCheck
                {
                    Username = data.Username,
                    Rolename = "Administrator"
                }, "CheckRole");

                if (!isAdmin)
                {
                    MessageBox.Show("Forbidden", "You must be an admin to login!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TxtUsername.Text = TxtPassword.Text = "";
                    loader.Visible = false;
                    return;
                }

                if (data != null)
                {
                    APIService.Token = data.Token;
                    loader.Visible = false;
                    new FrmIndex(TxtUsername.Text).Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Authentication", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
