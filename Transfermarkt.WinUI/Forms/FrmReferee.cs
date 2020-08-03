using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Transfermarkt.Models;

namespace Transfermarkt.WinUI.Forms
{
    public partial class FrmReferee : Form
    {
        private readonly APIService _aPIServiceReferee = new APIService("Referee");
        private readonly APIService _aPIServiceCity = new APIService("Cities");

        public int? Id { get; set; }
        public FrmReferee(int? id = null)
        {
            InitializeComponent();
            Id = id;
        }

        private async void FrmReferee_Load(object sender, EventArgs e)
        {
            var resultCity = await _aPIServiceCity.Get<List<Cities>>();

            CmbCities.DataSource = resultCity;
            CmbCities.DisplayMember = "Name";
            CmbCities.ValueMember = "Id";

            if (Id.HasValue)
            {
                var refereeLoad = await _aPIServiceReferee.GetById<Referees>(Id);
                TxtFirstName.Text = refereeLoad.FirstName;
                TxtLastName.Text = refereeLoad.LastName;
                TxtMiddleName.Text = refereeLoad.MiddleName;
                CmbCities.SelectedIndex = refereeLoad.CityId - 1;
            }
        }
        private async void BtnSaveReferee_Click(object sender, EventArgs e)
        {
            Referees referee = new Referees
            {
                FirstName = TxtFirstName.Text,
                LastName = TxtLastName.Text,
                MiddleName = TxtMiddleName.Text,
                CityId = int.Parse(CmbCities.SelectedValue.ToString()),
                Id = Id ?? 0
            };

            if (string.IsNullOrEmpty(TxtMiddleName.Text))
                referee.MiddleName = "N/A";
            else
                referee.MiddleName = TxtMiddleName.Text;

            if (Id.HasValue)
            {
                await _aPIServiceReferee.Update<Referees>(referee, referee.Id.ToString());
                MessageBox.Show("Referee updated", "Information");
            }
            else
            {
                await _aPIServiceReferee.Insert<Referees>(referee);
                MessageBox.Show("Referee added", "Information");
            }
        }
    }
}
