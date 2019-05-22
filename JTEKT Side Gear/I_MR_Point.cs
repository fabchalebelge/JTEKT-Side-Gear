using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTEKT_Side_Gear
{
    class I_MR_Point
    {
        public decimal I { get; set; }
        public decimal TolMin { get; set; }
        public decimal TolMax { get; set; }
        public decimal Target { get { return (this.TolMin + this.TolMax) / 2; } }
    }
}
