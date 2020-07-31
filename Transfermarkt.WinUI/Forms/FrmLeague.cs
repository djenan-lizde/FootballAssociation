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
    public partial class FrmLeague : Form
    {
        private readonly APIService _aPIServiceLeagues = new APIService("Leagues");
        public FrmLeague()
        {
            InitializeComponent();
        }

        private async void BtnAddLeague_Click(object sender, EventArgs e)
        {
            var league = new Leagues
            {
                Established = DateTime.Parse(txtDateEstablished.Text),
                Name = txtLeagueName.Text,
                Organizer = txtOrganizer.Text 
            };
            await _aPIServiceLeagues.Insert<Leagues>(league);
            MessageBox.Show("Leagues successfully added!", "Information", MessageBoxButtons.OK);
            Close();
        }
    }
}
