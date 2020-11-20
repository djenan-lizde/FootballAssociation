namespace Transfermarkt.WinUI.Forms
{
    partial class FrmMatchesList
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DgvMatches = new System.Windows.Forms.DataGridView();
            this.BtnNewSeason = new System.Windows.Forms.Button();
            this.BtnRefresh = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvMatches)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DgvMatches);
            this.groupBox1.Location = new System.Drawing.Point(12, 105);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(776, 333);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Matches";
            // 
            // DgvMatches
            // 
            this.DgvMatches.AllowUserToAddRows = false;
            this.DgvMatches.AllowUserToDeleteRows = false;
            this.DgvMatches.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvMatches.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvMatches.Location = new System.Drawing.Point(3, 16);
            this.DgvMatches.Name = "DgvMatches";
            this.DgvMatches.ReadOnly = true;
            this.DgvMatches.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvMatches.Size = new System.Drawing.Size(770, 314);
            this.DgvMatches.TabIndex = 0;
            this.DgvMatches.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.DgvMatches_MouseDoubleClick);
            // 
            // BtnNewSeason
            // 
            this.BtnNewSeason.BackColor = System.Drawing.Color.RoyalBlue;
            this.BtnNewSeason.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnNewSeason.ForeColor = System.Drawing.Color.White;
            this.BtnNewSeason.Location = new System.Drawing.Point(578, 35);
            this.BtnNewSeason.Name = "BtnNewSeason";
            this.BtnNewSeason.Size = new System.Drawing.Size(159, 46);
            this.BtnNewSeason.TabIndex = 1;
            this.BtnNewSeason.Text = "New season";
            this.BtnNewSeason.UseVisualStyleBackColor = false;
            this.BtnNewSeason.Click += new System.EventHandler(this.BtnNewSeason_Click);
            // 
            // BtnRefresh
            // 
            this.BtnRefresh.BackColor = System.Drawing.Color.RoyalBlue;
            this.BtnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRefresh.ForeColor = System.Drawing.Color.White;
            this.BtnRefresh.Location = new System.Drawing.Point(360, 35);
            this.BtnRefresh.Name = "BtnRefresh";
            this.BtnRefresh.Size = new System.Drawing.Size(159, 46);
            this.BtnRefresh.TabIndex = 2;
            this.BtnRefresh.Text = "Refresh";
            this.BtnRefresh.UseVisualStyleBackColor = false;
            this.BtnRefresh.Click += new System.EventHandler(this.BtnRefresh_Click);
            // 
            // FrmMatchesList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BtnRefresh);
            this.Controls.Add(this.BtnNewSeason);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmMatchesList";
            this.Text = "FrmMatchesList";
            this.Load += new System.EventHandler(this.FrmMatchesList_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvMatches)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView DgvMatches;
        private System.Windows.Forms.Button BtnNewSeason;
        private System.Windows.Forms.Button BtnRefresh;
    }
}