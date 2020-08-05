namespace Transfermarkt.WinUI.Forms
{
    partial class FrmNewMatchEvent
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
            this.CmbEvent = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CmbPlayers = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.CmbClubs = new System.Windows.Forms.ComboBox();
            this.BtnSaveDetail = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.TxtMinute = new System.Windows.Forms.TextBox();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // CmbEvent
            // 
            this.CmbEvent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbEvent.FormattingEnabled = true;
            this.CmbEvent.Location = new System.Drawing.Point(44, 92);
            this.CmbEvent.Name = "CmbEvent";
            this.CmbEvent.Size = new System.Drawing.Size(208, 28);
            this.CmbEvent.TabIndex = 0;
            this.CmbEvent.Validating += new System.ComponentModel.CancelEventHandler(this.CmbEvent_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(40, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Event";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(40, 179);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Players";
            // 
            // CmbPlayers
            // 
            this.CmbPlayers.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbPlayers.FormattingEnabled = true;
            this.CmbPlayers.Location = new System.Drawing.Point(44, 213);
            this.CmbPlayers.Name = "CmbPlayers";
            this.CmbPlayers.Size = new System.Drawing.Size(208, 28);
            this.CmbPlayers.TabIndex = 2;
            this.CmbPlayers.Validating += new System.ComponentModel.CancelEventHandler(this.CmbPlayers_Validating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(375, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Club";
            // 
            // CmbClubs
            // 
            this.CmbClubs.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbClubs.FormattingEnabled = true;
            this.CmbClubs.Location = new System.Drawing.Point(379, 92);
            this.CmbClubs.Name = "CmbClubs";
            this.CmbClubs.Size = new System.Drawing.Size(208, 28);
            this.CmbClubs.TabIndex = 4;
            this.CmbClubs.SelectionChangeCommitted += new System.EventHandler(this.CmbClubs_SelectionChangeCommitted);
            this.CmbClubs.Validating += new System.ComponentModel.CancelEventHandler(this.CmbClubs_Validating);
            // 
            // BtnSaveDetail
            // 
            this.BtnSaveDetail.BackColor = System.Drawing.Color.RoyalBlue;
            this.BtnSaveDetail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSaveDetail.ForeColor = System.Drawing.Color.White;
            this.BtnSaveDetail.Location = new System.Drawing.Point(400, 257);
            this.BtnSaveDetail.Name = "BtnSaveDetail";
            this.BtnSaveDetail.Size = new System.Drawing.Size(143, 37);
            this.BtnSaveDetail.TabIndex = 6;
            this.BtnSaveDetail.Text = "Save";
            this.BtnSaveDetail.UseVisualStyleBackColor = false;
            this.BtnSaveDetail.Click += new System.EventHandler(this.BtnSaveDetail_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(40, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(305, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Players will load when you choose the club";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(375, 157);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "Insert minute";
            // 
            // TxtMinute
            // 
            this.TxtMinute.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtMinute.Location = new System.Drawing.Point(379, 213);
            this.TxtMinute.Name = "TxtMinute";
            this.TxtMinute.Size = new System.Drawing.Size(208, 26);
            this.TxtMinute.TabIndex = 9;
            this.TxtMinute.Validating += new System.ComponentModel.CancelEventHandler(this.TxtMinute_Validating);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // FrmNewMatchEvent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 327);
            this.Controls.Add(this.TxtMinute);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.BtnSaveDetail);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CmbClubs);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CmbPlayers);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CmbEvent);
            this.Name = "FrmNewMatchEvent";
            this.Text = "FrmNewMatchEvent";
            this.Load += new System.EventHandler(this.FrmNewMatchEvent_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CmbEvent;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CmbPlayers;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox CmbClubs;
        private System.Windows.Forms.Button BtnSaveDetail;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TxtMinute;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}