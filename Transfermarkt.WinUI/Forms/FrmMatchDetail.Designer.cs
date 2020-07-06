namespace Transfermarkt.WinUI.Forms
{
    partial class FrmMatchDetail
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.HomeClubGoal = new System.Windows.Forms.Label();
            this.AwayClubGoal = new System.Windows.Forms.Label();
            this.HomeClubName = new System.Windows.Forms.Label();
            this.AwayClubName = new System.Windows.Forms.Label();
            this.BtnNewEventMatch = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.DgvGoalScorers = new System.Windows.Forms.DataGridView();
            this.BtnMatchFinish = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.DgvPlayerCards = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.DgvCorners = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvGoalScorers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvPlayerCards)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvCorners)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point(44, 85);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 200);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox2.Location = new System.Drawing.Point(909, 85);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(200, 200);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(578, 150);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 55);
            this.label1.TabIndex = 2;
            this.label1.Text = "-";
            // 
            // HomeClubGoal
            // 
            this.HomeClubGoal.AutoSize = true;
            this.HomeClubGoal.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HomeClubGoal.Location = new System.Drawing.Point(303, 159);
            this.HomeClubGoal.Name = "HomeClubGoal";
            this.HomeClubGoal.Size = new System.Drawing.Size(118, 42);
            this.HomeClubGoal.TabIndex = 3;
            this.HomeClubGoal.Text = "label2";
            // 
            // AwayClubGoal
            // 
            this.AwayClubGoal.AutoSize = true;
            this.AwayClubGoal.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AwayClubGoal.Location = new System.Drawing.Point(755, 159);
            this.AwayClubGoal.Name = "AwayClubGoal";
            this.AwayClubGoal.Size = new System.Drawing.Size(118, 42);
            this.AwayClubGoal.TabIndex = 4;
            this.AwayClubGoal.Text = "label3";
            // 
            // HomeClubName
            // 
            this.HomeClubName.AutoSize = true;
            this.HomeClubName.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HomeClubName.Location = new System.Drawing.Point(38, 310);
            this.HomeClubName.Name = "HomeClubName";
            this.HomeClubName.Size = new System.Drawing.Size(86, 31);
            this.HomeClubName.TabIndex = 5;
            this.HomeClubName.Text = "label2";
            // 
            // AwayClubName
            // 
            this.AwayClubName.AutoSize = true;
            this.AwayClubName.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AwayClubName.Location = new System.Drawing.Point(913, 310);
            this.AwayClubName.Name = "AwayClubName";
            this.AwayClubName.Size = new System.Drawing.Size(86, 31);
            this.AwayClubName.TabIndex = 6;
            this.AwayClubName.Text = "label2";
            // 
            // BtnNewEventMatch
            // 
            this.BtnNewEventMatch.BackColor = System.Drawing.Color.RoyalBlue;
            this.BtnNewEventMatch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnNewEventMatch.ForeColor = System.Drawing.Color.White;
            this.BtnNewEventMatch.Location = new System.Drawing.Point(762, 24);
            this.BtnNewEventMatch.Name = "BtnNewEventMatch";
            this.BtnNewEventMatch.Size = new System.Drawing.Size(107, 46);
            this.BtnNewEventMatch.TabIndex = 7;
            this.BtnNewEventMatch.Text = "New event";
            this.BtnNewEventMatch.UseVisualStyleBackColor = false;
            this.BtnNewEventMatch.Click += new System.EventHandler(this.BtnNewEventMatch_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(108, 376);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(194, 31);
            this.label2.TabIndex = 8;
            this.label2.Text = "Goal scorer(s):";
            // 
            // DgvGoalScorers
            // 
            this.DgvGoalScorers.AllowUserToAddRows = false;
            this.DgvGoalScorers.AllowUserToDeleteRows = false;
            this.DgvGoalScorers.BackgroundColor = System.Drawing.Color.White;
            this.DgvGoalScorers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvGoalScorers.Location = new System.Drawing.Point(12, 425);
            this.DgvGoalScorers.Name = "DgvGoalScorers";
            this.DgvGoalScorers.ReadOnly = true;
            this.DgvGoalScorers.Size = new System.Drawing.Size(373, 107);
            this.DgvGoalScorers.TabIndex = 9;
            // 
            // BtnMatchFinish
            // 
            this.BtnMatchFinish.BackColor = System.Drawing.Color.RoyalBlue;
            this.BtnMatchFinish.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnMatchFinish.ForeColor = System.Drawing.Color.White;
            this.BtnMatchFinish.Location = new System.Drawing.Point(310, 24);
            this.BtnMatchFinish.Name = "BtnMatchFinish";
            this.BtnMatchFinish.Size = new System.Drawing.Size(107, 46);
            this.BtnMatchFinish.TabIndex = 10;
            this.BtnMatchFinish.Text = "Finish match";
            this.BtnMatchFinish.UseVisualStyleBackColor = false;
            this.BtnMatchFinish.Click += new System.EventHandler(this.BtnMatchFinish_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(521, 376);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 31);
            this.label3.TabIndex = 11;
            this.label3.Text = "Card(s):";
            // 
            // DgvPlayerCards
            // 
            this.DgvPlayerCards.AllowUserToAddRows = false;
            this.DgvPlayerCards.AllowUserToDeleteRows = false;
            this.DgvPlayerCards.BackgroundColor = System.Drawing.Color.White;
            this.DgvPlayerCards.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvPlayerCards.Location = new System.Drawing.Point(391, 425);
            this.DgvPlayerCards.Name = "DgvPlayerCards";
            this.DgvPlayerCards.ReadOnly = true;
            this.DgvPlayerCards.Size = new System.Drawing.Size(373, 107);
            this.DgvPlayerCards.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(903, 376);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(137, 31);
            this.label4.TabIndex = 13;
            this.label4.Text = "Corner(s):";
            // 
            // DgvCorners
            // 
            this.DgvCorners.AllowUserToAddRows = false;
            this.DgvCorners.AllowUserToDeleteRows = false;
            this.DgvCorners.BackgroundColor = System.Drawing.Color.White;
            this.DgvCorners.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvCorners.Location = new System.Drawing.Point(775, 425);
            this.DgvCorners.Name = "DgvCorners";
            this.DgvCorners.ReadOnly = true;
            this.DgvCorners.Size = new System.Drawing.Size(373, 107);
            this.DgvCorners.TabIndex = 14;
            // 
            // FrmMatchDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1160, 583);
            this.Controls.Add(this.DgvCorners);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.DgvPlayerCards);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.BtnMatchFinish);
            this.Controls.Add(this.DgvGoalScorers);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BtnNewEventMatch);
            this.Controls.Add(this.AwayClubName);
            this.Controls.Add(this.HomeClubName);
            this.Controls.Add(this.AwayClubGoal);
            this.Controls.Add(this.HomeClubGoal);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Name = "FrmMatchDetail";
            this.Text = "FrmMatchDetail";
            this.Load += new System.EventHandler(this.FrmMatchDetail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvGoalScorers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvPlayerCards)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvCorners)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label HomeClubGoal;
        private System.Windows.Forms.Label AwayClubGoal;
        private System.Windows.Forms.Label HomeClubName;
        private System.Windows.Forms.Label AwayClubName;
        private System.Windows.Forms.Button BtnNewEventMatch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView DgvGoalScorers;
        private System.Windows.Forms.Button BtnMatchFinish;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView DgvPlayerCards;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView DgvCorners;
    }
}