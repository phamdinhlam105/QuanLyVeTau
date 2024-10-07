using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinhLam_C3_Bai2
{
    public class StationFrom
    {
        public string Id {  get; set; }
        public Station StationStart { get; set; }
        public List<Station> StationsPassed {  get; set; }
    }
}
