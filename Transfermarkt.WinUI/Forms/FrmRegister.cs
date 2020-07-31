using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Transfermarkt.Models;

namespace Transfermarkt.WinUI.Forms
{
    public partial class FrmRegister : Form
    {
        private readonly APIService _aPIServiceUser = new APIService("Users");

        public FrmRegister()
        {
            InitializeComponent();
        }
        private async void BtnCrAcc_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtUsername.Text) || string.IsNullOrEmpty(TxtEmailAddress.Text)
                || string.IsNullOrEmpty(TxtPassword.Text)
                || string.IsNullOrEmpty(TxtConPassword.Text)
                || string.IsNullOrEmpty(TxtFirstName.Text)
                || string.IsNullOrEmpty(TxtLastName.Text))
            {
                MessageBox.Show("Enter all the required fields", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var user = new UserRegistration
            {
                Email = TxtEmailAddress.Text,
                FirstName = TxtFirstName.Text,
                LastName = TxtLastName.Text,
                Password = TxtPassword.Text,
                PasswordConfirmation = TxtConPassword.Text,
                Username = TxtUsername.Text,
                Roles = new List<int>()
            };
            user.Roles.Add(2);//represents a Member role

            await _aPIServiceUser.Insert<Users>(user, "Registration");
            MessageBox.Show("Registration successful");
            FrmLogin frm = new FrmLogin();
            frm.Show();
            Close();
        }
    }
}
