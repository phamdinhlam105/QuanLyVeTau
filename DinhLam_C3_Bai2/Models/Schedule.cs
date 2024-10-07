using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinhLam_C3_Bai2
{
    public class Schedule
    {
        public int Id { get; set; }
        public Station Start { get; set; }
        public Station Destination { get; set; }
        public Train TrainType { get; set; }
        public DateTime DepartureTime {  get; set; }
        public DateTime ArrivedTime { get; set; }
        public int Status { get; set; }

        public Schedule Clone()
        {
            return new Schedule
            {
                Id = this.Id,
                Start = this.Start.Clone(), 
                Destination = this.Destination.Clone(), 
                TrainType = this.TrainType.Clone(), 
                DepartureTime = this.DepartureTime,
                ArrivedTime = this.ArrivedTime,
                Status = this.Status
            };
        }

    }
}
