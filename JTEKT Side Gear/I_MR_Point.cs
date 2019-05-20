using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTEKT_Side_Gear
{
    class I_MR_Point
    {
        public double I { get; set; }
        public double TolMin { get; set; }
        public double TolMax { get; set; }
        public double Target { get { return (this.TolMin + this.TolMax) / 2; } }
    }
}
