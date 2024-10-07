using DinhLam_C3_Bai2.Views;
using DinhLam_C3_Bai2.Views.Tickets;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace DinhLam_C3_Bai2
{
    public class NewTicketViewModel:INotifyPropertyChanged
    {
        StackPanel _stackPanel;
        private TicketService _ticketService;
        private TicketBuilder _newticket;
        private StationService _stationService;
        private ObservableCollection<Station> _startStation;
        private ObservableCollection<Station> _destinationStation;
        private ObservableCollection<Seat> _seats;
        private ObservableCollection<Coach> _coaches;
        private ScheduleService _scheduleService;
        private NewTicketWindow _newTicketWindow;
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
        public ObservableCollection<Seat> Seats
        {
            get => _seats;
            set
            {
                _seats = value;
                OnPropertyChanged(nameof(Seats));
            }
        }
        public ObservableCollection<Coach> Coaches
        {
            get => _coaches;
            set
            {
                _coaches = value;
                OnPropertyChanged(nameof(Coaches));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public NewTicketViewModel(StackPanel stackPanel, NewTicketWindow newTicketWindow)
        {
            _stackPanel = stackPanel;
            _ticketService = new TicketService();
            _newticket = new TicketBuilder();
            _stationService = new StationService();
            _scheduleService = new ScheduleService();
            _newTicketWindow = newTicketWindow;
        }
        private void CustomerInfoFinish_Click(object sender, RoutedEventArgs e)
        {
            List<string> errorMessages = new List<string>();
            bool isValid = true;
            int cccd = 0;
            string name = "";
            int phone = 0;
            foreach (var item in _stackPanel.Children)
                if (item is StackPanel stackpanel)
                {
                    if (stackpanel.Name == "CDDD")
                        if (!int.TryParse(UIHelpers.GetInput(stackpanel), out cccd))
                        {
                            errorMessages.Add(Constants.InvalidFormat + " for cccd.");
                            isValid = false;
                        }
                    if (stackpanel.Name == "Name")
                    {
                        name = UIHelpers.GetInput(stackpanel);
                        if (string.IsNullOrEmpty(name))
                        {
                            errorMessages.Add(Constants.EmptyFields + " for Name.");
                            isValid = false;
                        }
                    }
                    if (stackpanel.Name == "Phone")
                        if (!int.TryParse(UIHelpers.GetInput(stackpanel), out phone))
                        {
                            errorMessages.Add(Constants.InvalidFormat + " for Phone.");
                            isValid = false;
                        }
                }
            if (!isValid)
                MessageBox.Show(string.Join("\n", errorMessages), "Input Errors", MessageBoxButton.OK, MessageBoxImage.Warning);
            else
            {
                _newticket = _newticket.SetCustomer(cccd, name, phone);
                ChooseStationView();
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            _newTicketWindow.Close();
        }

        public void InitView()
        {
            _stackPanel.Children.Clear();
            _stackPanel.Children.Add(UIHelpers.CreateInputStackPanel("CDDD", "Identification: "));
            _stackPanel.Children.Add(UIHelpers.CreateInputStackPanel("Name", "Customer name: "));
            _stackPanel.Children.Add(UIHelpers.CreateInputStackPanel("Phone", "Customer phone: "));
            Button confirm = UIHelpers.CreateButton("confirm", "Next", CustomerInfoFinish_Click);
            Button cancel = UIHelpers.CreateButton("cancel", "Cancel", Cancel_Click);
            StackPanel buttonPanel = UIHelpers.CreateButtonPanel("buttonPanel", new List<Button> { confirm,cancel });
            _stackPanel.Children.Add(buttonPanel);
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

        private void ChooseStationFinish_Click(object sender, RoutedEventArgs e)
        {
            Station startStation = new Station();
            Station destinationStation= new Station();
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
            List<Schedule> schedules = _scheduleService.GetSchedule(startStation, destinationStation);
            if (schedules.Count() == 0)
                MessageBox.Show(Constants.NoTrain);
            else
                ChooseTrainView(schedules);
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            _newticket.Clear();
            InitView();
        }

        public void ChooseStationView()
        {
            _stackPanel.Children.Clear();
            StartStation = new ObservableCollection<Station>(_stationService.GetAllStation());
            DestinationStation = new ObservableCollection<Station>();
            ComboBox Start = UIHelpers.CreateComboBox("startStation", StartStation, "Name", Start_SelectionChanged);
            ComboBox Destination = UIHelpers.CreateComboBox("destinationStation", DestinationStation,"Name",null);

            Button confirm = UIHelpers.CreateButton("btNext", "Next", ChooseStationFinish_Click);
            Button back = UIHelpers.CreateButton("btBack", "Back", Back_Click);
            StackPanel buttonPanel = UIHelpers.CreateButtonPanel("buttonPanel", new List<Button> { confirm,back });
            _stackPanel.Children.Add(UIHelpers.CreateComboBoxStackPanel("Start Station: ",Start));
            _stackPanel.Children.Add(UIHelpers.CreateComboBoxStackPanel("Destination Station: ", Destination));
            _stackPanel.Children.Add(buttonPanel);
        }

        private void ChooseSchedule(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = ((DataGrid)sender).SelectedItem;
            if (selectedItem is Schedule schedule)
            {
                Coaches.Clear();
                foreach (var item in schedule.TrainType.Coaches)
                    Coaches.Add(item);
            }
                
            OnPropertyChanged(nameof(Coaches));
        }

        private void ChooseCoach(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = ((DataGrid)sender).SelectedItem;
            if (selectedItem is Coach coach)
            {
                Seats.Clear();
                foreach (var item in coach.Seats)
                    Seats.Add(item);
            }
        }

        private void NewTicketFinish_Click(object sender, RoutedEventArgs e)
        {
            List<string> errorMessages = new List<string>();
            bool isValid = true;
            Coach CoachNo = new Coach();
            Seat SeatNo = new Seat();
            Schedule ChosenSchedule = new Schedule();
            foreach (var item in _stackPanel.Children)
                if (item is DataGrid grid)
                {
                    if (grid.Name == "Schedule")
                        if (grid.SelectedItem is Schedule schedule)
                            if (schedule.Status == 1 && schedule != null)
                                ChosenSchedule = schedule.Clone();
                            else
                            {
                                errorMessages.Add(Constants.Unavailable + " schedule");
                                isValid = false;
                            }
                        else
                        {
                            errorMessages.Add(Constants.NotChosen + "for schedule");
                            isValid = false;
                        }
                    if (grid.Name == "Coach")
                    {
                        if (grid.SelectedItem is Coach coach)
                            if (coach.Status == 1 && coach != null)
                                CoachNo = coach;
                            else
                            {
                                errorMessages.Add(Constants.Unavailable + " coach");
                                isValid = false;
                            }
                        else
                        {
                            errorMessages.Add(Constants.NotChosen + "for coach");
                            isValid = false;
                        }
                    }
                    if (grid.Name == "Seat")
                    {
                        if (grid.SelectedItem is Seat seat)
                            if (seat.Status == 1 && seat != null)
                                SeatNo = seat;
                            else
                            {
                                errorMessages.Add(Constants.Unavailable + " seat");
                                isValid = false;
                            }
                        else
                        {
                            errorMessages.Add(Constants.NotChosen + "for seat");
                            isValid = false;
                        }
                    }
                }
            if (!isValid)
                MessageBox.Show(string.Join("\n", errorMessages), "Input Errors", MessageBoxButton.OK, MessageBoxImage.Warning);
            else
            {
                MessageBoxResult result = MessageBox.Show("Are you sure you want to save booking?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    TrainTicket newticket = _newticket
                        .SetId()
                        .SetCreatedDate(DateTime.Now)
                        .SetTrainInfo(ChosenSchedule)
                        .SetPosition(CoachNo, SeatNo)
                        .Build();
                    _ticketService.Add(newticket);
                    _scheduleService.UpdateSchedule(newticket);
                    MessageBox.Show(Constants.CompleteCreation);
                    TicketDetailWindow win2 = new TicketDetailWindow(newticket.Id);
                    win2.ShowDialog();
                    _newTicketWindow.Close();
                }
            }
        }

        private void BackToStation_Click(object sender, RoutedEventArgs e)
        {
            ChooseStationView();
        }

        public void ChooseTrainView(List<Schedule> schedules)
        {
            _stackPanel.Children.Clear();
            Seats = new ObservableCollection<Seat>();
            Coaches = new ObservableCollection<Coach>();
            // station information
            Label Start = new Label
            {
                Content = "Start station: " + schedules[0].Start.Name,
                Margin = new Thickness(0, 0, 5, 0),
                Width = 250,
                FontSize=20
            };
            Label Destination = new Label
            {
                Content = "Start station: " + schedules[0].Destination.Name,
                Margin = new Thickness(0, 0, 5, 0),
                Width = 250,
                FontSize = 20
            };
            _stackPanel.Children.Add(Start);
            _stackPanel.Children.Add(Destination);

            //choose schedule
            Label trainList = new Label
            {
                Content = "Schedules",
                Margin = new Thickness(0, 10, 0, 0),
                Width = 250,
                FontSize = 15,
                HorizontalAlignment = HorizontalAlignment.Left
            };
            _stackPanel.Children.Add(trainList);

            DataGrid Schedule = UIHelpers.CreateDataGrid<Schedule>(schedules, ChooseSchedule);
            Schedule.Name = "Schedule";
            DataGridTextColumn IdColumn = UIHelpers.CreateDatagridColumn("Id", "Id");
            DataGridTextColumn StartColumn = UIHelpers.CreateDatagridColumn("Start", "Start.Name");
            DataGridTextColumn DestinationColumn = UIHelpers.CreateDatagridColumn("Destination", "Destination.Name");
            DataGridTextColumn TrainColumn = UIHelpers.CreateDatagridColumn("Train", "TrainType.Name");
            DataGridTextColumn DepartureColumn = UIHelpers.CreateDatagridColumn("Departure", "DepartureTime");
            DataGridTextColumn ArrivedColumn = UIHelpers.CreateDatagridColumn("Arrived", "ArrivedTime");
            DataGridTextColumn StatusColumn = UIHelpers.CreateDatagridColumn("Status", "Status");
            Schedule.Columns.Add(IdColumn);
            Schedule.Columns.Add(StartColumn);
            Schedule.Columns.Add(DestinationColumn);
            Schedule.Columns.Add(TrainColumn);
            Schedule.Columns.Add(DepartureColumn);
            Schedule.Columns.Add(ArrivedColumn);
            Schedule.Columns.Add(StatusColumn);
            _stackPanel.Children.Add(Schedule);

            //chose coach
            Label coachList = new Label
            {
                Content = "Coaches",
                Margin = new Thickness(0, 10, 0, 0),
                Width = 250,
                FontSize = 15,
                HorizontalAlignment = HorizontalAlignment.Left
            };
            _stackPanel.Children.Add(coachList);

            DataGrid Coach = UIHelpers.CreateDataGrid<Coach>(Coaches, ChooseCoach);
            Coach.Name = "Coach";
            DataGridTextColumn IdCoachColumn = UIHelpers.CreateDatagridColumn("Id", "Id");
            DataGridTextColumn NameCoachColumn = UIHelpers.CreateDatagridColumn("Name", "Name");
            DataGridTextColumn StatusCoachColumn = UIHelpers.CreateDatagridColumn("Status", "Status");
            Coach.Columns.Add(IdCoachColumn);
            Coach.Columns.Add(NameCoachColumn);
            Coach.Columns.Add(StatusCoachColumn);
            _stackPanel.Children.Add(Coach);

            //chose seat
            Label seatList = new Label
            {
                Content = "Seats",
                Margin = new Thickness(0, 10, 0, 0),
                Width = 250,
                FontSize = 15,
                HorizontalAlignment = HorizontalAlignment.Left
            };
            _stackPanel.Children.Add(seatList);

            DataGrid Seat = UIHelpers.CreateDataGrid<Seat>(Seats, null);
            Seat.Name = "Seat";
            DataGridTextColumn IdSeatColumn = UIHelpers.CreateDatagridColumn("Id", "Id");
            DataGridTextColumn NameSeatColumn = UIHelpers.CreateDatagridColumn("Name", "Name");
            DataGridTextColumn StatusSeatColumn = UIHelpers.CreateDatagridColumn("Status", "Status");
            Seat.Columns.Add(IdSeatColumn);
            Seat.Columns.Add(NameSeatColumn);
            Seat.Columns.Add(StatusSeatColumn);
            _stackPanel.Children.Add(Seat);

            Button confirm = UIHelpers.CreateButton("btFinish", "Finish", NewTicketFinish_Click);
            Button back = UIHelpers.CreateButton("btBack", "Back", BackToStation_Click);
            StackPanel buttonPanel = UIHelpers.CreateButtonPanel("buttonPanel", new List<Button> { confirm, back });
           
            _stackPanel.Children.Add(buttonPanel);
        }
    }
}
