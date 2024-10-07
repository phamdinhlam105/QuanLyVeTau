using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinhLam_C3_Bai2
{
    public class CoachService
    {

        public List<Seat> GetSeats(Coach coach)
        {
            return coach.Seats;
        }

        public void CheckStatus(Coach coach)
        {
            int availableCount = 0;
            foreach (var item in coach.Seats)
                if (item.Status == 1)
                    availableCount++;
            if (availableCount == 0)
                coach.Status = 0;
        }
        public void BookingPosition(Coach coach,Seat seat)
        {
            foreach (var item in coach.Seats)
                if (item.Id == seat.Id)
                    item.Status = 0;
        }
    }
}
