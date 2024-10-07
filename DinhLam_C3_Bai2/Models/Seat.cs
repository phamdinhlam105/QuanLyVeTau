using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinhLam_C3_Bai2
{
    public class Seat:INotifyPropertyChanged
    {
        public int Id {  get; set; }
        public string Name { get; set; }
        public int Status {  get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public Seat Clone()
        {
            return new Seat
            {
                Id = this.Id,
                Name = this.Name,
                Status = this.Status
            };
        }
    }
}
