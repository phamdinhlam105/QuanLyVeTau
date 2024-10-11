using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinhLam_C3_Bai2
{
    public interface ITicketBuilder:IBuilder<TrainTicket>
    {
        ITicketBuilder SetId();
        ITicketBuilder SetCustomer(int cccd, string name, int phone);
        ITicketBuilder SetTrainInfo(Schedule schedule);
        ITicketBuilder SetPosition(Coach coach, Seat seat);
        ITicketBuilder SetCreatedDate(DateTime createAt);
    }
}
