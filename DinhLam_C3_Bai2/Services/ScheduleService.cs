using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinhLam_C3_Bai2
{
    public class ScheduleService
    {
        private readonly List<Schedule> _schedule = AllDataContext.AllSchedules;
        private TrainService _trainService = new TrainService();
        public List<Schedule> GetSchedule(Station start, Station destination)
        {
            List<Schedule> chosenSchedule = new List<Schedule>();
            foreach(var schedule in _schedule)
            {
                if (schedule.Start.Id == start.Id && schedule.Destination.Id == destination.Id)
                    chosenSchedule.Add(schedule);
            }
            return chosenSchedule;
        }

        public List<Schedule> GetAllData() 
        {
            return _schedule;
        }

        public Schedule GetById(int id)
        {
            foreach (var item in _schedule)
                if (item.Id == id)
                    return item;
            return null;
        }

        public ScheduleDto GetDto(Schedule schedule)
        {
            return new ScheduleDto
            {
                Id = schedule.Id,
                From = schedule.Start.Name,
                To = schedule.Destination.Name,
                TrainType = schedule.TrainType.Name,
                Departure = schedule.DepartureTime,
                Arrived = schedule.ArrivedTime,
                Status = schedule.Status
            };
        }

        public List<ScheduleDto> GetAll()
        {
            List<ScheduleDto> listdto = new List<ScheduleDto>();
            foreach (var schedule in _schedule)
            {
                listdto.Add(GetDto(schedule));
            }
            return listdto;
        }

        public void Add(Schedule schedule)
        {
            _schedule.Add(schedule);
        }

        public List<Train> GetAvailableTrain(DateTime departure, DateTime arrived)
        {
            List<Train> trainlist = new List<Train>();
            foreach (var item in _schedule)
                if (arrived < item.DepartureTime || departure > item.ArrivedTime)
                    trainlist.Add(_trainService.NewTrain(item.TrainType.Id));
            return trainlist;
        }

        public void ChangeStatus(int Id)
        {
            foreach(var item in _schedule)
                if(item.Id==Id)
                {
                    if(item.Status==1)
                        item.Status = 0;
                    else
                        item.Status = 1;
                    break;
                }
        }

        public void UpdateSchedule(TrainTicket newTicket)
        {
            foreach(var item in  _schedule)
            {
                if (item.Id == newTicket.TrainInfo.Id)
                {
                    _trainService.BookingPosition(item.TrainType,newTicket.CoachNo, newTicket.SeatNo);
                    _trainService.CheckStatus(item.TrainType);
                    if (item.TrainType.Status == 0)
                        item.Status = 0;
                    break;
                }
            }
        }
    }
}
