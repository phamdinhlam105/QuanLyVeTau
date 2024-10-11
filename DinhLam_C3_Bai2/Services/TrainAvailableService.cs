using DinhLam_C3_Bai2.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinhLam_C3_Bai2
{
    public class TrainAvailableService : ITrainAvailableService
    {
        private readonly IEnumerable<Schedule> _schedule = AllDataContext.AllSchedules;
        private readonly IEnumerable<Train> _train = AllDataContext.AllTrains;
        public IEnumerable<Train> GetAvailableTrain(DateTime departure, DateTime arrived)
        {
            List<Train> trainlist = _train.Select(t => t.Clone()).ToList();

            foreach (var item in _schedule)
                if (!(arrived < item.DepartureTime || departure > item.ArrivedTime))
                    trainlist.RemoveAll(t=> t.Id==item.TrainType.Id);
            return trainlist;
        }

    }
}
