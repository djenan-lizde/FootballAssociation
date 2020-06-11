using System;
using System.Windows.Forms;
using Transfermarkt.Models.Responses;

namespace Transfermarkt.WinUI.Forms
{
    public partial class FrmLogin : Form
    {
        private readonly APIService _apiServiceUsers = new APIService("Users");

        public FrmLogin()
        {
            InitializeComponent();
        }

        private void BtnCreateAcc_Click(object sender, EventArgs e)
        {
            FrmRegister frm = new FrmRegister();
            frm.Show();
            //Close();
        }
        private async void BtnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                var data = await _apiServiceUsers.Insert<UserAuthenticationResult>(new
                {
                    username = TxtUsername.Text,
                    password = TxtPassword.Text
                }, "login");

                if (data != null)
                {
                    APIService.Token = data.Token;
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
