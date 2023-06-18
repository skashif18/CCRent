using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBusiness
{
    public class ServiceScheduleNewModel
    {
        public int Id { get; set; }
        public int SrvId { get; set; }
        public string ScheduleType { get; set; }
        public int Interval { get; set; }
        public List<int> InvervalDay { get; set; }
        public DateTime StartDate { get;set; }
        public DateTime EndtDate { get; set; }
    }
}
