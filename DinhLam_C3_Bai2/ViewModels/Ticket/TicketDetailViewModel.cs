using DinhLam_C3_Bai2.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace DinhLam_C3_Bai2
{
    public class TicketDetailViewModel
    {
        private StackPanel _stackPanel;
        private int _chosenId;
        private TicketService _ticketService;
        private TicketDetailWindow _ticketDetailWindow;
        public TicketDetailViewModel(StackPanel stackPanel, int ChosenId,TicketDetailWindow ticketDetailWindow) 
        {
            _stackPanel = stackPanel;
            _chosenId = ChosenId;
            _ticketService = new TicketService();
            _ticketDetailWindow = ticketDetailWindow;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            _ticketDetailWindow.Close();
        }

        public void ImportView()
        {
            _stackPanel.Children.Clear();
            TrainTicket ticket = _ticketService.GetById(_chosenId);

            Label user = new Label
            {
                Content = "Customer Information:",
                FontSize = 15,
                FontWeight = FontWeights.Bold,
                Margin = new Thickness(5)
            };
            _stackPanel.Children.Add(user);

            StackPanel userPanel = new StackPanel();
            userPanel.Orientation=Orientation.Horizontal;
            Label userId = new Label
            {
                Content = "Identification: " + ticket.CCCD,
                FontSize = 15,
                Margin = new Thickness(5)
            };
            Label userName = new Label
            {
                Content = "Name: " + ticket.Name,
                FontSize = 15,
                Margin = new Thickness(5)
            };
            Label userPhone = new Label
            {
                Content = "Phone number: " + ticket.Phone,
                FontSize = 15,
                Margin = new Thickness(5)
            };
            userPanel.Children.Add(userId);
            userPanel.Children.Add(userName);
            userPanel.Children.Add(userPhone);
            _stackPanel.Children.Add(userPanel);

            Label station = new Label
            {
                Content = "Station Information:",
                FontSize = 15,
                FontWeight = FontWeights.Bold,
                Margin = new Thickness(5)
            };
            _stackPanel.Children.Add(station);
            StackPanel stationPanel = new StackPanel();
            stationPanel.Orientation = Orientation.Horizontal;
            Label From = new Label
            {
                Content = "From: " + ticket.TrainInfo.Start.Name,
                FontSize = 15,
                Margin = new Thickness(5)
            };
            Label To = new Label
            {
                Content = "To: " + ticket.TrainInfo.Destination.Name,
                FontSize = 15,
                Margin = new Thickness(5)
            };
            stationPanel.Children.Add(From);
            stationPanel.Children.Add(To);
            _stackPanel.Children.Add(stationPanel);

            Label trainInfo = new Label
            {
                Content = "Train Information:",
                FontSize = 15,
                FontWeight = FontWeights.Bold,
                Margin = new Thickness(5)
            };
            _stackPanel.Children.Add(trainInfo);
            StackPanel trainPanel = new StackPanel();
            trainPanel.Orientation = Orientation.Horizontal;
            Label train = new Label
            {
                Content = "Train: " + ticket.TrainInfo.TrainType.Name,
                FontSize = 15,
                Margin = new Thickness(5)
            };
            Label coach = new Label
            {
                Content = "Coach: " + ticket.CoachNo.Name,
                FontSize = 15,
                Margin = new Thickness(5)
            };
            Label seat = new Label
            {
                Content = "Seat: " + ticket.SeatNo.Name,
                FontSize = 15,
                Margin = new Thickness(5)
            };
            trainPanel.Children.Add(train);
            trainPanel.Children.Add(coach);
            trainPanel.Children.Add(seat);
            _stackPanel.Children.Add(trainPanel);

            Label time = new Label
            {
                Content = "Time Information:",
                FontSize = 15,
                FontWeight = FontWeights.Bold,
                Margin = new Thickness(5)
            };
            _stackPanel.Children.Add(time);
            StackPanel timePanel = new StackPanel();
            timePanel.Orientation = Orientation.Horizontal;
            Label departure = new Label
            {
                Content = "Departure time: " + ticket.TrainInfo.DepartureTime,
                FontSize = 15,
                Margin = new Thickness(5)
            };
            Label destination = new Label
            {
                Content = "Arrival time: " + ticket.TrainInfo.ArrivedTime,
                FontSize = 15,
                Margin = new Thickness(5)
            };
            timePanel.Children.Add(departure);
            timePanel.Children.Add(destination);
            _stackPanel.Children.Add(timePanel);

            Button back = UIHelpers.CreateButton("back", "Back", Back_Click);
            StackPanel buttonPanel = UIHelpers.CreateButtonPanel("buttonPanel",new List<Button> { back });
            _stackPanel.Children.Add(buttonPanel);
        }
    }
}
