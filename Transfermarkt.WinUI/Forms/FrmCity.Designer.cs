namespace Transfermarkt.WinUI.Forms
{
    partial class FrmCity
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
            this.label4 = new System.Windows.Forms.Label();
            this.TxtZipCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtCityName = new System.Windows.Forms.TextBox();
            this.BtnAddCity = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(47, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 18);
            this.label4.TabIndex = 9;
            this.label4.Text = "Zip code";
            // 
            // TxtZipCode
            // 
            this.TxtZipCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtZipCode.Location = new System.Drawing.Point(50, 139);
            this.TxtZipCode.Name = "TxtZipCode";
            this.TxtZipCode.Size = new System.Drawing.Size(190, 24);
            this.TxtZipCode.TabIndex = 8;
            this.TxtZipCode.Validating += new System.ComponentModel.CancelEventHandler(this.TxtZipCode_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(47, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 18);
            this.label1.TabIndex = 11;
            this.label1.Text = "City name";
            // 
            // TxtCityName
            // 
            this.TxtCityName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtCityName.Location = new System.Drawing.Point(50, 53);
            this.TxtCityName.Name = "TxtCityName";
            this.TxtCityName.Size = new System.Drawing.Size(190, 24);
            this.TxtCityName.TabIndex = 10;
            this.TxtCityName.Validating += new System.ComponentModel.CancelEventHandler(this.TxtCityName_Validating);
            // 
            // BtnAddCity
            // 
            this.BtnAddCity.BackColor = System.Drawing.Color.RoyalBlue;
            this.BtnAddCity.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAddCity.ForeColor = System.Drawing.Color.White;
            this.BtnAddCity.Location = new System.Drawing.Point(301, 197);
            this.BtnAddCity.Name = "BtnAddCity";
            this.BtnAddCity.Size = new System.Drawing.Size(127, 44);
            this.BtnAddCity.TabIndex = 17;
            this.BtnAddCity.Text = "Save";
            this.BtnAddCity.UseVisualStyleBackColor = false;
            this.BtnAddCity.Click += new System.EventHandler(this.BtnAddCity_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // FrmCity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 285);
            this.Controls.Add(this.BtnAddCity);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtCityName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TxtZipCode);
            this.Name = "FrmCity";
            this.Text = "FrmCity";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtZipCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtCityName;
        private System.Windows.Forms.Button BtnAddCity;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}