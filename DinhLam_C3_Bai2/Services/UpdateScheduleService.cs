using DinhLam_C3_Bai2.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinhLam_C3_Bai2
{
    public class UpdateScheduleService:IUpdateScheduleService
    {
        private readonly IEnumerable<Schedule> _schedule = AllDataContext.AllSchedules;

        public void UpdateScheduleStatus(TrainTicket newTicket)
        {
            foreach (var item in _schedule)
            {
                if (item.Id == newTicket.TrainInfo.Id)
                {
                    CoachPosition(item.TrainType, newTicket.CoachNo, newTicket.SeatNo);
                    TrainStatus(item.TrainType);
                    if (item.TrainType.Status == 0)
                        item.Status = 0;
                    break;
                }
            }
        }

        private void CoachPosition(Train train, Coach coach, Seat seat)
        {
            foreach (var item in train.Coaches)
            {
                if (item.Id == coach.Id)
                    SeatPosition(item, seat);
            }
        }

        private void TrainStatus(Train train)
        {
            int availableCount = 0;
            foreach (var item in train.Coaches)
            {
                CoachStatus(item);
                if (item.Status == 1)
                    availableCount++;
            }
            if (availableCount == 0)
                train.Status = 0;
        }

        private void CoachStatus(Coach coach)
        {
            int availableCount = 0;
            foreach (var item in coach.Seats)
                if (item.Status == 1)
                    availableCount++;
            if (availableCount == 0)
                coach.Status = 0;
        }

        private void SeatPosition(Coach coach, Seat seat)
        {
            foreach (var item in coach.Seats)
                if (item.Id == seat.Id)
                    item.Status = 0;
        }
    }
}
