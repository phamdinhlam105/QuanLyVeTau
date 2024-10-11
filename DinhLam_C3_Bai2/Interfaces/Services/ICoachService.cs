using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinhLam_C3_Bai2
{
    public interface ICoachService
    {
        IEnumerable<Seat> GetSeats(Coach coach);
    }
}
