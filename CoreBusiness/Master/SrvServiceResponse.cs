using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBusiness.Master
{
    public class SrvServiceResponse:SrvService
    {
        public double AvgRating { get; set; }
        public string CategoryHie { get; set; }
        public int ReviewNum { get; set; }
    }
}
