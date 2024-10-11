using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinhLam_C3_Bai2
{
    public class CoachService:ICoachService
    {
        public IEnumerable<Seat> GetSeats(Coach coach)
        {
            return coach.Seats;
        }

    }
}
