using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinhLam_C3_Bai2
{
    public interface IScheduleService
    {
        IEnumerable<Schedule> GetScheduleByStation(Station start, Station destination);
        IEnumerable<Schedule> GetAll();
        Schedule GetById(int id);

        ScheduleDto GetDto(Schedule schedule);

        IEnumerable<ScheduleDto> GetAllDto();

        void Add(Schedule schedule);

        void ChangeStatus(int Id);
     
    }
}
