using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Common;

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

                cmd.CommandText = "EXECUTE sp_GetListOfDimensions @productionLineId=2;";

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
                        yValue.I = double.Parse(reader.GetValue(ind).ToString());
                    }
                    catch
                    {
                        yValue.I = 0;
                    }

                    ind = reader.GetOrdinal("min");
                    try
                    {
                        yValue.TolMin = double.Parse(reader.GetValue(ind).ToString());
                    }
                    catch
                    {
                        yValue.TolMin = 0;
                    }

                    ind = reader.GetOrdinal("max");
                    try
                    {
                        yValue.TolMax = double.Parse(reader.GetValue(ind).ToString());
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
    }
}
