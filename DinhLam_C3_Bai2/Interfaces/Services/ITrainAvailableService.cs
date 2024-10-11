﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinhLam_C3_Bai2
{
    public interface ITrainAvailableService
    {
        public IEnumerable<Train> GetAvailableTrain(DateTime departure, DateTime arrived);
    }
}
