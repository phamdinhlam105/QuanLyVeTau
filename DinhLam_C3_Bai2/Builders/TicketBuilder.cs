using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinhLam_C3_Bai2
{
    public class TicketBuilder:ITicketBuilder
    {
        private TrainTicket _ticket;
        private static int _count = 1;
        public TicketBuilder()
        {
            _ticket = new TrainTicket();
        }
        public void Clear()
        {
            _ticket = new TrainTicket();
        }
        public ITicketBuilder SetId()
        {
            _ticket.Id = _count;
            return this;
        }
        public ITicketBuilder SetCustomer(int cccd,string name, int phone)
        {
            _ticket.CCCD = cccd;
            _ticket.Name = name;
            _ticket.Phone = phone;
            return this;
        }
        public ITicketBuilder SetTrainInfo(Schedule schedule)
        {
            _ticket.TrainInfo=schedule.Clone();
            return this;
        }
        public ITicketBuilder SetPosition(Coach coach,Seat seat)
        {
            _ticket.SeatNo = seat.Clone();
            _ticket.CoachNo = coach.Clone();
            return this;
        }
        public ITicketBuilder SetCreatedDate(DateTime createAt)
        {
            _ticket.createAt = createAt;
            return this;
        }
        public TrainTicket Build()
        {
            _count++;
            return _ticket.Clone();
        }
    }
}
