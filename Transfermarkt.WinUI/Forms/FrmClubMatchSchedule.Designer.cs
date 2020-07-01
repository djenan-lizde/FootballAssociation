namespace Transfermarkt.WinUI.Forms
{
    partial class FrmClubMatchSchedule
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
            this.LblClubName = new System.Windows.Forms.Label();
            this.PicBoxLogoClub = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvMatches)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxLogoClub)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DgvMatches);
            this.groupBox1.Location = new System.Drawing.Point(12, 202);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(655, 196);
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
            this.DgvMatches.Size = new System.Drawing.Size(649, 177);
            this.DgvMatches.TabIndex = 0;
            // 
            // LblClubName
            // 
            this.LblClubName.AutoSize = true;
            this.LblClubName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblClubName.Location = new System.Drawing.Point(395, 93);
            this.LblClubName.Name = "LblClubName";
            this.LblClubName.Size = new System.Drawing.Size(115, 25);
            this.LblClubName.TabIndex = 1;
            this.LblClubName.Text = "Club name";
            // 
            // PicBoxLogoClub
            // 
            this.PicBoxLogoClub.Location = new System.Drawing.Point(103, 26);
            this.PicBoxLogoClub.Name = "PicBoxLogoClub";
            this.PicBoxLogoClub.Size = new System.Drawing.Size(150, 150);
            this.PicBoxLogoClub.TabIndex = 2;
            this.PicBoxLogoClub.TabStop = false;
            // 
            // FrmClubMatchSchedule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(679, 410);
            this.Controls.Add(this.PicBoxLogoClub);
            this.Controls.Add(this.LblClubName);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmClubMatchSchedule";
            this.Text = "FrmClubMatchSchedule";
            this.Load += new System.EventHandler(this.FrmClubMatchSchedule_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvMatches)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxLogoClub)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView DgvMatches;
        private System.Windows.Forms.Label LblClubName;
        private System.Windows.Forms.PictureBox PicBoxLogoClub;
    }
}