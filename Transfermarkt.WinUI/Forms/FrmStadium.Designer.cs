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
            this.components = new System.ComponentModel.Container();
            this.TxtStadiumName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtCapacity = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtDateBuilt = new System.Windows.Forms.TextBox();
            this.lblClubName = new System.Windows.Forms.Label();
            this.BtnSaveStadium = new System.Windows.Forms.Button();
            this.txtStadiumId = new System.Windows.Forms.TextBox();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // TxtStadiumName
            // 
            this.TxtStadiumName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtStadiumName.Location = new System.Drawing.Point(44, 135);
            this.TxtStadiumName.Name = "TxtStadiumName";
            this.TxtStadiumName.Size = new System.Drawing.Size(203, 24);
            this.TxtStadiumName.TabIndex = 0;
            this.TxtStadiumName.Validating += new System.ComponentModel.CancelEventHandler(this.TxtStadiumName_Validating);
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
            // TxtCapacity
            // 
            this.TxtCapacity.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtCapacity.Location = new System.Drawing.Point(44, 228);
            this.TxtCapacity.Name = "TxtCapacity";
            this.TxtCapacity.Size = new System.Drawing.Size(203, 24);
            this.TxtCapacity.TabIndex = 2;
            this.TxtCapacity.Validating += new System.ComponentModel.CancelEventHandler(this.TxtCapacity_Validating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(332, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(175, 18);
            this.label3.TabIndex = 5;
            this.label3.Text = "Date built (MM.DD.YYYY)";
            // 
            // TxtDateBuilt
            // 
            this.TxtDateBuilt.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtDateBuilt.Location = new System.Drawing.Point(313, 135);
            this.TxtDateBuilt.Name = "TxtDateBuilt";
            this.TxtDateBuilt.Size = new System.Drawing.Size(203, 24);
            this.TxtDateBuilt.TabIndex = 4;
            this.TxtDateBuilt.Validating += new System.ComponentModel.CancelEventHandler(this.TxtDateBuilt_Validating);
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
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
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
            this.Controls.Add(this.TxtDateBuilt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TxtCapacity);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtStadiumName);
            this.Name = "FrmStadium";
            this.Text = "FrmStadium";
            this.Load += new System.EventHandler(this.FrmStadium_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtStadiumName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtCapacity;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtDateBuilt;
        private System.Windows.Forms.Label lblClubName;
        private System.Windows.Forms.Button BtnSaveStadium;
        private System.Windows.Forms.TextBox txtStadiumId;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}