namespace Transfermarkt.WinUI.Forms
{
    partial class FrmContract
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
            this.label1 = new System.Windows.Forms.Label();
            this.TxtExpirationDate = new System.Windows.Forms.TextBox();
            this.BtnSignContract = new System.Windows.Forms.Button();
            this.TxtRedemptionClause = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CmbClubs = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.PlayerName = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(30, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(211, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Expiration date (MM.DD.YYYY)";
            // 
            // TxtExpirationDate
            // 
            this.TxtExpirationDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtExpirationDate.Location = new System.Drawing.Point(33, 111);
            this.TxtExpirationDate.Name = "TxtExpirationDate";
            this.TxtExpirationDate.Size = new System.Drawing.Size(200, 26);
            this.TxtExpirationDate.TabIndex = 1;
            this.TxtExpirationDate.Validating += new System.ComponentModel.CancelEventHandler(this.TxtExpirationDate_Validating);
            // 
            // BtnSignContract
            // 
            this.BtnSignContract.BackColor = System.Drawing.Color.RoyalBlue;
            this.BtnSignContract.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSignContract.ForeColor = System.Drawing.Color.White;
            this.BtnSignContract.Location = new System.Drawing.Point(329, 205);
            this.BtnSignContract.Name = "BtnSignContract";
            this.BtnSignContract.Size = new System.Drawing.Size(130, 52);
            this.BtnSignContract.TabIndex = 2;
            this.BtnSignContract.Text = "Sign it!";
            this.BtnSignContract.UseVisualStyleBackColor = false;
            this.BtnSignContract.Click += new System.EventHandler(this.BtnSignContract_Click);
            // 
            // TxtRedemptionClause
            // 
            this.TxtRedemptionClause.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtRedemptionClause.Location = new System.Drawing.Point(33, 205);
            this.TxtRedemptionClause.Name = "TxtRedemptionClause";
            this.TxtRedemptionClause.Size = new System.Drawing.Size(200, 26);
            this.TxtRedemptionClause.TabIndex = 4;
            this.TxtRedemptionClause.Validating += new System.ComponentModel.CancelEventHandler(this.TxtRedemptionClause_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(30, 165);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "Redemption clause";
            // 
            // CmbClubs
            // 
            this.CmbClubs.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbClubs.FormattingEnabled = true;
            this.CmbClubs.Location = new System.Drawing.Point(317, 111);
            this.CmbClubs.Name = "CmbClubs";
            this.CmbClubs.Size = new System.Drawing.Size(200, 26);
            this.CmbClubs.TabIndex = 5;
            this.CmbClubs.Validating += new System.ComponentModel.CancelEventHandler(this.CmbClubs_Validating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(326, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 18);
            this.label3.TabIndex = 6;
            this.label3.Text = "Clubs";
            // 
            // PlayerName
            // 
            this.PlayerName.AutoSize = true;
            this.PlayerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlayerName.Location = new System.Drawing.Point(225, 20);
            this.PlayerName.Name = "PlayerName";
            this.PlayerName.Size = new System.Drawing.Size(60, 24);
            this.PlayerName.TabIndex = 7;
            this.PlayerName.Text = "label4";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // FrmContract
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 302);
            this.Controls.Add(this.PlayerName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CmbClubs);
            this.Controls.Add(this.TxtRedemptionClause);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BtnSignContract);
            this.Controls.Add(this.TxtExpirationDate);
            this.Controls.Add(this.label1);
            this.Name = "FrmContract";
            this.Text = "FrmContract";
            this.Load += new System.EventHandler(this.FrmContract_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtExpirationDate;
        private System.Windows.Forms.Button BtnSignContract;
        private System.Windows.Forms.TextBox TxtRedemptionClause;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CmbClubs;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label PlayerName;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}