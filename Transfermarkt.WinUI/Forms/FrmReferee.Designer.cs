namespace Transfermarkt.WinUI.Forms
{
    partial class FrmReferee
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
            this.TxtFirstName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtMiddleName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtLastName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.CmbCities = new System.Windows.Forms.ComboBox();
            this.BtnSaveReferee = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.BtnAddCity = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // TxtFirstName
            // 
            this.TxtFirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtFirstName.Location = new System.Drawing.Point(43, 92);
            this.TxtFirstName.Name = "TxtFirstName";
            this.TxtFirstName.Size = new System.Drawing.Size(158, 24);
            this.TxtFirstName.TabIndex = 0;
            this.TxtFirstName.Validating += new System.ComponentModel.CancelEventHandler(this.TxtFirstName_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(40, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "First name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(236, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "Middle name";
            // 
            // TxtMiddleName
            // 
            this.TxtMiddleName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtMiddleName.Location = new System.Drawing.Point(239, 92);
            this.TxtMiddleName.Name = "TxtMiddleName";
            this.TxtMiddleName.Size = new System.Drawing.Size(158, 24);
            this.TxtMiddleName.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(432, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 18);
            this.label3.TabIndex = 5;
            this.label3.Text = "Last name";
            // 
            // TxtLastName
            // 
            this.TxtLastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtLastName.Location = new System.Drawing.Point(435, 92);
            this.TxtLastName.Name = "TxtLastName";
            this.TxtLastName.Size = new System.Drawing.Size(158, 24);
            this.TxtLastName.TabIndex = 4;
            this.TxtLastName.Validating += new System.ComponentModel.CancelEventHandler(this.TxtLastName_Validating);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(40, 151);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 18);
            this.label4.TabIndex = 6;
            this.label4.Text = "City";
            // 
            // CmbCities
            // 
            this.CmbCities.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbCities.FormattingEnabled = true;
            this.CmbCities.Location = new System.Drawing.Point(43, 179);
            this.CmbCities.Name = "CmbCities";
            this.CmbCities.Size = new System.Drawing.Size(158, 26);
            this.CmbCities.TabIndex = 7;
            this.CmbCities.MouseHover += new System.EventHandler(this.CmbCities_MouseHover);
            this.CmbCities.Validating += new System.ComponentModel.CancelEventHandler(this.CmbCities_Validating);
            // 
            // BtnSaveReferee
            // 
            this.BtnSaveReferee.BackColor = System.Drawing.Color.RoyalBlue;
            this.BtnSaveReferee.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSaveReferee.ForeColor = System.Drawing.Color.White;
            this.BtnSaveReferee.Location = new System.Drawing.Point(478, 170);
            this.BtnSaveReferee.Name = "BtnSaveReferee";
            this.BtnSaveReferee.Size = new System.Drawing.Size(115, 43);
            this.BtnSaveReferee.TabIndex = 8;
            this.BtnSaveReferee.Text = "Save";
            this.BtnSaveReferee.UseVisualStyleBackColor = false;
            this.BtnSaveReferee.Click += new System.EventHandler(this.BtnSaveReferee_Click);
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
            this.BtnAddCity.Location = new System.Drawing.Point(239, 176);
            this.BtnAddCity.Name = "BtnAddCity";
            this.BtnAddCity.Size = new System.Drawing.Size(79, 29);
            this.BtnAddCity.TabIndex = 29;
            this.BtnAddCity.Text = "Add city";
            this.BtnAddCity.UseVisualStyleBackColor = false;
            this.BtnAddCity.Click += new System.EventHandler(this.BtnAddCity_Click);
            // 
            // FrmReferee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(621, 266);
            this.Controls.Add(this.BtnAddCity);
            this.Controls.Add(this.BtnSaveReferee);
            this.Controls.Add(this.CmbCities);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TxtLastName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TxtMiddleName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtFirstName);
            this.Name = "FrmReferee";
            this.Text = "FrmReferee";
            this.Load += new System.EventHandler(this.FrmReferee_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtFirstName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtMiddleName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtLastName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox CmbCities;
        private System.Windows.Forms.Button BtnSaveReferee;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Button BtnAddCity;
    }
}