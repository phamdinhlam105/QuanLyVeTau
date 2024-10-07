using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;

namespace DinhLam_C3_Bai2
{
    public class Coach:INotifyPropertyChanged
    {
        public int Id {  get; set; }
        public string Name { get; set; }
        public int Status {  get; set; }
        public List<Seat> Seats {  get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public Coach()
        {
            Seats=new List<Seat>();
        }
        public Coach Clone()
        {
            List<Seat> seats = new List<Seat>();
            foreach (var item in Seats)
                seats.Add(item.Clone());
            return new Coach
            {
                Id = this.Id,
                Name= this.Name,
                Status = this.Status,
                Seats = seats
            };
        }
    }
}
