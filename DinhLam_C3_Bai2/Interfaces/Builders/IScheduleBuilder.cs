using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinhLam_C3_Bai2
{
    public interface IScheduleBuilder:IBuilder<Schedule>
    {
        IScheduleBuilder SetId();
        IScheduleBuilder SetStation(Station start, Station destination);
        IScheduleBuilder SetTime(DateTime departure, DateTime arrived);
        IScheduleBuilder SetTrain(Train train);
        IScheduleBuilder SetStatus(int status);
    }
}
