namespace Transfermarkt.WinUI
{
    partial class FrmIndex
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.clubsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddClubToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.leaguesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddLeagueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddPlayerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PlayersListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.matchesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddMatchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.matchesListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refereeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addRefereeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DgvLeagues = new System.Windows.Forms.DataGridView();
            this.lblHello = new System.Windows.Forms.Label();
            this.BtnReport = new System.Windows.Forms.Button();
            this.BtnRefresh = new System.Windows.Forms.Button();
            this.adminPanelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvLeagues)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clubsToolStripMenuItem,
            this.leaguesToolStripMenuItem,
            this.playersToolStripMenuItem,
            this.matchesToolStripMenuItem,
            this.refereeToolStripMenuItem,
            this.adminPanelToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1222, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            // 
            // clubsToolStripMenuItem
            // 
            this.clubsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddClubToolStripMenuItem});
            this.clubsToolStripMenuItem.Name = "clubsToolStripMenuItem";
            this.clubsToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.clubsToolStripMenuItem.Text = "Clubs";
            // 
            // AddClubToolStripMenuItem
            // 
            this.AddClubToolStripMenuItem.Name = "AddClubToolStripMenuItem";
            this.AddClubToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.AddClubToolStripMenuItem.Text = "Add club";
            this.AddClubToolStripMenuItem.Click += new System.EventHandler(this.AddClubToolStripMenuItem_Click);
            // 
            // leaguesToolStripMenuItem
            // 
            this.leaguesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddLeagueToolStripMenuItem});
            this.leaguesToolStripMenuItem.Name = "leaguesToolStripMenuItem";
            this.leaguesToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.leaguesToolStripMenuItem.Text = "Leagues";
            // 
            // AddLeagueToolStripMenuItem
            // 
            this.AddLeagueToolStripMenuItem.Name = "AddLeagueToolStripMenuItem";
            this.AddLeagueToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.AddLeagueToolStripMenuItem.Text = "Add league";
            this.AddLeagueToolStripMenuItem.Click += new System.EventHandler(this.AddLeagueToolStripMenuItem_Click);
            // 
            // playersToolStripMenuItem
            // 
            this.playersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddPlayerToolStripMenuItem,
            this.PlayersListToolStripMenuItem});
            this.playersToolStripMenuItem.Name = "playersToolStripMenuItem";
            this.playersToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.playersToolStripMenuItem.Text = "Players";
            // 
            // AddPlayerToolStripMenuItem
            // 
            this.AddPlayerToolStripMenuItem.Name = "AddPlayerToolStripMenuItem";
            this.AddPlayerToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.AddPlayerToolStripMenuItem.Text = "Add player";
            this.AddPlayerToolStripMenuItem.Click += new System.EventHandler(this.AddPlayerToolStripMenuItem_Click);
            // 
            // PlayersListToolStripMenuItem
            // 
            this.PlayersListToolStripMenuItem.Name = "PlayersListToolStripMenuItem";
            this.PlayersListToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.PlayersListToolStripMenuItem.Text = "Players list";
            this.PlayersListToolStripMenuItem.Click += new System.EventHandler(this.PlayersListToolStripMenuItem_Click);
            // 
            // matchesToolStripMenuItem
            // 
            this.matchesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddMatchToolStripMenuItem,
            this.matchesListToolStripMenuItem});
            this.matchesToolStripMenuItem.Name = "matchesToolStripMenuItem";
            this.matchesToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.matchesToolStripMenuItem.Text = "Matches";
            // 
            // AddMatchToolStripMenuItem
            // 
            this.AddMatchToolStripMenuItem.Name = "AddMatchToolStripMenuItem";
            this.AddMatchToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.AddMatchToolStripMenuItem.Text = "Add match";
            this.AddMatchToolStripMenuItem.Click += new System.EventHandler(this.AddMatchToolStripMenuItem_Click);
            // 
            // matchesListToolStripMenuItem
            // 
            this.matchesListToolStripMenuItem.Name = "matchesListToolStripMenuItem";
            this.matchesListToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.matchesListToolStripMenuItem.Text = "Matches list";
            this.matchesListToolStripMenuItem.Click += new System.EventHandler(this.MatchesListToolStripMenuItem_Click);
            // 
            // refereeToolStripMenuItem
            // 
            this.refereeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addRefereeToolStripMenuItem});
            this.refereeToolStripMenuItem.Name = "refereeToolStripMenuItem";
            this.refereeToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.refereeToolStripMenuItem.Text = "Referee";
            // 
            // addRefereeToolStripMenuItem
            // 
            this.addRefereeToolStripMenuItem.Name = "addRefereeToolStripMenuItem";
            this.addRefereeToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.addRefereeToolStripMenuItem.Text = "Add referee";
            this.addRefereeToolStripMenuItem.Click += new System.EventHandler(this.AddRefereeToolStripMenuItem_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 408);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1222, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "StatusStrip";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(39, 17);
            this.toolStripStatusLabel.Text = "Status";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DgvLeagues);
            this.groupBox1.Location = new System.Drawing.Point(12, 72);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(484, 160);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Leagues";
            // 
            // DgvLeagues
            // 
            this.DgvLeagues.AllowUserToAddRows = false;
            this.DgvLeagues.AllowUserToDeleteRows = false;
            this.DgvLeagues.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvLeagues.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvLeagues.Location = new System.Drawing.Point(3, 16);
            this.DgvLeagues.Name = "DgvLeagues";
            this.DgvLeagues.ReadOnly = true;
            this.DgvLeagues.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvLeagues.Size = new System.Drawing.Size(478, 141);
            this.DgvLeagues.TabIndex = 0;
            this.DgvLeagues.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.DgvLeagues_MouseDoubleClick);
            // 
            // lblHello
            // 
            this.lblHello.AutoSize = true;
            this.lblHello.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHello.Location = new System.Drawing.Point(535, 40);
            this.lblHello.Name = "lblHello";
            this.lblHello.Size = new System.Drawing.Size(0, 31);
            this.lblHello.TabIndex = 6;
            // 
            // BtnReport
            // 
            this.BtnReport.BackColor = System.Drawing.Color.RoyalBlue;
            this.BtnReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnReport.ForeColor = System.Drawing.Color.White;
            this.BtnReport.Location = new System.Drawing.Point(359, 273);
            this.BtnReport.Name = "BtnReport";
            this.BtnReport.Size = new System.Drawing.Size(134, 37);
            this.BtnReport.TabIndex = 10;
            this.BtnReport.Text = "Report";
            this.BtnReport.UseVisualStyleBackColor = false;
            this.BtnReport.Click += new System.EventHandler(this.BtnReport_Click);
            // 
            // BtnRefresh
            // 
            this.BtnRefresh.BackColor = System.Drawing.Color.RoyalBlue;
            this.BtnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRefresh.ForeColor = System.Drawing.Color.White;
            this.BtnRefresh.Location = new System.Drawing.Point(199, 273);
            this.BtnRefresh.Name = "BtnRefresh";
            this.BtnRefresh.Size = new System.Drawing.Size(134, 37);
            this.BtnRefresh.TabIndex = 12;
            this.BtnRefresh.Text = "Refresh";
            this.BtnRefresh.UseVisualStyleBackColor = false;
            this.BtnRefresh.Click += new System.EventHandler(this.BtnRefresh_Click);
            // 
            // adminPanelToolStripMenuItem
            // 
            this.adminPanelToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usersToolStripMenuItem});
            this.adminPanelToolStripMenuItem.Name = "adminPanelToolStripMenuItem";
            this.adminPanelToolStripMenuItem.Size = new System.Drawing.Size(87, 20);
            this.adminPanelToolStripMenuItem.Text = "Admin panel";
            // 
            // usersToolStripMenuItem
            // 
            this.usersToolStripMenuItem.Name = "usersToolStripMenuItem";
            this.usersToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.usersToolStripMenuItem.Text = "Users";
            this.usersToolStripMenuItem.Click += new System.EventHandler(this.UsersToolStripMenuItem_Click);
            // 
            // FrmIndex
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1222, 430);
            this.Controls.Add(this.BtnRefresh);
            this.Controls.Add(this.BtnReport);
            this.Controls.Add(this.lblHello);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "FrmIndex";
            this.Text = "FrmIndex";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmIndex_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvLeagues)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripMenuItem clubsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AddClubToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem leaguesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AddLeagueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem playersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AddPlayerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PlayersListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem matchesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AddMatchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refereeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addRefereeToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView DgvLeagues;
        private System.Windows.Forms.ToolStripMenuItem matchesListToolStripMenuItem;
        private System.Windows.Forms.Label lblHello;
        private System.Windows.Forms.Button BtnReport;
        private System.Windows.Forms.Button BtnRefresh;
        private System.Windows.Forms.ToolStripMenuItem adminPanelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usersToolStripMenuItem;
    }
}



