using DinhLam_C3_Bai2.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace DinhLam_C3_Bai2
{
    public class TrainService:ITrainService
    {
        public IEnumerable<Coach> GetCoaches(Train train)
        {
            return train.Coaches;
        }
    }
}
