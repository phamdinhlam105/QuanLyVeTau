using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinhLam_C3_Bai2
{
    public class StationService
    {
        private readonly List<Station> _station = AllDataContext.AllStations;
        private readonly List<StationFrom> _stationFrom = AllDataContext.AllStationFroms;

        public List<Station> GetAllStation()
        {
            return _station;
        }
        public List<Station> ListDestinations(Station fromStation)
        {
            foreach(var item in  _stationFrom)
            {
                if (fromStation == item.StationStart)
                    return item.StationsPassed;
            }
            return null;
        }
    }
}
