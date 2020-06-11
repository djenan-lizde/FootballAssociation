namespace Transfermarkt.WinUI.Forms
{
    partial class FrmClub
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
            this.BtnSaveClub = new System.Windows.Forms.Button();
            this.txtClubName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAbbreviation = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNickname = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDateFounded = new System.Windows.Forms.TextBox();
            this.CmbCities = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMarketValue = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.BtnAddLogo = new System.Windows.Forms.Button();
            this.txtPhotoInput = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.BtnAddStadium = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.CmbLeagues = new System.Windows.Forms.ComboBox();
            this.DgvPlayers = new System.Windows.Forms.DataGridView();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvPlayers)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnSaveClub
            // 
            this.BtnSaveClub.BackColor = System.Drawing.Color.RoyalBlue;
            this.BtnSaveClub.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSaveClub.ForeColor = System.Drawing.Color.White;
            this.BtnSaveClub.Location = new System.Drawing.Point(748, 349);
            this.BtnSaveClub.Name = "BtnSaveClub";
            this.BtnSaveClub.Size = new System.Drawing.Size(139, 37);
            this.BtnSaveClub.TabIndex = 0;
            this.BtnSaveClub.Text = "Save";
            this.BtnSaveClub.UseVisualStyleBackColor = false;
            this.BtnSaveClub.Click += new System.EventHandler(this.BtnSaveClub_Click);
            // 
            // txtClubName
            // 
            this.txtClubName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClubName.Location = new System.Drawing.Point(302, 40);
            this.txtClubName.Name = "txtClubName";
            this.txtClubName.Size = new System.Drawing.Size(218, 24);
            this.txtClubName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(299, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "Club name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(299, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "Abbreviation";
            // 
            // txtAbbreviation
            // 
            this.txtAbbreviation.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAbbreviation.Location = new System.Drawing.Point(302, 111);
            this.txtAbbreviation.Name = "txtAbbreviation";
            this.txtAbbreviation.Size = new System.Drawing.Size(218, 24);
            this.txtAbbreviation.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(607, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 18);
            this.label3.TabIndex = 6;
            this.label3.Text = "Nickname";
            // 
            // txtNickname
            // 
            this.txtNickname.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNickname.Location = new System.Drawing.Point(610, 40);
            this.txtNickname.Name = "txtNickname";
            this.txtNickname.Size = new System.Drawing.Size(218, 24);
            this.txtNickname.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(607, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 18);
            this.label4.TabIndex = 8;
            this.label4.Text = "Date founded";
            // 
            // txtDateFounded
            // 
            this.txtDateFounded.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDateFounded.Location = new System.Drawing.Point(610, 111);
            this.txtDateFounded.Name = "txtDateFounded";
            this.txtDateFounded.Size = new System.Drawing.Size(218, 24);
            this.txtDateFounded.TabIndex = 7;
            // 
            // CmbCities
            // 
            this.CmbCities.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbCities.FormattingEnabled = true;
            this.CmbCities.Location = new System.Drawing.Point(302, 277);
            this.CmbCities.Name = "CmbCities";
            this.CmbCities.Size = new System.Drawing.Size(218, 26);
            this.CmbCities.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(299, 243);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 18);
            this.label5.TabIndex = 10;
            this.label5.Text = "City";
            // 
            // txtMarketValue
            // 
            this.txtMarketValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMarketValue.Location = new System.Drawing.Point(610, 201);
            this.txtMarketValue.Name = "txtMarketValue";
            this.txtMarketValue.Size = new System.Drawing.Size(218, 24);
            this.txtMarketValue.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(607, 162);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(92, 18);
            this.label8.TabIndex = 15;
            this.label8.Text = "Market value";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // BtnAddLogo
            // 
            this.BtnAddLogo.BackColor = System.Drawing.Color.RoyalBlue;
            this.BtnAddLogo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAddLogo.ForeColor = System.Drawing.Color.White;
            this.BtnAddLogo.Location = new System.Drawing.Point(35, 267);
            this.BtnAddLogo.Name = "BtnAddLogo";
            this.BtnAddLogo.Size = new System.Drawing.Size(110, 36);
            this.BtnAddLogo.TabIndex = 16;
            this.BtnAddLogo.Text = "Add logo";
            this.BtnAddLogo.UseVisualStyleBackColor = false;
            this.BtnAddLogo.Click += new System.EventHandler(this.BtnAddLogo_Click);
            // 
            // txtPhotoInput
            // 
            this.txtPhotoInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhotoInput.Location = new System.Drawing.Point(302, 201);
            this.txtPhotoInput.Name = "txtPhotoInput";
            this.txtPhotoInput.Size = new System.Drawing.Size(218, 24);
            this.txtPhotoInput.TabIndex = 18;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(299, 162);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 18);
            this.label7.TabIndex = 19;
            this.label7.Text = "Logo";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point(35, 40);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 200);
            this.pictureBox1.TabIndex = 20;
            this.pictureBox1.TabStop = false;
            // 
            // BtnAddStadium
            // 
            this.BtnAddStadium.BackColor = System.Drawing.Color.RoyalBlue;
            this.BtnAddStadium.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAddStadium.ForeColor = System.Drawing.Color.White;
            this.BtnAddStadium.Location = new System.Drawing.Point(603, 349);
            this.BtnAddStadium.Name = "BtnAddStadium";
            this.BtnAddStadium.Size = new System.Drawing.Size(139, 37);
            this.BtnAddStadium.TabIndex = 21;
            this.BtnAddStadium.Text = "Assign stadium";
            this.BtnAddStadium.UseVisualStyleBackColor = false;
            this.BtnAddStadium.Click += new System.EventHandler(this.BtnAddStadium_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(607, 243);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 18);
            this.label6.TabIndex = 23;
            this.label6.Text = "League";
            // 
            // CmbLeagues
            // 
            this.CmbLeagues.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbLeagues.FormattingEnabled = true;
            this.CmbLeagues.Location = new System.Drawing.Point(610, 277);
            this.CmbLeagues.Name = "CmbLeagues";
            this.CmbLeagues.Size = new System.Drawing.Size(218, 26);
            this.CmbLeagues.TabIndex = 22;
            // 
            // DgvPlayers
            // 
            this.DgvPlayers.AllowUserToAddRows = false;
            this.DgvPlayers.AllowUserToDeleteRows = false;
            this.DgvPlayers.BackgroundColor = System.Drawing.Color.White;
            this.DgvPlayers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvPlayers.Location = new System.Drawing.Point(35, 382);
            this.DgvPlayers.Name = "DgvPlayers";
            this.DgvPlayers.ReadOnly = true;
            this.DgvPlayers.Size = new System.Drawing.Size(549, 150);
            this.DgvPlayers.TabIndex = 24;
            this.DgvPlayers.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(32, 349);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 18);
            this.label9.TabIndex = 25;
            this.label9.Text = "Players: ";
            this.label9.Visible = false;
            // 
            // FrmClub
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(899, 544);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.DgvPlayers);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.CmbLeagues);
            this.Controls.Add(this.BtnAddStadium);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtPhotoInput);
            this.Controls.Add(this.BtnAddLogo);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtMarketValue);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.CmbCities);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtDateFounded);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNickname);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtAbbreviation);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtClubName);
            this.Controls.Add(this.BtnSaveClub);
            this.Name = "FrmClub";
            this.Text = "InsertClub";
            this.Load += new System.EventHandler(this.FrmInsertClub_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvPlayers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnSaveClub;
        private System.Windows.Forms.TextBox txtClubName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAbbreviation;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNickname;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDateFounded;
        private System.Windows.Forms.ComboBox CmbCities;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtMarketValue;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button BtnAddLogo;
        private System.Windows.Forms.TextBox txtPhotoInput;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button BtnAddStadium;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox CmbLeagues;
        private System.Windows.Forms.DataGridView DgvPlayers;
        private System.Windows.Forms.Label label9;
    }
}