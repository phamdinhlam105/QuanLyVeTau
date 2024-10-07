using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinhLam_C3_Bai2
{
    public class Station:INotifyPropertyChanged
    {
        public string Id {  get; set; }
        public string Name { get; set; }
        public string City {  get; set; }
        public string Address {  get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
       
        public Station Clone()
        {
            return new Station
            {
                Id = this.Id,
                Name = this.Name,
                City = this.City,
                Address = this.Address
            };
        }
    }
}
