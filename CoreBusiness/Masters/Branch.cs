using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBusiness.Masters
{
    public class Branch
    {
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public int DivisionId { get; set; }
        public int BranchId { get; set; }
    }
}
