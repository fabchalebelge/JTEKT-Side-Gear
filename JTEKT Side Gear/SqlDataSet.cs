using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Common;

using System.Windows.Forms;

namespace JTEKT_Side_Gear
{
    class SqlDataSet
    {
        private readonly int productionLineId;
        private readonly SqlConnection cnn;
        private SqlCommand cmd;
        private int numOfPoints;

        public SqlDataSet(int productionLineId, string connexionString, int numOfPoints)
        {
            this.productionLineId = productionLineId;
            this.numOfPoints = numOfPoints;
            cnn = new SqlConnection(connexionString);
            cnn.Open();
            cmd = cnn.CreateCommand();
        }

        public List<int> DimensionsIds
        {
            get
            {
                List<int> dimensionsIds = new List<int>();
                DbDataReader reader;

                cmd.CommandText = "EXECUTE sp_GetListOfDimensions @productionLineId=" + productionLineId.ToString() + ";";

                using (reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int ind = reader.GetOrdinal("id");
                        int id = (int)reader.GetValue(ind);
                        dimensionsIds.Add(id);
                    }
                }
                    return dimensionsIds;
            }
        }

        public I_MR_List Values(int dimensionId)
        {

            I_MR_List yValues = new I_MR_List();
            DbDataReader reader;

            cmd.CommandText = "EXECUTE sp_GetLastMeasurements @n=" + numOfPoints.ToString() + ", @dimensionId=" + dimensionId.ToString() + ";";

            using (reader = cmd.ExecuteReader())
            {
                int ind;

                while (reader.Read())
                {
                    I_MR_Point yValue = new I_MR_Point();

                    ind = reader.GetOrdinal("value");
                    try
                    {
                        yValue.I = decimal.Parse(reader.GetValue(ind).ToString());
                    }
                    catch
                    {
                        yValue.I = 0;
                    }

                    ind = reader.GetOrdinal("min");
                    try
                    {
                        yValue.TolMin = decimal.Parse(reader.GetValue(ind).ToString());
                    }
                    catch
                    {
                        yValue.TolMin = 0;
                    }

                    ind = reader.GetOrdinal("max");
                    try
                    {
                        yValue.TolMax = decimal.Parse(reader.GetValue(ind).ToString());
                    }
                    catch
                    {
                        yValue.TolMax = 0;
                    }

                    yValues.Add(yValue);

                }
            }
            return yValues;
        }

        public string PartNumber
        {
            get
            {
                DbDataReader reader;
                string partNumber;

                cmd.CommandText = "SELECT[partNumber] FROM [ExchangeTable] WHERE [productionLineId] = " + productionLineId.ToString() + ";";

                using (reader = cmd.ExecuteReader())
                {
                    reader.Read();
                    int ind = reader.GetOrdinal("partNumber");
                    try
                    {
                        partNumber = reader.GetString(ind);
                    }
                    catch
                    {
                        partNumber = "NA";
                    }
                }

                return partNumber;
            }
        }

        public string WorkOrder
        {
            get
            {
                DbDataReader reader;
                string workOrder;

                cmd.CommandText = "SELECT[workOrder] FROM [ExchangeTable] WHERE [productionLineId] = " + productionLineId.ToString() + ";";

                using (reader = cmd.ExecuteReader())
                {
                    reader.Read();
                    int ind = reader.GetOrdinal("workOrder");
                    try
                    {
                        workOrder = reader.GetString(ind);
                    }
                    catch
                    {
                        workOrder = "NA";
                    }
                }

                return workOrder;
            }
        }

        public int WorkOrderSize
        {
            get
            {
                DbDataReader reader;
                int workOrderSize;

                cmd.CommandText = "SELECT[workOrderSize] FROM [ExchangeTable] WHERE [productionLineId] = " + productionLineId.ToString() + ";";

                using (reader = cmd.ExecuteReader())
                {
                    reader.Read();
                    int ind = reader.GetOrdinal("workOrderSize");
                    try
                    {
                        workOrderSize = reader.GetInt16(ind);
                    }
                    catch
                    {
                        workOrderSize = -1;
                    }
                }

                return workOrderSize;
            }
        }

        public int NumOfPiecesOk
        {
            get
            {
                DbDataReader reader;
                int numOfPiecsOk;

                cmd.CommandText = "SELECT [numOfPiecesOk] FROM [WorkOrder] WHERE [id] = (SELECT [workOrderId] FROM [ExchangeTable] WHERE [productionLineId] = " + productionLineId.ToString() + ");";

                using (reader = cmd.ExecuteReader())
                {
                    reader.Read();
                    int ind = reader.GetOrdinal("numOfPiecesOk");
                    try
                    {
                        numOfPiecsOk = reader.GetInt16(ind);
                    }
                    catch
                    {
                        numOfPiecsOk = -1;
                    }
                }

                return numOfPiecsOk;
            }
        }

        public int NumOfPiecesNok
        {
            get
            {
                DbDataReader reader;
                int numOfPiecsNok;

                cmd.CommandText = "SELECT [numOfPiecesNok] FROM [WorkOrder] WHERE [id] = (SELECT [workOrderId] FROM [ExchangeTable] WHERE [productionLineId] = " + productionLineId.ToString() + ");";

                using (reader = cmd.ExecuteReader())
                {
                    reader.Read();
                    int ind = reader.GetOrdinal("numOfPiecesNok");
                    try
                    {
                        numOfPiecsNok = reader.GetInt16(ind);
                    }
                    catch
                    {
                        numOfPiecsNok = -1;
                    }
                }

                return numOfPiecsNok;
            }
        }

        public int PartNumberId
        {
            get
            {
                DbDataReader reader;
                int partNumberId;

                cmd.CommandText = "SELECT [partNumberId] FROM [ExchangeTable] WHERE [productionLineId] = " + productionLineId.ToString() + ";";

                using (reader = cmd.ExecuteReader())
                {
                    reader.Read();
                    int ind = reader.GetOrdinal("partNumberId");
                    try
                    {
                        partNumberId = (int)reader.GetValue(ind);
                    }
                    catch
                    {
                        partNumberId = -1;
                    }
                }

                return partNumberId;
            }
        }
    }
}
