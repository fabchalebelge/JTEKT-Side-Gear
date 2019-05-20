using System;
using System.Windows.Forms;

namespace JTEKT_Side_Gear
{
    partial class Main
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.label_WorkOrder = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label_PartNumber = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label_Ok = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label_Nok = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label_Size = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // label_WorkOrder
            // 
            this.label_WorkOrder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_WorkOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_WorkOrder.Location = new System.Drawing.Point(276, 26);
            this.label_WorkOrder.Name = "label_WorkOrder";
            this.label_WorkOrder.Size = new System.Drawing.Size(167, 53);
            this.label_WorkOrder.TabIndex = 0;
            this.label_WorkOrder.Text = "012345";
            this.label_WorkOrder.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(286, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Work Order";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(22, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Part Number";
            // 
            // label_PartNumber
            // 
            this.label_PartNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_PartNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_PartNumber.Location = new System.Drawing.Point(12, 26);
            this.label_PartNumber.Name = "label_PartNumber";
            this.label_PartNumber.Size = new System.Drawing.Size(258, 53);
            this.label_PartNumber.TabIndex = 2;
            this.label_PartNumber.Text = "UE24 490023-3400";
            this.label_PartNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(632, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "Qty OK";
            // 
            // label_Ok
            // 
            this.label_Ok.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_Ok.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Ok.Location = new System.Drawing.Point(622, 26);
            this.label_Ok.Name = "label_Ok";
            this.label_Ok.Size = new System.Drawing.Size(186, 53);
            this.label_Ok.TabIndex = 4;
            this.label_Ok.Text = "1553 (99.00 %)";
            this.label_Ok.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(824, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 25);
            this.label5.TabIndex = 7;
            this.label5.Text = "Qty NOK";
            // 
            // label_Nok
            // 
            this.label_Nok.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_Nok.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Nok.Location = new System.Drawing.Point(814, 26);
            this.label_Nok.Name = "label_Nok";
            this.label_Nok.Size = new System.Drawing.Size(186, 53);
            this.label_Nok.TabIndex = 6;
            this.label_Nok.Text = "15 (1.00 %)";
            this.label_Nok.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(459, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 25);
            this.label4.TabIndex = 9;
            this.label4.Text = "Size";
            // 
            // label_Size
            // 
            this.label_Size.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_Size.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Size.Location = new System.Drawing.Point(449, 26);
            this.label_Size.Name = "label_Size";
            this.label_Size.Size = new System.Drawing.Size(167, 53);
            this.label_Size.TabIndex = 8;
            this.label_Size.Text = "2400";
            this.label_Size.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chart1
            // 
            chartArea1.AxisX.MajorGrid.Enabled = false;
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.DarkGray;
            chartArea1.AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Location = new System.Drawing.Point(12, 196);
            this.chart1.Name = "chart1";
            series1.BorderWidth = 3;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Color = System.Drawing.Color.Red;
            series1.Name = "TolMin";
            series2.BorderWidth = 3;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Color = System.Drawing.Color.Red;
            series2.Name = "TolMax";
            series3.BorderWidth = 3;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Color = System.Drawing.Color.DarkGray;
            series3.Name = "Target";
            series4.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            series4.BorderWidth = 3;
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series4.Color = System.Drawing.Color.Black;
            series4.Name = "Avg";
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series5.MarkerBorderColor = System.Drawing.Color.Blue;
            series5.MarkerColor = System.Drawing.Color.Blue;
            series5.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            series5.Name = "Values";
            this.chart1.Series.Add(series1);
            this.chart1.Series.Add(series2);
            this.chart1.Series.Add(series3);
            this.chart1.Series.Add(series4);
            this.chart1.Series.Add(series5);
            this.chart1.Size = new System.Drawing.Size(988, 300);
            this.chart1.TabIndex = 10;
            this.chart1.Text = "chart1";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1015, 620);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label_Size);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label_Nok);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label_Ok);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label_PartNumber);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label_WorkOrder);
            this.Name = "Main";
            this.RightToLeftLayout = true;
            this.Text = "JTEKT SG05";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_WorkOrder;
        private System.Windows.Forms.Label label1;
        private Label label2;
        private Label label_PartNumber;
        private Label label3;
        private Label label_Ok;
        private Label label5;
        private Label label_Nok;
        private Label label4;
        private Label label_Size;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
    }
}

