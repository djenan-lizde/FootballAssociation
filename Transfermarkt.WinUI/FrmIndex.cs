using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Transfermarkt.Models;
using Transfermarkt.WinUI.Forms;

namespace Transfermarkt.WinUI
{
    public partial class FrmIndex : Form
    {
        private int childFormNumber = 0;
        private readonly APIService _aPIServiceLeague = new APIService("Leagues");

        private string UserName { get; set; }

        public FrmIndex(string userName)
        {
            InitializeComponent();
            UserName = userName;
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form
            {
                MdiParent = this,
                Text = "Window " + childFormNumber++
            };
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal),
                Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"
            };
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal),
                Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"
            };
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        //private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        //}

        //private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        //}

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void AddClubToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmClub frm = new FrmClub
            {
                MdiParent = this
            };
            frm.Show();
        }

        private void AddPlayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPlayer frm = new FrmPlayer();
            frm.Show();
        }

        private void PlayersListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPlayersList frm = new FrmPlayersList();
            frm.Show();
        }

        private void AddLeagueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmLeague frm = new FrmLeague();
            frm.Show();
        }

        private void AddMatchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMatch frm = new FrmMatch();
            frm.Show();
        }

        private void AddRefereeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmReferee frm = new FrmReferee();
            frm.Show();
        }

        private async void FrmIndex_Load(object sender, EventArgs e)
        {
            var result = await _aPIServiceLeague.Get<List<League>>();
            lblHello.Text = $"Hello, {UserName}";
            DgvLeagues.DataSource = result;
        }

        private void DgvLeagues_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var id = DgvLeagues.SelectedRows[0].Cells[0].Value;

            if ((int)id == 0)
            {
                MessageBox.Show("You need to select a league.", "Error", MessageBoxButtons.OK);
                return;
            }

            FrmClubsList frmClubsList = new FrmClubsList(int.Parse(id.ToString()));
            frmClubsList.Show();
        }

        private void MatchesListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMatchesList frm = new FrmMatchesList();
            frm.Show();
        }

        private void BtnReport_Click(object sender, EventArgs e)
        {
            FrmReport frm = new FrmReport();
            frm.Show();
        }
    }
}
