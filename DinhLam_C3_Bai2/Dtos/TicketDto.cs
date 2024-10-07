using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinhLam_C3_Bai2
{
    public class TicketDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Phone { get; set; }
        public string Train {  get; set; }
        public string Coach {  get; set; }
        public string Seat {  get; set; }
        public DateTime departureTime { get; set; }
        public DateTime createdAt {  get; set; }

    }
}
