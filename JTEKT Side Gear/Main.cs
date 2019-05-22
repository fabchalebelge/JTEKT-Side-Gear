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
        private delegate void SafeCallUpdateIMRChart(I_MR_Chart chart);
        private delegate void SafeCallUpdateInfoProd();
        private delegate void SafeCallAddCharts();
        private int partNumberId;

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
            //Démarrage dans un thread de la mise à jour de la fenêtre (info prod + graphiques)
            myThreadUpdateForm = new Thread(new ThreadStart(UpdateForm));
            myThreadUpdateForm.Start();

        }

        private void UpdateForm()
        {
            while (Thread.CurrentThread.IsAlive)
            {
                //Mise à jour des infos générales de prod
                UpdateInfoProd();

                //Ajout d'un objet graphique par dimension (caractéristique) à afficher si changement de part number
                int currentPartNumberId = sqlDataSet.PartNumberId;
                if (partNumberId != currentPartNumberId)
                {
                    partNumberId = currentPartNumberId;
                    AddCharts();
                }

                //Mise à jour de chaque graphique
                foreach (I_MR_Chart chart in listOfCharts)
                {
                    Update_I_MR_Chart(chart);
                }

                Thread.Sleep(1000);
            }
        }

        private void AddCharts()
        {
            if (this.InvokeRequired)
            {
                var d = new SafeCallAddCharts(AddCharts);
                Invoke(d, new object[] { });
            }
            else
            {
                int index = 0;
                foreach(I_MR_Chart chart in listOfCharts)
                {
                    this.Controls.Remove(chart.chart_I);
                }
                listOfCharts.Clear();
                foreach (int dimensionId in sqlDataSet.DimensionsIds)
                {
                    I_MR_Chart myChart = new I_MR_Chart(index, dimensionId);
                    this.Controls.Add(myChart.chart_I);
                    listOfCharts.Add(myChart);
                    index++;
                }
            }
            
        }

        private void UpdateInfoProd()
        {
            if (label_WorkOrder.InvokeRequired || label_PartNumber.InvokeRequired || label_Size.InvokeRequired || label_Ok.InvokeRequired || label_Nok.InvokeRequired)
            {
                var d = new SafeCallUpdateInfoProd(UpdateInfoProd);
                Invoke(d, new object[] { });
            }
            else
            {
                string partNumber = sqlDataSet.PartNumber;
                label_PartNumber.Text = partNumber;

                string workOrder = sqlDataSet.WorkOrder;
                label_WorkOrder.Text = workOrder;

                int workOrderSize = sqlDataSet.WorkOrderSize;
                if (workOrderSize > -1)
                    label_Size.Text = workOrderSize.ToString();
                else
                    label_Size.Text = "NA";

                int numOfPiecesOk = sqlDataSet.NumOfPiecesOk;
                int numOfPiecesNok = sqlDataSet.NumOfPiecesNok;
                if (numOfPiecesOk > -1 && numOfPiecesNok > -1)
                {
                    double ratioOk = (double)numOfPiecesOk / (numOfPiecesOk + numOfPiecesNok);
                    string pcesOk = numOfPiecesOk.ToString() + " (";
                    pcesOk += ratioOk.ToString("P2") + ")";

                    double ratioNok = (double)numOfPiecesNok / (numOfPiecesOk + numOfPiecesNok);
                    string pcesNok = numOfPiecesNok.ToString() + " (";
                    pcesNok += ratioNok.ToString("P2") + ")";

                    label_Ok.Text = pcesOk;
                    label_Nok.Text = pcesNok;
                }
                else
                {
                    label_Ok.Text = "NA";
                    label_Nok.Text = "NA";
                }
                    

            }
        }

        private void Update_I_MR_Chart(I_MR_Chart chart)
        {
            if (chart.chart_I.InvokeRequired)
            {
                var d = new SafeCallUpdateIMRChart(Update_I_MR_Chart);
                Invoke(d, new object[] { chart });
            }
            else
            {
                I_MR_List yValues = sqlDataSet.Values(chart.DimensionId);
                chart.UpdateChart(yValues);
            }
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Fermeture des Threads
            myThreadUpdateForm.Abort();

        }
    }
}
