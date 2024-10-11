using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinhLam_C3_Bai2
{
    public class TicketService:ITicketService
    {
        private readonly List<TrainTicket> _ticketList = AllDataContext.AllTickets;

        public IEnumerable<TrainTicket> GetAll()
        {
            return _ticketList;
        }
        public void Add(TrainTicket ticket)
        {
            _ticketList.Add(ticket);
        }

        public TrainTicket GetById(int id)
        {
            foreach(var ticket in _ticketList)
                if (ticket.Id == id)
                    return ticket;
            return null;
        }

        public TicketDto GetDto(TrainTicket ticket)
        {
            Train train = ticket.TrainInfo.TrainType.Clone();
            TicketDto ticketDto = new TicketDto();
            ticketDto.Id = ticket.Id;
            ticketDto.Name = ticket.Name;
            ticketDto.Phone=ticket.Phone;
            ticketDto.Train = train.Name;
            ticketDto.Coach = ticket.CoachNo.Name;
            ticketDto.Seat = ticket.SeatNo.Name;
            ticketDto.departureTime = ticket.TrainInfo.DepartureTime;
            ticketDto.createdAt = ticket.createAt;
            return ticketDto;
        }


        public IEnumerable<TicketDto> GetAllDto()
        {
            List<TicketDto> listdto = new List<TicketDto>();
            foreach (TrainTicket ticket in _ticketList)
            {
                listdto.Add(GetDto(ticket));
            }
            return listdto;
        }
    }
}
