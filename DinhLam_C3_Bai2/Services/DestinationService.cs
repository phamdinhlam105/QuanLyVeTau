using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinhLam_C3_Bai2
{
    internal class DestinationService : IDestinationService
    {
        private readonly IEnumerable<StationFrom> _stationFrom = AllDataContext.AllStationFroms;
        public IEnumerable<Station> GetDestination(Station stationFrom)
        {
                foreach (var item in _stationFrom)
                {
                    if (stationFrom == item.StationStart)
                        return item.StationsPassed;
                }
                return null;
        }
    }
}
