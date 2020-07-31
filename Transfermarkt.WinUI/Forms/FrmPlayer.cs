using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Transfermarkt.Models;
using Transfermarkt.Models.Extensions;
using static Transfermarkt.Models.Enums.Enums;

namespace Transfermarkt.WinUI.Forms
{
    public partial class FrmPlayer : Form
    {
        private readonly APIService _aPIServicePlayer = new APIService("Players");

        public int? Id { get; set; }

        public FrmPlayer(int? id = null)
        {
            InitializeComponent();
            Id = id;
        }

        private async void FrmPlayers_Load(object sender, EventArgs e)
        {
            var list = Globals.ToPairList<StrongerFoot>(typeof(StrongerFoot));
            CmbStrongerFoot.DataSource = list.ToList();
            CmbStrongerFoot.DisplayMember = "Value";
            CmbStrongerFoot.ValueMember = "Key";

            var positions = await _aPIServicePlayer.Get<List<Positions>>(null, "Positions");

            listBox1.DataSource = positions.ToList();
            listBox1.DisplayMember = "Name";
            listBox1.ValueMember = "Id";

            if (Id.HasValue)
            {
                var player = await _aPIServicePlayer.GetById<Players>(Id);
                txtBirthDate.Text = player.Birthdate.ToString();
                txtFirstName.Text = player.FirstName;
                txtHeight.Text = player.Height.ToString();
                txtJerseyNumber.Text = player.Jersey.ToString();
                txtLastName.Text = player.LastName;
                txtMarketValue.Text = player.Value.ToString();
                txtMiddleName.Text = player.MiddleName;
                txtWeight.Text = player.Weight.ToString();
                ChBoxSign.Checked = player.IsSigned;
                CmbStrongerFoot.SelectedIndex = player.StrongerFoot;
                if (player.IsSigned)
                {
                    ChBoxSign.Enabled = false;
                }
            }
        }
        private async void BtnAddPlayer_Click(object sender, EventArgs e)
        {
            Players player = new Players
            {
                FirstName = txtFirstName.Text,
                MiddleName = txtMiddleName.Text,
                LastName = txtLastName.Text,
                Birthdate = DateTime.Parse(txtBirthDate.Text.ToString()),
                Height = int.Parse(txtHeight.Text.ToString()),
                Jersey = int.Parse(txtJerseyNumber.Text.ToString()),
                Value = int.Parse(txtMarketValue.Text.ToString()),
                Weight = int.Parse(txtWeight.Text.ToString()),
                StrongerFoot = int.Parse(CmbStrongerFoot.SelectedIndex.ToString()),
                Id = Id ?? 0
            };
            if (ChBoxSign.Checked)
            {
                player.IsSigned = true;
            }
            else
            {
                player.IsSigned = false;
            }
            Players lastAdded = null;
            if (Id.HasValue)
                lastAdded = await _aPIServicePlayer.Update<Players>(player);
            else
                lastAdded = await _aPIServicePlayer.Insert<Players>(player);

            if (!Id.HasValue)
            {
                var selectedValues = listBox1.SelectedItems.Cast<Positions>().Select(x => x.Id).ToList();
                for (int i = 0; i < selectedValues.Count(); i++)
                {
                    PlayerPositions playerPosition = new PlayerPositions
                    {
                        PlayerId = lastAdded.Id,
                        PositionId = selectedValues[i]
                    };
                    await _aPIServicePlayer.Insert<PlayerPositions>(playerPosition, "InsertPlayerPosition");
                }
            }
            if (ChBoxSign.Checked)
            {
                if (ChBoxSign.Enabled == false)
                {
                    return;
                }
                else if (Id.HasValue)
                {
                    FrmContract frm = new FrmContract(lastAdded.FirstName, lastAdded.LastName, lastAdded.Id);
                    frm.Show();
                }
                else
                {
                    FrmContract frm = new FrmContract(lastAdded.FirstName, lastAdded.LastName, lastAdded.Id);
                    frm.Show();
                }
            }
        }
    }
}
