namespace Transfermarkt.WinUI.Forms
{
    partial class FrmStadium
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
            this.txtStadiumName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCapacity = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDateBuilt = new System.Windows.Forms.TextBox();
            this.lblClubName = new System.Windows.Forms.Label();
            this.BtnSaveStadium = new System.Windows.Forms.Button();
            this.txtStadiumId = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtStadiumName
            // 
            this.txtStadiumName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStadiumName.Location = new System.Drawing.Point(44, 135);
            this.txtStadiumName.Name = "txtStadiumName";
            this.txtStadiumName.Size = new System.Drawing.Size(203, 24);
            this.txtStadiumName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(41, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Stadium name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(41, 197);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "Capacity";
            // 
            // txtCapacity
            // 
            this.txtCapacity.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCapacity.Location = new System.Drawing.Point(44, 228);
            this.txtCapacity.Name = "txtCapacity";
            this.txtCapacity.Size = new System.Drawing.Size(203, 24);
            this.txtCapacity.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(310, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 18);
            this.label3.TabIndex = 5;
            this.label3.Text = "Date built";
            // 
            // txtDateBuilt
            // 
            this.txtDateBuilt.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDateBuilt.Location = new System.Drawing.Point(313, 135);
            this.txtDateBuilt.Name = "txtDateBuilt";
            this.txtDateBuilt.Size = new System.Drawing.Size(203, 24);
            this.txtDateBuilt.TabIndex = 4;
            // 
            // lblClubName
            // 
            this.lblClubName.AutoSize = true;
            this.lblClubName.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClubName.Location = new System.Drawing.Point(161, 36);
            this.lblClubName.Name = "lblClubName";
            this.lblClubName.Size = new System.Drawing.Size(86, 31);
            this.lblClubName.TabIndex = 6;
            this.lblClubName.Text = "label4";
            // 
            // BtnSaveStadium
            // 
            this.BtnSaveStadium.BackColor = System.Drawing.Color.RoyalBlue;
            this.BtnSaveStadium.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSaveStadium.ForeColor = System.Drawing.Color.White;
            this.BtnSaveStadium.Location = new System.Drawing.Point(335, 250);
            this.BtnSaveStadium.Name = "BtnSaveStadium";
            this.BtnSaveStadium.Size = new System.Drawing.Size(149, 44);
            this.BtnSaveStadium.TabIndex = 7;
            this.BtnSaveStadium.Text = "Save";
            this.BtnSaveStadium.UseVisualStyleBackColor = false;
            this.BtnSaveStadium.Click += new System.EventHandler(this.BtnSaveStadium_Click);
            // 
            // txtStadiumId
            // 
            this.txtStadiumId.Location = new System.Drawing.Point(313, 194);
            this.txtStadiumId.Name = "txtStadiumId";
            this.txtStadiumId.Size = new System.Drawing.Size(100, 20);
            this.txtStadiumId.TabIndex = 8;
            this.txtStadiumId.Visible = false;
            // 
            // FrmStadium
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 350);
            this.Controls.Add(this.txtStadiumId);
            this.Controls.Add(this.BtnSaveStadium);
            this.Controls.Add(this.lblClubName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDateBuilt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCapacity);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtStadiumName);
            this.Name = "FrmStadium";
            this.Text = "FrmStadium";
            this.Load += new System.EventHandler(this.FrmStadium_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtStadiumName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCapacity;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDateBuilt;
        private System.Windows.Forms.Label lblClubName;
        private System.Windows.Forms.Button BtnSaveStadium;
        private System.Windows.Forms.TextBox txtStadiumId;
    }
}