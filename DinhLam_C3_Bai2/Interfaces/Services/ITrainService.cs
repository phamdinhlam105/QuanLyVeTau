using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinhLam_C3_Bai2.Interfaces.Services
{
    public interface ITrainService
    {
        IEnumerable<Coach> GetCoaches(Train train);
    }
}