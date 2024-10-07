using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinhLam_C3_Bai2
{
    public static class Validate
    {
        public static bool DateTimeValidate(DateTime start, DateTime destination)
        {
            if (start < destination)
                return true;
            return false;
        }
    }
}
