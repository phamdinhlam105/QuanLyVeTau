using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace DinhLam_C3_Bai2
{
    public interface IBuilder<T>
    {
        T Build();
        void Clear();
    }
}
