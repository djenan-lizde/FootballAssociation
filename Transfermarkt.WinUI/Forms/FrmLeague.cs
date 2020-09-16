using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Transfermarkt.Models;

namespace Transfermarkt.WinUI.Forms
{
    public partial class FrmLeague : Form
    {
        private readonly APIService _aPIServiceLeagues = new APIService("Leagues");
        public FrmLeague()
        {
            InitializeComponent();
            this.AutoValidate = AutoValidate.Disable;
        }

        private async void BtnAddLeague_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                var leagues = await _aPIServiceLeagues.Get<List<Leagues>>();
                foreach (var item in leagues)
                {
                    if (item.Name == TxtLeagueName.Text)
                    {
                        MessageBox.Show("Leagues already exists!", "Information", MessageBoxButtons.OK);
                        return;
                    }
                }
                await _aPIServiceLeagues.Insert<Leagues>(new Leagues
                {
                    Established = DateTime.Parse(TxtDateEstablished.Text),
                    Name = TxtLeagueName.Text,
                    Organizer = TxtOrganizer.Text
                });
                MessageBox.Show("Leagues successfully added!", "Information", MessageBoxButtons.OK);
                Close();
            }
        }
        private void TxtLeagueName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtLeagueName.Text))
            {
                errorProvider.SetError(TxtLeagueName, "Input can not be an empty string.");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(TxtLeagueName, null);
            }
        }
        private void TxtOrganizer_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtOrganizer.Text))
            {
                errorProvider.SetError(TxtOrganizer, "Input can not be an empty string.");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(TxtOrganizer, null);
            }
        }
        private void TxtDateEstablished_Validating(object sender, CancelEventArgs e)
        {
            bool success = DateTime.TryParse(TxtDateEstablished.Text, out _);
            if (string.IsNullOrWhiteSpace(TxtDateEstablished.Text) || !success)
            {
                errorProvider.SetError(TxtDateEstablished, "Please insert date.");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(TxtDateEstablished, null);
            }
        }
    }
}
