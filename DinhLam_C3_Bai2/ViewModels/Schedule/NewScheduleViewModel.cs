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

namespace DinhLam_C3_Bai2.ViewModels
{
    public class NewScheduleViewModel:INotifyPropertyChanged
    {
        private NewScheduleWindow _newSchduleWindow;
        private StackPanel _stackPanel;
        private ScheduleService _scheduleService;
        private ObservableCollection<Station> _startStation;
        private ObservableCollection<Station> _destinationStation;
        private ObservableCollection<Train> _trains;
        private DateTime departure;
        private DateTime arrived;
        private ScheduleBuilder _newSchedule;
        private StationService _stationService;
        public ObservableCollection<Station> StartStation
        {
            get => _startStation;
            set
            {
                _startStation = value;
                OnPropertyChanged(nameof(StartStation));
            }
        }
        public ObservableCollection<Station> DestinationStation
        {
            get => _destinationStation;
            set
            {
                _destinationStation = value;
                OnPropertyChanged(nameof(DestinationStation));
            }
        }
        public ObservableCollection<Train> Trains
        {
            get => _trains;
            set
            {
                _trains = value;
                OnPropertyChanged(nameof(Trains));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public NewScheduleViewModel(StackPanel stackPanel, NewScheduleWindow newScheduleWindow)
        {
            _stackPanel = stackPanel;
            _scheduleService = new ScheduleService();
            _newSchedule = new ScheduleBuilder();
            _stationService = new StationService();
            _newSchduleWindow = newScheduleWindow;
        }
        private void Start_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is ComboBox comboBox && comboBox.SelectedItem is Station selectedStation)
            {
                DestinationStation.Clear();
                foreach (var item in new ObservableCollection<Station>(_stationService.ListDestinations(selectedStation)))
                    DestinationStation.Add(item);
            }
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            Station startStation = new Station();
            Station destinationStation = new Station();

            foreach (var item in _stackPanel.Children)
                if (item is StackPanel combopanel)
                    if (combopanel.Name != "buttonPanel")
                        foreach (var combochildren in combopanel.Children)
                            if (combochildren is ComboBox combo)
                            {
                                if (combo.Name == "startStation")
                                    startStation = UIHelpers.GetItemFromComboBox<Station>(combo);
                                if (combo.Name == "destinationStation")
                                    destinationStation = UIHelpers.GetItemFromComboBox<Station>(combo);
                            }

            if (startStation != null && destinationStation != null)
            {
                _newSchedule.SetStation(startStation, destinationStation);
                ChooseTimeView(startStation,destinationStation);
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            _newSchduleWindow.Close();
        }
        public void InitView()
        {
            _stackPanel.Children.Clear();
            StartStation = new ObservableCollection<Station>(_stationService.GetAllStation());
            DestinationStation = new ObservableCollection<Station>();

            ComboBox Start = UIHelpers.CreateComboBox<Station>("startStation", StartStation, "Name", Start_SelectionChanged);
            ComboBox Destination = UIHelpers.CreateComboBox<Station>("destinationStation", DestinationStation, "Name", null);

            Button confirm = UIHelpers.CreateButton("btNext", "Next", Next_Click);
            Button cancel = UIHelpers.CreateButton("btBack", "Cancel", Cancel_Click);
            StackPanel buttonPanel = UIHelpers.CreateButtonPanel("buttonPanel", new List<Button> { confirm, cancel });

            _stackPanel.Children.Add(UIHelpers.CreateComboBoxStackPanel("Start Station: ", Start));
            _stackPanel.Children.Add(UIHelpers.CreateComboBoxStackPanel("Destination Station: ", Destination));
            _stackPanel.Children.Add(buttonPanel);
        }

        private void DateTimePickerChanged(object sender, RoutedEventArgs e)
        {
            if(_stackPanel.Children[5] is Button button)
                button.IsEnabled = true;
            foreach(var item in _stackPanel.Children)
            {
                if (item is ComboBox combo)
                    if (combo.Name == "train")
                    {
                        _stackPanel.Children.Remove(combo);
                        break;
                    }
            }
        }

        private void GetTrain_Click(object sender, RoutedEventArgs e)
        {
            departure = UIHelpers.GetDateTimeFromPicker((StackPanel)_stackPanel.Children[2]);
            arrived = UIHelpers.GetDateTimeFromPicker((StackPanel)_stackPanel.Children[3]);
            if (Validate.DateTimeValidate(departure, arrived))
            {
                Trains = new ObservableCollection<Train>(_scheduleService.GetAvailableTrain(departure, arrived));
                
                if (Trains.Count() != 0)
                {
                    ComboBox trainlist = UIHelpers.CreateComboBox<Train>("train", Trains, "Name", null);
                    _stackPanel.Children.Insert(4, trainlist);
                    ((Button)sender).IsEnabled = false;
                }
                else
                    MessageBox.Show(Constants.NoTrainSuitable);
            }
            else
                MessageBox.Show(Constants.InvalidDateValidate);
        }

        private void Finish_Click(object sender, RoutedEventArgs e)
        {
            Train chosenTrain = null;
            foreach (var item in _stackPanel.Children)
                if (item is ComboBox combo)
                    chosenTrain = UIHelpers.GetItemFromComboBox<Train>(combo);
            if (chosenTrain != null)
            {
                _scheduleService.Add(_newSchedule
                    .SetId()
                    .SetStatus(1)
                    .SetTime(departure, arrived)
                    .SetTrain(chosenTrain)
                    .Build());
                _newSchduleWindow.Close();
            }
            else
                MessageBox.Show(Constants.NotChosen);
        }

        private void BackToStation_Click(object sender, RoutedEventArgs e)
        {
            InitView();
        }

        public void ChooseTimeView(Station startStation,Station destinationStation)
        {
            departure = DateTime.Now;
            arrived = DateTime.Now;
            _stackPanel.Children.Clear();
            
            //station information
            Label Start = new Label
            {
                Content = "Start station: " + startStation.Name,
                Margin = new Thickness(0, 0, 5, 0),
                Width = 300,
                FontSize=20
            };
            Label Destination = new Label
            {
                Content = "Desination station: " + destinationStation.Name,
                Margin = new Thickness(0, 0, 10, 0),
                Width = 300,
                FontSize = 20
            };
            _stackPanel.Children.Add(Start);
            _stackPanel.Children.Add(Destination);

            //pick date
            DatePicker departurePicker = UIHelpers.CreateDatePicker("departure", departure);
            StackPanel departurePanel = UIHelpers.CreateDateTimePickerPanel("departurePanel", "Departure time: ", departurePicker, DateTimePickerChanged);

            DatePicker arrivedPicker = UIHelpers.CreateDatePicker("arrived", arrived);
            StackPanel arrivedPanel = UIHelpers.CreateDateTimePickerPanel("arrivedPanel", "Arrived time: ", arrivedPicker, DateTimePickerChanged);

            //get train list by combobox after click button
            Button getTrain = UIHelpers.CreateButton("getTrain", "Train Available", GetTrain_Click);

            Button confirm = UIHelpers.CreateButton("btFinish", "Finish", Finish_Click);
            Button back = UIHelpers.CreateButton("btBack", "Back", BackToStation_Click);
            StackPanel buttonPanel = UIHelpers.CreateButtonPanel("buttonPanel", new List<Button> { confirm, back });

            _stackPanel.Children.Add(departurePanel);
            _stackPanel.Children.Add(arrivedPanel);
            _stackPanel.Children.Add(getTrain);
            _stackPanel.Children.Add(buttonPanel);
        }
    }
}
