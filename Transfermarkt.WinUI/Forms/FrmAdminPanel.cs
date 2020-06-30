using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Transfermarkt.Models;
using Transfermarkt.Models.Requests;

namespace Transfermarkt.WinUI.Forms
{
    public partial class FrmAdminPanel : Form
    {
        private readonly APIService _aPIServiceUsers = new APIService("Users");

        public FrmAdminPanel()
        {
            InitializeComponent();
        }

        private void FrmAdminPanel_Load(object sender, EventArgs e)
        {
            GetUsers();
        }

        private async void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtSearch.Text))
            {
                GetUsers();
                return;
            }
            var request = new UserSearchRequest
            {
                Username = TxtSearch.Text.ToLower(),
                Email = TxtSearch.Text.ToLower(),
                FirstName = TxtSearch.Text.ToLower(),
                LastName = TxtSearch.Text.ToLower()
            };
            var list = await _aPIServiceUsers.Get<List<UserInfo>>(request);
            DgvUsers.DataSource = list;
        }

        private async void GetUsers()
        {
            var users = await _aPIServiceUsers.Get<List<UserInfo>>(null);
            TxtUsersNumber.Text = users.Count().ToString();

            DgvUsers.DataSource = users;
        }
    }
}
