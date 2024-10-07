using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinhLam_C3_Bai2
{
    public class ScheduleDto
    {
        public int Id { get; set; }
        public string From {  get; set; }
        public string To { get; set; }
        public string TrainType {  get; set; }
        public DateTime Departure {  get; set; }
        public DateTime Arrived {  get; set; }
        public int Status { get; set; }
    }
}
