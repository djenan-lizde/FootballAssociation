namespace Transfermarkt.WinUI.Forms
{
    partial class FrmPlayer
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
            this.TxtLastName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtMiddleName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtJerseyNumber = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TxtMarketValue = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.TxtHeight = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.TxtWeight = new System.Windows.Forms.TextBox();
            this.CmbStrongerFoot = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.BtnAddPlayer = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.TxtBirthDate = new System.Windows.Forms.TextBox();
            this.ChBoxSign = new System.Windows.Forms.CheckBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label10 = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // TxtFirstName
            // 
            this.TxtFirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtFirstName.Location = new System.Drawing.Point(58, 59);
            this.TxtFirstName.Name = "TxtFirstName";
            this.TxtFirstName.Size = new System.Drawing.Size(190, 24);
            this.TxtFirstName.TabIndex = 0;
            this.TxtFirstName.Validating += new System.ComponentModel.CancelEventHandler(this.TxtFirstName_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(55, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "First name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(545, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "Last name";
            // 
            // TxtLastName
            // 
            this.TxtLastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtLastName.Location = new System.Drawing.Point(548, 59);
            this.TxtLastName.Name = "TxtLastName";
            this.TxtLastName.Size = new System.Drawing.Size(190, 24);
            this.TxtLastName.TabIndex = 2;
            this.TxtLastName.Validating += new System.ComponentModel.CancelEventHandler(this.TxtLastName_Validating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(297, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 18);
            this.label3.TabIndex = 5;
            this.label3.Text = "Middle name";
            // 
            // TxtMiddleName
            // 
            this.TxtMiddleName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtMiddleName.Location = new System.Drawing.Point(300, 59);
            this.TxtMiddleName.Name = "TxtMiddleName";
            this.TxtMiddleName.Size = new System.Drawing.Size(190, 24);
            this.TxtMiddleName.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(545, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 18);
            this.label4.TabIndex = 7;
            this.label4.Text = "Jersey number";
            // 
            // TxtJerseyNumber
            // 
            this.TxtJerseyNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtJerseyNumber.Location = new System.Drawing.Point(548, 138);
            this.TxtJerseyNumber.Name = "TxtJerseyNumber";
            this.TxtJerseyNumber.Size = new System.Drawing.Size(190, 24);
            this.TxtJerseyNumber.TabIndex = 6;
            this.TxtJerseyNumber.Validating += new System.ComponentModel.CancelEventHandler(this.TxtJerseyNumber_Validating);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(55, 188);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 18);
            this.label5.TabIndex = 9;
            this.label5.Text = "Market value";
            // 
            // TxtMarketValue
            // 
            this.TxtMarketValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtMarketValue.Location = new System.Drawing.Point(58, 227);
            this.TxtMarketValue.Name = "TxtMarketValue";
            this.TxtMarketValue.Size = new System.Drawing.Size(190, 24);
            this.TxtMarketValue.TabIndex = 8;
            this.TxtMarketValue.Validating += new System.ComponentModel.CancelEventHandler(this.TxtMarketValue_Validating);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(56, 111);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 18);
            this.label6.TabIndex = 11;
            this.label6.Text = "Height (cm)";
            // 
            // TxtHeight
            // 
            this.TxtHeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtHeight.Location = new System.Drawing.Point(58, 138);
            this.TxtHeight.Name = "TxtHeight";
            this.TxtHeight.Size = new System.Drawing.Size(190, 24);
            this.TxtHeight.TabIndex = 10;
            this.TxtHeight.Validating += new System.ComponentModel.CancelEventHandler(this.TxtHeight_Validating);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(297, 111);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 18);
            this.label7.TabIndex = 13;
            this.label7.Text = "Weight (kg)";
            // 
            // TxtWeight
            // 
            this.TxtWeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtWeight.Location = new System.Drawing.Point(300, 138);
            this.TxtWeight.Name = "TxtWeight";
            this.TxtWeight.Size = new System.Drawing.Size(190, 24);
            this.TxtWeight.TabIndex = 12;
            this.TxtWeight.Validating += new System.ComponentModel.CancelEventHandler(this.TxtWeight_Validating);
            // 
            // CmbStrongerFoot
            // 
            this.CmbStrongerFoot.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbStrongerFoot.FormattingEnabled = true;
            this.CmbStrongerFoot.Location = new System.Drawing.Point(300, 225);
            this.CmbStrongerFoot.Name = "CmbStrongerFoot";
            this.CmbStrongerFoot.Size = new System.Drawing.Size(190, 26);
            this.CmbStrongerFoot.TabIndex = 14;
            this.CmbStrongerFoot.Validating += new System.ComponentModel.CancelEventHandler(this.CmbStrongerFoot_Validating);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(297, 188);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(95, 18);
            this.label8.TabIndex = 15;
            this.label8.Text = "Stronger foot";
            // 
            // BtnAddPlayer
            // 
            this.BtnAddPlayer.BackColor = System.Drawing.Color.RoyalBlue;
            this.BtnAddPlayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAddPlayer.ForeColor = System.Drawing.Color.White;
            this.BtnAddPlayer.Location = new System.Drawing.Point(611, 394);
            this.BtnAddPlayer.Name = "BtnAddPlayer";
            this.BtnAddPlayer.Size = new System.Drawing.Size(127, 44);
            this.BtnAddPlayer.TabIndex = 16;
            this.BtnAddPlayer.Text = "Save";
            this.BtnAddPlayer.UseVisualStyleBackColor = false;
            this.BtnAddPlayer.Click += new System.EventHandler(this.BtnAddPlayer_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(545, 188);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(176, 18);
            this.label9.TabIndex = 18;
            this.label9.Text = "Birth date (MM.DD.YYYY)";
            // 
            // TxtBirthDate
            // 
            this.TxtBirthDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtBirthDate.Location = new System.Drawing.Point(548, 227);
            this.TxtBirthDate.Name = "TxtBirthDate";
            this.TxtBirthDate.Size = new System.Drawing.Size(190, 24);
            this.TxtBirthDate.TabIndex = 17;
            this.TxtBirthDate.Validating += new System.ComponentModel.CancelEventHandler(this.TxtBirthDate_Validating);
            // 
            // ChBoxSign
            // 
            this.ChBoxSign.AutoSize = true;
            this.ChBoxSign.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChBoxSign.Location = new System.Drawing.Point(160, 414);
            this.ChBoxSign.Name = "ChBoxSign";
            this.ChBoxSign.Size = new System.Drawing.Size(251, 24);
            this.ChBoxSign.TabIndex = 19;
            this.ChBoxSign.Text = "Do you want to sign this player?";
            this.ChBoxSign.UseVisualStyleBackColor = true;
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 18;
            this.listBox1.Location = new System.Drawing.Point(58, 314);
            this.listBox1.Name = "listBox1";
            this.listBox1.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBox1.Size = new System.Drawing.Size(245, 94);
            this.listBox1.TabIndex = 20;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(55, 279);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(125, 18);
            this.label10.TabIndex = 21;
            this.label10.Text = "Choose positions";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // FrmPlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(969, 465);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.ChBoxSign);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.TxtBirthDate);
            this.Controls.Add(this.BtnAddPlayer);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.CmbStrongerFoot);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.TxtWeight);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.TxtHeight);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TxtMarketValue);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TxtJerseyNumber);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TxtMiddleName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TxtLastName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtFirstName);
            this.Name = "FrmPlayer";
            this.Text = "FrmPlayers";
            this.Load += new System.EventHandler(this.FrmPlayers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtFirstName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtLastName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtMiddleName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtJerseyNumber;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TxtMarketValue;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TxtHeight;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox TxtWeight;
        private System.Windows.Forms.ComboBox CmbStrongerFoot;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button BtnAddPlayer;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox TxtBirthDate;
        private System.Windows.Forms.CheckBox ChBoxSign;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}