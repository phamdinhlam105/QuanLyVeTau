﻿
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace DinhLam_C3_Bai2
{
    public class ScheduleBuilder:IScheduleBuilder
    {
        private Schedule _schedule;
        private static int _count = 1;
        public ScheduleBuilder()
        {
            _schedule = new Schedule();
        }
        public void Clear()
        {
            _schedule = new Schedule();
        }
        public IScheduleBuilder SetId()
        {
            _schedule.Id= _count;
            return this;
        }
        public IScheduleBuilder SetStation(Station start,Station destination)
        {
            _schedule.Start= start.Clone();
            _schedule.Destination = destination.Clone();
            return this;
        }

        public IScheduleBuilder SetTime(DateTime departure, DateTime arrived)
        {
            _schedule.DepartureTime = departure;
            _schedule.ArrivedTime = arrived;
            return this;
        }
        public IScheduleBuilder SetTrain(Train train)
        {
            _schedule.TrainType = train.Clone();
            return this;
        }
        public IScheduleBuilder SetStatus(int status)
        {
            _schedule.Status = status;
            return this;
        }
        public Schedule Build()
        {
            _count++;
            return _schedule.Clone();
        }
    }
}
