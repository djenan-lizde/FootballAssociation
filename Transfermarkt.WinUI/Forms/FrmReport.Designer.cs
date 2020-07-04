namespace Transfermarkt.WinUI.Forms
{
    partial class FrmReport
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.CmbLeagues = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtTotalSum = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DgvTransfers = new System.Windows.Forms.DataGridView();
            this.BtnPrint = new System.Windows.Forms.Button();
            this.ChrPie = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvTransfers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChrPie)).BeginInit();
            this.SuspendLayout();
            // 
            // CmbLeagues
            // 
            this.CmbLeagues.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbLeagues.FormattingEnabled = true;
            this.CmbLeagues.Location = new System.Drawing.Point(142, 70);
            this.CmbLeagues.Name = "CmbLeagues";
            this.CmbLeagues.Size = new System.Drawing.Size(224, 26);
            this.CmbLeagues.TabIndex = 0;
            this.CmbLeagues.SelectionChangeCommitted += new System.EventHandler(this.CmbLeagues_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(196, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Pick a league";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(509, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Total money spent";
            // 
            // TxtTotalSum
            // 
            this.TxtTotalSum.Enabled = false;
            this.TxtTotalSum.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtTotalSum.Location = new System.Drawing.Point(445, 70);
            this.TxtTotalSum.Name = "TxtTotalSum";
            this.TxtTotalSum.Size = new System.Drawing.Size(224, 24);
            this.TxtTotalSum.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DgvTransfers);
            this.groupBox1.Location = new System.Drawing.Point(12, 164);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(511, 322);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Transfers";
            // 
            // DgvTransfers
            // 
            this.DgvTransfers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvTransfers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvTransfers.Location = new System.Drawing.Point(3, 16);
            this.DgvTransfers.Name = "DgvTransfers";
            this.DgvTransfers.Size = new System.Drawing.Size(505, 303);
            this.DgvTransfers.TabIndex = 0;
            // 
            // BtnPrint
            // 
            this.BtnPrint.BackColor = System.Drawing.Color.RoyalBlue;
            this.BtnPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPrint.ForeColor = System.Drawing.Color.White;
            this.BtnPrint.Location = new System.Drawing.Point(887, 492);
            this.BtnPrint.Name = "BtnPrint";
            this.BtnPrint.Size = new System.Drawing.Size(106, 40);
            this.BtnPrint.TabIndex = 5;
            this.BtnPrint.Text = "Print";
            this.BtnPrint.UseVisualStyleBackColor = false;
            this.BtnPrint.Click += new System.EventHandler(this.BtnPrint_Click);
            // 
            // ChrPie
            // 
            chartArea4.Name = "ChartArea1";
            this.ChrPie.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.ChrPie.Legends.Add(legend4);
            this.ChrPie.Location = new System.Drawing.Point(560, 180);
            this.ChrPie.Name = "ChrPie";
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series4.Legend = "Legend1";
            series4.Name = "s1";
            this.ChrPie.Series.Add(series4);
            this.ChrPie.Size = new System.Drawing.Size(486, 306);
            this.ChrPie.TabIndex = 6;
            this.ChrPie.Text = "chart1";
            // 
            // FrmReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1058, 558);
            this.Controls.Add(this.ChrPie);
            this.Controls.Add(this.BtnPrint);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.TxtTotalSum);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CmbLeagues);
            this.Name = "FrmReport";
            this.Text = "FrmReport";
            this.Load += new System.EventHandler(this.FrmReport_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvTransfers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChrPie)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CmbLeagues;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtTotalSum;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView DgvTransfers;
        private System.Windows.Forms.Button BtnPrint;
        private System.Windows.Forms.DataVisualization.Charting.Chart ChrPie;
    }
}