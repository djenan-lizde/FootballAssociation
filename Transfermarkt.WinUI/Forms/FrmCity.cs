using System;
using System.ComponentModel;
using System.Windows.Forms;
using Transfermarkt.Models;

namespace Transfermarkt.WinUI.Forms
{
    public partial class FrmCity : Form
    {
        private readonly APIService _aPIServiceCity = new APIService("Cities");

        public FrmCity()
        {
            InitializeComponent();
            this.AutoValidate = AutoValidate.Disable;
        }
        private async void BtnAddCity_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                var city = new Cities
                {
                    Name = TxtCityName.Text,
                    PostalCode = int.Parse(TxtZipCode.Text)
                };
                await _aPIServiceCity.Insert<Cities>(city);
                MessageBox.Show("City successfully added.", "Infomation", MessageBoxButtons.OK);
                Close();
            }
        }
        private void TxtCityName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtCityName.Text))
            {
                errorProvider.SetError(TxtCityName, "Input can not be an empty string.");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(TxtCityName, null);
            }
        }
        private void TxtZipCode_Validating(object sender, CancelEventArgs e)
        {
            bool success = int.TryParse(TxtZipCode.Text, out _);
            if (string.IsNullOrWhiteSpace(TxtZipCode.Text) || !success)
            {
                errorProvider.SetError(TxtZipCode, "Please insert a valid zip code number.");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(TxtZipCode, null);
            }
        }
    }
}
