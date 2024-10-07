using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace DinhLam_C3_Bai2
{
    public class TrainService
    {
        private readonly List<Train> _trainList = AllDataContext.AllTrains;
        private CoachService _coachService = new CoachService();

        public List<Coach> GetCoaches(Train train)
        {
            return train.Coaches;
        }

        public void BookingPosition(Train train, Coach coach, Seat seat)
        {
            foreach(var item in train.Coaches)
            {
                if (item.Id == coach.Id)
                    _coachService.BookingPosition(item, seat);
            }
        }

        public void CheckStatus(Train train)
        {
            int availableCount = 0;
            foreach (var item in train.Coaches)
            {
                _coachService.CheckStatus(item);
                if (item.Status == 1)
                    availableCount++;
            }
            if (availableCount == 0)
                train.Status = 0;
        }
        public Train NewTrain(int Id)
        {
            foreach (var item in _trainList)
                if (item.Id == Id)
                    return item.Clone();
            return null;
        }
    }
}
