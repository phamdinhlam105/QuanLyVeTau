﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinhLam_C3_Bai2
{
    public interface IDestinationService
    {
        IEnumerable<Station> GetDestination(Station stationFrom);
    }
}
