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
            this.components = new System.ComponentModel.Container();
            this.BtnSaveClub = new System.Windows.Forms.Button();
            this.TxtClubName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtAbbreviation = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtNickname = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtDateFounded = new System.Windows.Forms.TextBox();
            this.CmbCities = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TxtMarketValue = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.BtnAddLogo = new System.Windows.Forms.Button();
            this.TxtPhotoInput = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.DgvPlayers = new System.Windows.Forms.DataGridView();
            this.label9 = new System.Windows.Forms.Label();
            this.BtnMatchSchedule = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.BtnAddCity = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvPlayers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnSaveClub
            // 
            this.BtnSaveClub.BackColor = System.Drawing.Color.RoyalBlue;
            this.BtnSaveClub.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSaveClub.ForeColor = System.Drawing.Color.White;
            this.BtnSaveClub.Location = new System.Drawing.Point(689, 266);
            this.BtnSaveClub.Name = "BtnSaveClub";
            this.BtnSaveClub.Size = new System.Drawing.Size(139, 37);
            this.BtnSaveClub.TabIndex = 0;
            this.BtnSaveClub.Text = "Save";
            this.BtnSaveClub.UseVisualStyleBackColor = false;
            this.BtnSaveClub.Click += new System.EventHandler(this.BtnSaveClub_Click);
            // 
            // TxtClubName
            // 
            this.TxtClubName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtClubName.Location = new System.Drawing.Point(302, 40);
            this.TxtClubName.Name = "TxtClubName";
            this.TxtClubName.Size = new System.Drawing.Size(218, 24);
            this.TxtClubName.TabIndex = 1;
            this.TxtClubName.Validating += new System.ComponentModel.CancelEventHandler(this.TxtClubName_Validating);
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
            // TxtAbbreviation
            // 
            this.TxtAbbreviation.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtAbbreviation.Location = new System.Drawing.Point(302, 111);
            this.TxtAbbreviation.Name = "TxtAbbreviation";
            this.TxtAbbreviation.Size = new System.Drawing.Size(218, 24);
            this.TxtAbbreviation.TabIndex = 3;
            this.TxtAbbreviation.Validating += new System.ComponentModel.CancelEventHandler(this.TxtAbbreviation_Validating);
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
            // TxtNickname
            // 
            this.TxtNickname.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtNickname.Location = new System.Drawing.Point(610, 40);
            this.TxtNickname.Name = "TxtNickname";
            this.TxtNickname.Size = new System.Drawing.Size(218, 24);
            this.TxtNickname.TabIndex = 5;
            this.TxtNickname.Validating += new System.ComponentModel.CancelEventHandler(this.TxtNickname_Validating);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(607, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(202, 18);
            this.label4.TabIndex = 8;
            this.label4.Text = "Date founded (MM.DD.YYYY)";
            // 
            // TxtDateFounded
            // 
            this.TxtDateFounded.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtDateFounded.Location = new System.Drawing.Point(610, 111);
            this.TxtDateFounded.Name = "TxtDateFounded";
            this.TxtDateFounded.Size = new System.Drawing.Size(218, 24);
            this.TxtDateFounded.TabIndex = 7;
            this.TxtDateFounded.Validating += new System.ComponentModel.CancelEventHandler(this.TxtDateFounded_Validating);
            // 
            // CmbCities
            // 
            this.CmbCities.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbCities.FormattingEnabled = true;
            this.CmbCities.Location = new System.Drawing.Point(302, 277);
            this.CmbCities.Name = "CmbCities";
            this.CmbCities.Size = new System.Drawing.Size(218, 26);
            this.CmbCities.TabIndex = 9;
            this.CmbCities.MouseHover += new System.EventHandler(this.CmbCities_MouseHover);
            this.CmbCities.Validating += new System.ComponentModel.CancelEventHandler(this.CmbCities_Validating);
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
            // TxtMarketValue
            // 
            this.TxtMarketValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtMarketValue.Location = new System.Drawing.Point(610, 201);
            this.TxtMarketValue.Name = "TxtMarketValue";
            this.TxtMarketValue.Size = new System.Drawing.Size(218, 24);
            this.TxtMarketValue.TabIndex = 13;
            this.TxtMarketValue.Validating += new System.ComponentModel.CancelEventHandler(this.TxtMarketValue_Validating);
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
            // TxtPhotoInput
            // 
            this.TxtPhotoInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtPhotoInput.Location = new System.Drawing.Point(302, 201);
            this.TxtPhotoInput.Name = "TxtPhotoInput";
            this.TxtPhotoInput.Size = new System.Drawing.Size(218, 24);
            this.TxtPhotoInput.TabIndex = 18;
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
            // BtnMatchSchedule
            // 
            this.BtnMatchSchedule.BackColor = System.Drawing.Color.RoyalBlue;
            this.BtnMatchSchedule.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnMatchSchedule.ForeColor = System.Drawing.Color.White;
            this.BtnMatchSchedule.Location = new System.Drawing.Point(658, 495);
            this.BtnMatchSchedule.Name = "BtnMatchSchedule";
            this.BtnMatchSchedule.Size = new System.Drawing.Size(139, 37);
            this.BtnMatchSchedule.TabIndex = 27;
            this.BtnMatchSchedule.Text = "Match schedule";
            this.BtnMatchSchedule.UseVisualStyleBackColor = false;
            this.BtnMatchSchedule.Visible = false;
            this.BtnMatchSchedule.Click += new System.EventHandler(this.BtnMatchSchedule_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // BtnAddCity
            // 
            this.BtnAddCity.BackColor = System.Drawing.Color.RoyalBlue;
            this.BtnAddCity.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAddCity.ForeColor = System.Drawing.Color.White;
            this.BtnAddCity.Location = new System.Drawing.Point(535, 275);
            this.BtnAddCity.Name = "BtnAddCity";
            this.BtnAddCity.Size = new System.Drawing.Size(79, 29);
            this.BtnAddCity.TabIndex = 28;
            this.BtnAddCity.Text = "Add city";
            this.BtnAddCity.UseVisualStyleBackColor = false;
            this.BtnAddCity.Click += new System.EventHandler(this.BtnAddCity_Click);
            // 
            // FrmClub
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(899, 544);
            this.Controls.Add(this.BtnAddCity);
            this.Controls.Add(this.BtnMatchSchedule);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.DgvPlayers);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.TxtPhotoInput);
            this.Controls.Add(this.BtnAddLogo);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.TxtMarketValue);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.CmbCities);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TxtDateFounded);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TxtNickname);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TxtAbbreviation);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtClubName);
            this.Controls.Add(this.BtnSaveClub);
            this.Name = "FrmClub";
            this.Text = "InsertClub";
            this.Load += new System.EventHandler(this.FrmInsertClub_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvPlayers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnSaveClub;
        private System.Windows.Forms.TextBox TxtClubName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtAbbreviation;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtNickname;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtDateFounded;
        private System.Windows.Forms.ComboBox CmbCities;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TxtMarketValue;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button BtnAddLogo;
        private System.Windows.Forms.TextBox TxtPhotoInput;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView DgvPlayers;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button BtnMatchSchedule;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Button BtnAddCity;
    }
}