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
            var resultCity = await _aPIServiceCity.Get<List<City>>();

            CmbCities.DataSource = resultCity;
            CmbCities.DisplayMember = "Name";
            CmbCities.ValueMember = "Id";

            if (Id.HasValue)
            {
                var refereeLoad = await _aPIServiceReferee.GetById<Referee>(Id);
                TxtFirstName.Text = refereeLoad.FirstName;
                TxtLastName.Text = refereeLoad.LastName;
                TxtMiddleName.Text = refereeLoad.MiddleName;
                CmbCities.SelectedIndex = refereeLoad.CityId - 1;
            }
        }
        private async void BtnSaveReferee_Click(object sender, EventArgs e)
        {
            Referee referee = new Referee
            {
                FirstName = TxtFirstName.Text,
                LastName = TxtLastName.Text,
                MiddleName = TxtMiddleName.Text,
                CityId = int.Parse(CmbCities.SelectedValue.ToString()),
                Id = Id ?? 0
            };
            if (Id.HasValue)
            {
                await _aPIServiceReferee.Update<Referee>(referee);
                MessageBox.Show("Referee updated", "Information");
            }
            else
            {
                await _aPIServiceReferee.Insert<Referee>(referee);
                MessageBox.Show("Referee added", "Information");
            }
        }
    }
}
