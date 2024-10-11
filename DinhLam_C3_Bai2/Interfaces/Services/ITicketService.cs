using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinhLam_C3_Bai2
{
    public interface ITicketService
    {
        IEnumerable<TrainTicket> GetAll();
        void Add(TrainTicket ticket);

        TrainTicket GetById(int id);

        TicketDto GetDto(TrainTicket ticket);
        IEnumerable<TicketDto> GetAllDto();
    }
}
