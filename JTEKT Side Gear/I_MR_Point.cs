using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTEKT_Side_Gear
{
    class I_MR_Point
    {
        private static List<I_MR_Point> list = new List<I_MR_Point>();

        public double I { get; set; }
        public double TolMin { get; set; }
        public double TolMax { get; set; }
        public double Target { get { return (this.TolMin + this.TolMax) / 2; } }
        public double AvgI { get { return (double)list.Sum(item => item.I) / list.Count(); } }

        public I_MR_Point()
        {
            list.Add(this);
        }

        public static void ClearListOfPoints()
        {
            list.Clear();
        }

        /*
        private static double sumOfI;
        private static double sumOfMR;
        private static int numOfPoints;

        private double myI;
        private double myMR;

        public double I
        {
            get
            {
                return myI;
            }
            set
            {
                sumOfI -= myI;
                myI = value;
                sumOfI += myI;
            }
        }
        public double MR
        {
            get
            {
                return myMR;
            }
            set
            {
                sumOfMR -= myMR;
                myMR = value;
                sumOfMR += myMR;
            }
        }
        public double TolMin { get; set; }
        public double TolMax { get; set; }
        public double Target { get { return (this.TolMin + this.TolMax) / 2; } }
        public double AvgI { get { return sumOfI / numOfPoints; } }

        public I_MR_Point()
        {
            numOfPoints++;
        }
        */
    }
}
