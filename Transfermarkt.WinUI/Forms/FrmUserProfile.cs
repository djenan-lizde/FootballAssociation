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
    public partial class FrmUserProfile : Form
    {
        private readonly APIService _apiServiceUsers = new APIService("Users");
        public FrmUserProfile()
        {
            InitializeComponent();
        }

        private void FrmUserProfile_Load(object sender, EventArgs e)
        {
            //var user = await _apiServiceUsers.GetById
        }

        private async void BtnUpdate_Click(object sender, EventArgs e)
        {
            var user = new UserUpdate
            {
                Email = TxtEmail.Text,
                FirstName = TxtEmail.Text,
                LastName = TxtEmail.Text,
                Username = TxtUsername.Text
            };
            await _apiServiceUsers.Update<UserUpdate>(user);
            MessageBox.Show("Your profile has been updated", "Information");
        }


    }
}
