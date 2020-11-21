namespace Transfermarkt.WinUI.Forms
{
    partial class FrmRegister
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
            this.label1 = new System.Windows.Forms.Label();
            this.TxtFirstName = new System.Windows.Forms.TextBox();
            this.TxtLastName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtEmailAddress = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtUsername = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtConPassword = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TxtPassword = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.BtnCrAcc = new System.Windows.Forms.Button();
            this.loader = new Transfermarkt.WinUI.UserControls.Loader();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(72, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "First name";
            // 
            // TxtFirstName
            // 
            this.TxtFirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtFirstName.ForeColor = System.Drawing.Color.Black;
            this.TxtFirstName.Location = new System.Drawing.Point(76, 75);
            this.TxtFirstName.Name = "TxtFirstName";
            this.TxtFirstName.Size = new System.Drawing.Size(189, 29);
            this.TxtFirstName.TabIndex = 1;
            this.TxtFirstName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TxtLastName
            // 
            this.TxtLastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtLastName.ForeColor = System.Drawing.Color.Black;
            this.TxtLastName.Location = new System.Drawing.Point(362, 75);
            this.TxtLastName.Name = "TxtLastName";
            this.TxtLastName.Size = new System.Drawing.Size(189, 29);
            this.TxtLastName.TabIndex = 3;
            this.TxtLastName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(358, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "Last name";
            // 
            // TxtEmailAddress
            // 
            this.TxtEmailAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtEmailAddress.ForeColor = System.Drawing.Color.Black;
            this.TxtEmailAddress.Location = new System.Drawing.Point(362, 168);
            this.TxtEmailAddress.Name = "TxtEmailAddress";
            this.TxtEmailAddress.Size = new System.Drawing.Size(189, 29);
            this.TxtEmailAddress.TabIndex = 5;
            this.TxtEmailAddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(358, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 24);
            this.label3.TabIndex = 4;
            this.label3.Text = "Email address";
            // 
            // TxtUsername
            // 
            this.TxtUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtUsername.ForeColor = System.Drawing.Color.Black;
            this.TxtUsername.Location = new System.Drawing.Point(76, 168);
            this.TxtUsername.Name = "TxtUsername";
            this.TxtUsername.Size = new System.Drawing.Size(189, 29);
            this.TxtUsername.TabIndex = 7;
            this.TxtUsername.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(72, 125);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 24);
            this.label4.TabIndex = 6;
            this.label4.Text = "Username";
            // 
            // TxtConPassword
            // 
            this.TxtConPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtConPassword.ForeColor = System.Drawing.Color.Black;
            this.TxtConPassword.Location = new System.Drawing.Point(362, 263);
            this.TxtConPassword.Name = "TxtConPassword";
            this.TxtConPassword.PasswordChar = '*';
            this.TxtConPassword.Size = new System.Drawing.Size(189, 29);
            this.TxtConPassword.TabIndex = 9;
            this.TxtConPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(358, 227);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(172, 24);
            this.label5.TabIndex = 8;
            this.label5.Text = "Coniform password";
            // 
            // TxtPassword
            // 
            this.TxtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtPassword.ForeColor = System.Drawing.Color.Black;
            this.TxtPassword.Location = new System.Drawing.Point(76, 263);
            this.TxtPassword.Name = "TxtPassword";
            this.TxtPassword.PasswordChar = '*';
            this.TxtPassword.Size = new System.Drawing.Size(189, 29);
            this.TxtPassword.TabIndex = 11;
            this.TxtPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(72, 227);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 24);
            this.label6.TabIndex = 10;
            this.label6.Text = "Password";
            // 
            // BtnCrAcc
            // 
            this.BtnCrAcc.BackColor = System.Drawing.Color.RoyalBlue;
            this.BtnCrAcc.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCrAcc.ForeColor = System.Drawing.Color.White;
            this.BtnCrAcc.Location = new System.Drawing.Point(251, 334);
            this.BtnCrAcc.Name = "BtnCrAcc";
            this.BtnCrAcc.Size = new System.Drawing.Size(135, 51);
            this.BtnCrAcc.TabIndex = 12;
            this.BtnCrAcc.Text = "Create it";
            this.BtnCrAcc.UseVisualStyleBackColor = false;
            this.BtnCrAcc.Click += new System.EventHandler(this.BtnCrAcc_Click);
            // 
            // loader
            // 
            this.loader.Location = new System.Drawing.Point(271, 121);
            this.loader.Name = "loader";
            this.loader.Size = new System.Drawing.Size(104, 136);
            this.loader.TabIndex = 13;
            // 
            // FrmRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 441);
            this.Controls.Add(this.loader);
            this.Controls.Add(this.BtnCrAcc);
            this.Controls.Add(this.TxtPassword);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.TxtConPassword);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TxtUsername);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TxtEmailAddress);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TxtLastName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TxtFirstName);
            this.Controls.Add(this.label1);
            this.Name = "FrmRegister";
            this.Text = "FrmRegister";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtFirstName;
        private System.Windows.Forms.TextBox TxtLastName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtEmailAddress;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtUsername;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtConPassword;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TxtPassword;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button BtnCrAcc;
        private UserControls.Loader loader;
    }
}