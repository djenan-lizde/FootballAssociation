namespace Transfermarkt.WinUI.Forms
{
    partial class FrmMatch
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
            this.TxtDateGame = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtMatchStart = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CmbHomeClub = new System.Windows.Forms.ComboBox();
            this.CmbAwayClub = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.BtnSave = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtStadium = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.CmbReferees = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // TxtDateGame
            // 
            this.TxtDateGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtDateGame.Location = new System.Drawing.Point(52, 72);
            this.TxtDateGame.Name = "TxtDateGame";
            this.TxtDateGame.Size = new System.Drawing.Size(200, 24);
            this.TxtDateGame.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(49, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Match date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(594, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 18);
            this.label3.TabIndex = 5;
            this.label3.Text = "Match start";
            // 
            // TxtMatchStart
            // 
            this.TxtMatchStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtMatchStart.Location = new System.Drawing.Point(597, 72);
            this.TxtMatchStart.Name = "TxtMatchStart";
            this.TxtMatchStart.Size = new System.Drawing.Size(200, 24);
            this.TxtMatchStart.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(49, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 18);
            this.label2.TabIndex = 6;
            this.label2.Text = "Home club";
            // 
            // CmbHomeClub
            // 
            this.CmbHomeClub.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbHomeClub.FormattingEnabled = true;
            this.CmbHomeClub.Location = new System.Drawing.Point(52, 165);
            this.CmbHomeClub.Name = "CmbHomeClub";
            this.CmbHomeClub.Size = new System.Drawing.Size(200, 26);
            this.CmbHomeClub.TabIndex = 7;
            this.CmbHomeClub.SelectionChangeCommitted += new System.EventHandler(this.CmbHomeClub_SelectionChangeCommitted);
            // 
            // CmbAwayClub
            // 
            this.CmbAwayClub.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbAwayClub.FormattingEnabled = true;
            this.CmbAwayClub.Location = new System.Drawing.Point(597, 165);
            this.CmbAwayClub.Name = "CmbAwayClub";
            this.CmbAwayClub.Size = new System.Drawing.Size(200, 26);
            this.CmbAwayClub.TabIndex = 11;
            this.CmbAwayClub.SelectionChangeCommitted += new System.EventHandler(this.CmbAwayClub_SelectionChangeCommitted);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(594, 135);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 18);
            this.label5.TabIndex = 10;
            this.label5.Text = "Away club";
            // 
            // BtnSave
            // 
            this.BtnSave.BackColor = System.Drawing.Color.RoyalBlue;
            this.BtnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSave.ForeColor = System.Drawing.Color.White;
            this.BtnSave.Location = new System.Drawing.Point(367, 369);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(116, 48);
            this.BtnSave.TabIndex = 12;
            this.BtnSave.Text = "Save";
            this.BtnSave.UseVisualStyleBackColor = false;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(386, 135);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 18);
            this.label4.TabIndex = 8;
            this.label4.Text = "Stadium";
            // 
            // TxtStadium
            // 
            this.TxtStadium.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtStadium.Location = new System.Drawing.Point(271, 167);
            this.TxtStadium.Name = "TxtStadium";
            this.TxtStadium.ReadOnly = true;
            this.TxtStadium.Size = new System.Drawing.Size(302, 24);
            this.TxtStadium.TabIndex = 13;
            this.TxtStadium.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point(52, 217);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 200);
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox2.Location = new System.Drawing.Point(597, 216);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(200, 200);
            this.pictureBox2.TabIndex = 15;
            this.pictureBox2.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(365, 259);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(118, 73);
            this.label6.TabIndex = 16;
            this.label6.Text = "VS";
            // 
            // CmbReferees
            // 
            this.CmbReferees.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbReferees.FormattingEnabled = true;
            this.CmbReferees.Location = new System.Drawing.Point(271, 72);
            this.CmbReferees.Name = "CmbReferees";
            this.CmbReferees.Size = new System.Drawing.Size(302, 26);
            this.CmbReferees.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(386, 38);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 18);
            this.label7.TabIndex = 18;
            this.label7.Text = "Referee";
            // 
            // FrmMatch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(862, 474);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.CmbReferees);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.TxtStadium);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.CmbAwayClub);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.CmbHomeClub);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TxtMatchStart);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtDateGame);
            this.Name = "FrmMatch";
            this.Text = "FrmMatch";
            this.Load += new System.EventHandler(this.FrmMatch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtDateGame;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtMatchStart;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CmbHomeClub;
        private System.Windows.Forms.ComboBox CmbAwayClub;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtStadium;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox CmbReferees;
        private System.Windows.Forms.Label label7;
    }
}