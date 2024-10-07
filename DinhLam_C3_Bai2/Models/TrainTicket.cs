using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinhLam_C3_Bai2
{
    public class TrainTicket
    {
        public int Id {  get; set; }
        public int CCCD {  get; set; }
        public string Name {  get; set; }
        public int Phone {  get; set; }
        public Schedule TrainInfo { get; set; }
        public Coach CoachNo {  get; set; }
        public Seat SeatNo {  get; set; }
        public DateTime createAt {  get; set; }

        public TrainTicket Clone()
        {
            return new TrainTicket
            {
                Id = this.Id,
                CCCD = this.CCCD,
                Name = this.Name,
                Phone = this.Phone,
                TrainInfo = this.TrainInfo.Clone(),
                CoachNo = this.CoachNo.Clone(),
                SeatNo = this.SeatNo.Clone(),
                createAt = this.createAt
            };
        }
    }
    
}
