using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinhLam_C3_Bai2
{
    public static class AllDataContext
    {
        public static List<Schedule> AllSchedules = new List<Schedule>();
        public static List<TrainTicket> AllTickets = new List<TrainTicket>();
        public static List<Station> AllStations = new List<Station>();
        public static List<StationFrom> AllStationFroms = new List<StationFrom>();
        public static List<Train> AllTrains = new List<Train>();
        public static List<Coach> AllCoaches = new List<Coach>();
        public static List<Seat> AllSeats = new List<Seat>();
    }
}
