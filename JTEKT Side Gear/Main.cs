using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Data.SqlClient;
using System.Data.Common;

namespace JTEKT_Side_Gear
{
    public partial class Main : Form
    {
        private int productionLineId;
        private string connexionString;
        private SqlDataSet sqlDataSet;
        private Thread myThreadUpdateForm;
        private List<I_MR_Chart> listOfCharts;
        private int numOfPoints;
        //private delegate void SafeCallDelegate(string workOrder, int workOrderSize, string partNumber, int numOfPiecesOk, int numOfPiecesNok); //Nécessaire pour la mise à jour des labels dans un thread autre que celui dans lequel ils ont été créés
        //private static int numOfPoints = 10;
        //private delegate void DelegateUpdateChart(I_MR_List yValues);
        private delegate void SafeCallUpdateIMRValues(I_MR_Chart chart);
        

        public Main()
        {
            InitializeVariable();
            InitializeComponent();
        }

        private void InitializeVariable()
        {
            productionLineId = 2;
            numOfPoints = 40;
            connexionString = "Data Source=DESKTOP-BCK9KR3\\SQLEXPRESS; Initial Catalog = side_gear; User ID = sidegear; Password = sidegear";
            sqlDataSet = new SqlDataSet(productionLineId, connexionString, numOfPoints);
            listOfCharts = new List<I_MR_Chart>();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            //Ajout d'un objet graphique par dimension à afficher
            int index = 0;
            foreach (int dimensionId in sqlDataSet.DimensionsIds)
            {
                I_MR_Chart myChart = new I_MR_Chart(index);
                this.Controls.Add(myChart.chart_I);
                myChart.DimensionId = dimensionId;
                listOfCharts.Add(myChart);
                index++;
            }

            //Démarrage dans un thread secondaire de la mise à jour des graphiques
            myThreadUpdateForm = new Thread(new ThreadStart(Update_I_MR_Chart));
            myThreadUpdateForm.Start();

        }

        private void Update_I_MR_Chart()
        {
            while (Thread.CurrentThread.IsAlive)
            {
                foreach (I_MR_Chart chart in listOfCharts)
                {
                    Update_I_MR_Values(chart);
                }
                Thread.Sleep(1000);
            }
        }

        private void Update_I_MR_Values(I_MR_Chart chart)
        {
            if (chart.chart_I.InvokeRequired)
            {
                var d = new SafeCallUpdateIMRValues(Update_I_MR_Values);
                Invoke(d, new object[] { chart });
            }
            else
            {
                I_MR_List yValues = sqlDataSet.Values(chart.DimensionId);
                chart.UpdateChart(yValues);
            }
        }

        private void ThreadUpdateInfoProd()
        {
            //DbDataReader reader;
            //int ind;
            //string workOrder;
            //string partNumber;
            //int workOrderSize;
            //int numOfPiecesOk;
            //int numOfPiecesNok;

            //while (Thread.CurrentThread.IsAlive)
            //{
            //    //Infos Work Order
            //    cmd.CommandText = "SELECT [workOrder], [partNumber], [workOrderSize] FROM [ExchangeTable] WHERE [productionLineId] = 2;";
            //    using (reader = cmd.ExecuteReader())
            //    {
            //        reader.Read();
            //        ind = reader.GetOrdinal("workOrder");
            //        workOrder = reader.GetValue(ind).ToString();
            //        ind = reader.GetOrdinal("partNumber");
            //        partNumber = reader.GetValue(ind).ToString();
            //        ind = reader.GetOrdinal("workOrderSize");
            //        try
            //        {
            //            workOrderSize = int.Parse(reader.GetValue(ind).ToString());
            //        }
            //        catch
            //        {
            //            workOrderSize = -1;
            //        }                   
            //    }
            //    cmd.CommandText = "SELECT [numOfPiecesOk], [numOfPiecesNok] FROM [WorkOrder] WHERE [id] = (SELECT [workOrderId] FROM [ExchangeTable] WHERE [productionLineId] = 2);";
            //    using (reader = cmd.ExecuteReader())
            //    {
            //        reader.Read();
            //        ind = reader.GetOrdinal("numOfPiecesOk");
            //        try
            //        {
            //            numOfPiecesOk = int.Parse(reader.GetValue(ind).ToString());
            //        }
            //        catch
            //        {
            //            numOfPiecesOk = 0;
            //        }
            //        ind = reader.GetOrdinal("numOfPiecesNok");
            //        try
            //        {
            //            numOfPiecesNok = int.Parse(reader.GetValue(ind).ToString());
            //        }
            //        catch
            //        {
            //            numOfPiecesNok = 0;
            //        }
            //    }
            //    UpdateInfoProd(workOrder, workOrderSize, partNumber, numOfPiecesOk, numOfPiecesNok);

            //    //Infos charts
                
            //    cmd.CommandText = "EXECUTE sp_GetListOfDimensions @productionLineId=2;";
            //    int id = 0;
            //    using (reader = cmd.ExecuteReader())
            //    {                    
            //        while (reader.Read())
            //        {
            //            ind = reader.GetOrdinal("id");
            //            try
            //            {
            //                id = int.Parse(reader.GetValue(ind).ToString());
            //            }
            //            catch
            //            {
            //                id = 0;
            //            }
            //        }
            //    }

            //    I_MR_List yValues = new I_MR_List();
            //    cmd.CommandText = "EXECUTE sp_GetLastMeasurements @n=" + numOfPoints.ToString() + ", @dimensionId=" + id.ToString() + ";";
            //    using (reader = cmd.ExecuteReader())
            //    {
            //        int i = 0;
            //        while(reader.Read())
            //        {
            //            I_MR_Point yValue = new I_MR_Point();
                        
            //            ind = reader.GetOrdinal("value");
            //            try
            //            {
            //                yValue.I = double.Parse(reader.GetValue(ind).ToString());
            //            }
            //            catch
            //            {
            //                yValue.I = 0;
            //            }

            //            ind = reader.GetOrdinal("min");
            //            try
            //            {
            //                yValue.TolMin = double.Parse(reader.GetValue(ind).ToString());
            //            }
            //            catch
            //            {
            //                yValue.TolMin = 0;
            //            }

            //            ind = reader.GetOrdinal("max");
            //            try
            //            {
            //                yValue.TolMax = double.Parse(reader.GetValue(ind).ToString());
            //            }
            //            catch
            //            {
            //                yValue.TolMax = 0;
            //            }

            //            yValues.Add(yValue);

            //            i++;
            //        }
            //    }
            //    UpdateChart(yValues);
            //    Thread.Sleep(1000);
            //}
            
        }

