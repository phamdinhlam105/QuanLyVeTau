using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinhLam_C3_Bai2
{
    public class Train
    {
        public int Id {  get; set; }
        public string Name { get; set; }
        public int Status {  get; set; }
        public List<Coach> Coaches { get; set; }
        
        public Train()
        {
            Coaches = new List<Coach>();
        }
        public Train Clone()
        {
            List<Coach> coaches = new List<Coach>();
            foreach (var item in Coaches)
                coaches.Add(item.Clone());
            return new Train
            {
                Id = Id,
                Name = Name,
                Status = Status,
                Coaches = coaches
            };
        }
    }
}
