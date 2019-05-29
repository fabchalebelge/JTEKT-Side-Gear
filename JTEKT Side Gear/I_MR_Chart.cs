using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Threading;
using System.Drawing;

namespace JTEKT_Side_Gear
{
    class I_MR_Chart
    {
        public Chart chart_I;
        public Label label_LastValue;
        private readonly int index;
        public int DimensionId { get; set; }

        public I_MR_Chart(int index, int dimensionId)
        {
            this.index = index;
            this.DimensionId = dimensionId;
            InitializeComponent();           
        }

        public void UpdateChart(I_MR_List yValues, decimal lastValue, bool lastValueIsOk)
        {
            chart_I.Series["Values"].Points.Clear();
            chart_I.Series["TolMin"].Points.Clear();
            chart_I.Series["TolMax"].Points.Clear();
            chart_I.Series["Med"].Points.Clear();
            chart_I.Series["Target"].Points.Clear();

            if (yValues.Count > 0)
            {
                chart_I.ChartAreas[0].AxisY.Minimum = (double)Math.Round(yValues[yValues.Count - 1].TolMin - (yValues[yValues.Count - 1].TolMax - yValues[yValues.Count - 1].TolMin) / 4, 2);
                chart_I.ChartAreas[0].AxisY.Maximum = (double)Math.Round(yValues[yValues.Count - 1].TolMax + (yValues[yValues.Count - 1].TolMax - yValues[yValues.Count - 1].TolMin) / 4, 2);

                foreach (I_MR_Point yValue in yValues)
                {
                    chart_I.Series["Values"].Points.AddY(yValue.I);
                    chart_I.Series["TolMin"].Points.AddY(yValue.TolMin);
                    chart_I.Series["TolMax"].Points.AddY(yValue.TolMax);
                    chart_I.Series["Med"].Points.AddY(yValues.MedI);
                    chart_I.Series["Target"].Points.AddY(yValue.Target);
                }

                label_LastValue.Text = lastValue.ToString();
                if (lastValueIsOk)
                {
                    label_LastValue.BackColor = Color.LightGreen;
                    label_LastValue.ForeColor = Color.Black;
                }

                else
                {
                    label_LastValue.BackColor = Color.Red;
                    label_LastValue.ForeColor = Color.White;
                }

            }
        }

        private void InitializeComponent()
        {
            Rectangle screen = Screen.PrimaryScreen.WorkingArea;
            int ySize = 200;
            int yLocation = 100 + index * ySize;

            //
            //label_LastValue
            //
            label_LastValue = new Label();
            label_LastValue.Location = new Point(12, ySize);
            label_LastValue.Size = new Size(300, ySize);
            label_LastValue.BorderStyle = BorderStyle.FixedSingle;
            label_LastValue.TextAlign = ContentAlignment.MiddleCenter;
            label_LastValue.Font = new Font("Microsoft Sans Serif", 50F, (System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //
            //chart_I
            //
            ChartArea chartArea1 = new ChartArea();
            Series series1 = new Series();
            Series series2 = new Series();
            Series series3 = new Series();
            Series series4 = new Series();
            Series series5 = new Series();            
            this.chart_I = new Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chart_I)).BeginInit();
            chartArea1.AxisX.MajorGrid.Enabled = false;
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.DarkGray;
            chartArea1.AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea1.Name = "ChartArea1";
            this.chart_I.ChartAreas.Add(chartArea1);
            this.chart_I.Location = new System.Drawing.Point(label_LastValue.Location.X + label_LastValue.Size.Width + 12, ySize);
            this.chart_I.Name = "chart_I";
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
            series4.Name = "Med";
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series5.MarkerBorderColor = System.Drawing.Color.Blue;
            series5.MarkerColor = System.Drawing.Color.Blue;
            series5.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            series5.Name = "Values";
            this.chart_I.Series.Add(series1);
            this.chart_I.Series.Add(series2);
            this.chart_I.Series.Add(series3);
            this.chart_I.Series.Add(series4);
            this.chart_I.Series.Add(series5);
            this.chart_I.Size = new System.Drawing.Size(screen.Width - chart_I.Location.X - 12, ySize);
            this.chart_I.TabIndex = 10;
            this.chart_I.Text = "chart1";
        }
    }
}
