using DinhLam_C3_Bai2.Views.Schedule;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace DinhLam_C3_Bai2
{
    public class ScheduleViewModel:INotifyPropertyChanged
    {
        private ScheduleWindow _scheduleWindow;
        private StackPanel _stackPanel;
        private IScheduleService _scheduleService;
        private ObservableCollection<ScheduleDto> _schedules;
        private int ChosenId = 0;
        public ObservableCollection<ScheduleDto> Schedules
        {
            get => _schedules;
            set
            {
                _schedules = value;
                OnPropertyChanged(nameof(_schedules));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ScheduleViewModel(ScheduleWindow scheduleWindow, StackPanel stackPanel)
        {
            _scheduleWindow = scheduleWindow;
            _stackPanel = stackPanel;
            _scheduleService = new ScheduleService();
        }
        private void SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = (ScheduleDto)((DataGrid)sender).SelectedItem;
            if (selectedItem != null)
                ChosenId = selectedItem.Id;
        }

        public void ImportView()
        {
            _stackPanel.Children.Clear();
            Schedules = new ObservableCollection<ScheduleDto>(_scheduleService.GetAllDto());
            DataGrid scheduleGrid = UIHelpers.CreateDataGrid<ScheduleDto>(Schedules, SelectionChanged);
            DataGridTextColumn IdColumn = UIHelpers.CreateDatagridColumn("Id", "Id");
            DataGridTextColumn FromColumn = UIHelpers.CreateDatagridColumn("From", "From");
            DataGridTextColumn ToColumn = UIHelpers.CreateDatagridColumn("To", "To");
            DataGridTextColumn TrainTypeColumn = UIHelpers.CreateDatagridColumn("TrainType", "TrainType");
            DataGridTextColumn DepartureColumn = UIHelpers.CreateDatagridColumn("Departure", "Departure");
            DataGridTextColumn ArrivedColumn = UIHelpers.CreateDatagridColumn("Arrived", "Arrived");
            DataGridTextColumn StatusColumn = UIHelpers.CreateDatagridColumn("Status", "Status");
            
            
            scheduleGrid.Columns.Add(IdColumn);
            scheduleGrid.Columns.Add(FromColumn);
            scheduleGrid.Columns.Add(ToColumn);
            scheduleGrid.Columns.Add(TrainTypeColumn);
            scheduleGrid.Columns.Add(DepartureColumn);
            scheduleGrid.Columns.Add(ArrivedColumn);
            scheduleGrid.Columns.Add(StatusColumn);
            _stackPanel.Children.Add(scheduleGrid);
        }

        public void ChangeStatus()
        {

            if (ChosenId!=0)
                _scheduleService.ChangeStatus(ChosenId);
            else
                MessageBox.Show(Constants.NotChosen);
        }
    }
}
