namespace Transfermarkt.WinUI.Forms
{
    partial class FrmLeague
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
            this.TxtLeagueName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtOrganizer = new System.Windows.Forms.TextBox();
            this.BtnAddLeague = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // TxtLeagueName
            // 
            this.TxtLeagueName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtLeagueName.Location = new System.Drawing.Point(69, 93);
            this.TxtLeagueName.Name = "TxtLeagueName";
            this.TxtLeagueName.Size = new System.Drawing.Size(205, 24);
            this.TxtLeagueName.TabIndex = 0;
            this.TxtLeagueName.Validating += new System.ComponentModel.CancelEventHandler(this.TxtLeagueName_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(66, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "League name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(66, 152);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(223, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "Date established (MM.DD.YYYY)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(331, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 18);
            this.label3.TabIndex = 5;
            this.label3.Text = "Organizer";
            // 
            // TxtOrganizer
            // 
            this.TxtOrganizer.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtOrganizer.Location = new System.Drawing.Point(334, 93);
            this.TxtOrganizer.Name = "TxtOrganizer";
            this.TxtOrganizer.Size = new System.Drawing.Size(205, 24);
            this.TxtOrganizer.TabIndex = 4;
            this.TxtOrganizer.Validating += new System.ComponentModel.CancelEventHandler(this.TxtOrganizer_Validating);
            // 
            // BtnAddLeague
            // 
            this.BtnAddLeague.BackColor = System.Drawing.Color.RoyalBlue;
            this.BtnAddLeague.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAddLeague.ForeColor = System.Drawing.Color.White;
            this.BtnAddLeague.Location = new System.Drawing.Point(393, 179);
            this.BtnAddLeague.Name = "BtnAddLeague";
            this.BtnAddLeague.Size = new System.Drawing.Size(87, 38);
            this.BtnAddLeague.TabIndex = 6;
            this.BtnAddLeague.Text = "Save";
            this.BtnAddLeague.UseVisualStyleBackColor = false;
            this.BtnAddLeague.Click += new System.EventHandler(this.BtnAddLeague_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(69, 197);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(205, 20);
            this.dateTimePicker1.TabIndex = 30;
            // 
            // FrmLeague
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 288);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.BtnAddLeague);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TxtOrganizer);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtLeagueName);
            this.Name = "FrmLeague";
            this.Text = "FrmLegue";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtLeagueName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtOrganizer;
        private System.Windows.Forms.Button BtnAddLeague;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}