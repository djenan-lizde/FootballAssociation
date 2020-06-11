namespace Transfermarkt.WinUI.Forms
{
    partial class FrmPlayersList
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
            this.BtnPlayersList = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DgvPlayersList = new System.Windows.Forms.DataGridView();
            this.BtnUnsignedPlayers = new System.Windows.Forms.Button();
            this.BtnContractUpdate = new System.Windows.Forms.Button();
            this.TxtSearchPlayer = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ChcIsSigned = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvPlayersList)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnPlayersList
            // 
            this.BtnPlayersList.BackColor = System.Drawing.Color.RoyalBlue;
            this.BtnPlayersList.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPlayersList.ForeColor = System.Drawing.Color.White;
            this.BtnPlayersList.Location = new System.Drawing.Point(898, 57);
            this.BtnPlayersList.Name = "BtnPlayersList";
            this.BtnPlayersList.Size = new System.Drawing.Size(113, 47);
            this.BtnPlayersList.TabIndex = 0;
            this.BtnPlayersList.Text = "Show players";
            this.BtnPlayersList.UseVisualStyleBackColor = false;
            this.BtnPlayersList.Click += new System.EventHandler(this.BtnPlayersList_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DgvPlayersList);
            this.groupBox1.Location = new System.Drawing.Point(12, 138);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1025, 300);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Players";
            // 
            // DgvPlayersList
            // 
            this.DgvPlayersList.AllowUserToAddRows = false;
            this.DgvPlayersList.AllowUserToDeleteRows = false;
            this.DgvPlayersList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvPlayersList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvPlayersList.Location = new System.Drawing.Point(3, 16);
            this.DgvPlayersList.Name = "DgvPlayersList";
            this.DgvPlayersList.ReadOnly = true;
            this.DgvPlayersList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvPlayersList.Size = new System.Drawing.Size(1019, 281);
            this.DgvPlayersList.TabIndex = 0;
            this.DgvPlayersList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.DgvPlayersList_MouseDoubleClick);
            // 
            // BtnUnsignedPlayers
            // 
            this.BtnUnsignedPlayers.BackColor = System.Drawing.Color.RoyalBlue;
            this.BtnUnsignedPlayers.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnUnsignedPlayers.ForeColor = System.Drawing.Color.White;
            this.BtnUnsignedPlayers.Location = new System.Drawing.Point(732, 57);
            this.BtnUnsignedPlayers.Name = "BtnUnsignedPlayers";
            this.BtnUnsignedPlayers.Size = new System.Drawing.Size(113, 47);
            this.BtnUnsignedPlayers.TabIndex = 2;
            this.BtnUnsignedPlayers.Text = "Unsigned players";
            this.BtnUnsignedPlayers.UseVisualStyleBackColor = false;
            this.BtnUnsignedPlayers.Click += new System.EventHandler(this.BtnUnsignedPlayers_Click);
            // 
            // BtnContractUpdate
            // 
            this.BtnContractUpdate.BackColor = System.Drawing.Color.RoyalBlue;
            this.BtnContractUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnContractUpdate.ForeColor = System.Drawing.Color.White;
            this.BtnContractUpdate.Location = new System.Drawing.Point(560, 57);
            this.BtnContractUpdate.Name = "BtnContractUpdate";
            this.BtnContractUpdate.Size = new System.Drawing.Size(113, 47);
            this.BtnContractUpdate.TabIndex = 3;
            this.BtnContractUpdate.Text = "Update contracts";
            this.BtnContractUpdate.UseVisualStyleBackColor = false;
            this.BtnContractUpdate.Click += new System.EventHandler(this.BtnContractUpdate_Click);
            // 
            // TxtSearchPlayer
            // 
            this.TxtSearchPlayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtSearchPlayer.Location = new System.Drawing.Point(58, 80);
            this.TxtSearchPlayer.Name = "TxtSearchPlayer";
            this.TxtSearchPlayer.Size = new System.Drawing.Size(265, 24);
            this.TxtSearchPlayer.TabIndex = 4;
            this.TxtSearchPlayer.TextChanged += new System.EventHandler(this.TxtSearchPlayer_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(55, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 18);
            this.label1.TabIndex = 5;
            this.label1.Text = "Search player";
            // 
            // ChcIsSigned
            // 
            this.ChcIsSigned.AutoSize = true;
            this.ChcIsSigned.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChcIsSigned.Location = new System.Drawing.Point(353, 80);
            this.ChcIsSigned.Name = "ChcIsSigned";
            this.ChcIsSigned.Size = new System.Drawing.Size(72, 22);
            this.ChcIsSigned.TabIndex = 6;
            this.ChcIsSigned.Text = "Signed";
            this.ChcIsSigned.UseVisualStyleBackColor = true;
            // 
            // FrmPlayersList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1049, 450);
            this.Controls.Add(this.ChcIsSigned);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtSearchPlayer);
            this.Controls.Add(this.BtnContractUpdate);
            this.Controls.Add(this.BtnUnsignedPlayers);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.BtnPlayersList);
            this.Name = "FrmPlayersList";
            this.Text = "FrmPlayersList";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvPlayersList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnPlayersList;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView DgvPlayersList;
        private System.Windows.Forms.Button BtnUnsignedPlayers;
        private System.Windows.Forms.Button BtnContractUpdate;
        private System.Windows.Forms.TextBox TxtSearchPlayer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox ChcIsSigned;
    }
}