using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBusiness
{
    public class AvailableDateTimeResponseModel
    {
        public List<DateTime> FromDateTime { get; set; }
        public List<DateTime> ToDateTime { get; set; }
    }
}
