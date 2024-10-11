using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinhLam_C3_Bai2
{
    public class StationService:IStationService
    {
        private readonly List<Station> _station = AllDataContext.AllStations;

        public IEnumerable<Station> GetAllStation()
        {
            return _station;
        }
       
    }
}