        private void UpdateInfoProd(string workOrder, int workOrderSize, string partNumber, int numOfPiecesOk, int numOfPiecesNok)
        {
            //if (label_WorkOrder.InvokeRequired)
            //{
            //    var d = new SafeCallDelegate(UpdateInfoProd);
            //    Invoke(d, new object[] { workOrder, workOrderSize, partNumber, numOfPiecesOk, numOfPiecesNok });
            //}
            //else
            //{
            //    label_WorkOrder.Text = workOrder;
            //}

            //if (label_Size.InvokeRequired)
            //{
            //    var d = new SafeCallDelegate(UpdateInfoProd);
            //    Invoke(d, new object[] { workOrder, workOrderSize, partNumber, numOfPiecesOk, numOfPiecesNok });
            //}
            //else
            //{
            //    label_Size.Text = workOrderSize.ToString();
            //}
            
            //if (label_PartNumber.InvokeRequired)
            //{
            //    var d = new SafeCallDelegate(UpdateInfoProd);
            //    Invoke(d, new object[] { workOrder, workOrderSize, partNumber, numOfPiecesOk, numOfPiecesNok });
            //}
            //else
            //{
            //    label_PartNumber.Text = partNumber;
            //}

            //if (label_Ok.InvokeRequired)
            //{
            //    var d = new SafeCallDelegate(UpdateInfoProd);
            //    Invoke(d, new object[] { workOrder, workOrderSize, partNumber, numOfPiecesOk, numOfPiecesNok });
            //}
            //else
            //{
            //    double ratio = (double)numOfPiecesOk / (numOfPiecesOk + numOfPiecesNok);
            //    string pcesOk = numOfPiecesOk.ToString() + " (";
            //    pcesOk += ratio.ToString("P2") + ")";
            //    label_Ok.Text = pcesOk;
            //}

            //if (label_Nok.InvokeRequired)
            //{
            //    var d = new SafeCallDelegate(UpdateInfoProd);
            //    Invoke(d, new object[] { workOrder, workOrderSize, partNumber, numOfPiecesOk, numOfPiecesNok });
            //}
            //else
            //{
            //    double ratio = (double)numOfPiecesNok / (numOfPiecesOk + numOfPiecesNok);
            //    string pcesNok = numOfPiecesNok.ToString() + " (";
            //    pcesNok += ratio.ToString("P2") + ")";
            //    label_Nok.Text = pcesNok;
            //}

        }

        private void UpdateChart(I_MR_List yValues)
        {
            //if (chart1.InvokeRequired)
            //{
            //    var d = new DelegateUpdateChart(UpdateChart);
            //    Invoke(d, new object[] { yValues });
            //}
            //else
            //{
            //    chart1.Series["Values"].Points.Clear();
            //    chart1.Series["TolMin"].Points.Clear();
            //    chart1.Series["TolMax"].Points.Clear();
            //    chart1.Series["Avg"].Points.Clear();
            //    chart1.Series["Target"].Points.Clear();

            //    if (yValues.Count > 0)
            //    {
            //        chart1.ChartAreas[0].AxisY.Minimum = Math.Round(yValues[yValues.Count - 1].TolMin - (yValues[yValues.Count - 1].TolMax - yValues[yValues.Count - 1].TolMin) / 4, 2);
            //        chart1.ChartAreas[0].AxisY.Maximum = Math.Round(yValues[yValues.Count - 1].TolMax + (yValues[yValues.Count - 1].TolMax - yValues[yValues.Count - 1].TolMin) / 4, 2);

            //        foreach (I_MR_Point yValue in yValues)
            //        {
            //            chart1.Series["Values"].Points.AddY(yValue.I);
            //            chart1.Series["TolMin"].Points.AddY(yValue.TolMin);
            //            chart1.Series["TolMax"].Points.AddY(yValue.TolMax);
            //            chart1.Series["Avg"].Points.AddY(yValues.AvgI);
            //            chart1.Series["Target"].Points.AddY(yValue.Target);
            //        }
            //    }
            //}
        }
        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Fermeture des Threads
            //myThreadUpdateInfoProd.Abort();
            myThreadUpdateForm.Abort();

            //Fermeture de la connexion au serveur SQL
            //cnn.Close();
        }
    }
}
