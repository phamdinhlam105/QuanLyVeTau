using DinhLam_C3_Bai2.Views.Schedule;
using DinhLam_C3_Bai2.Views.Tickets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DinhLam_C3_Bai2.Views
{
    /// <summary>
    /// Interaction logic for TicketWindow.xaml
    /// </summary>
    public partial class TicketWindow : Window
    {
        private TicketViewModel _ticketVM;
        public TicketWindow()
        {
            InitializeComponent();
            _ticketVM = new TicketViewModel(mainPanel);
            _ticketVM.ImportView();
        }

        private void NewTicket_Click(object sender, RoutedEventArgs e)
        {
            NewTicketWindow win2 = new NewTicketWindow();
            win2.ShowDialog();
            _ticketVM.ImportView();
        }
        private void TicketDetail_Click(object sender, RoutedEventArgs e)
        {
            int chosenId = _ticketVM.GetChosenId();
            if (chosenId == 0)
                MessageBox.Show(Constants.NotChosen);
            else
            {
                TicketDetailWindow win2 = new TicketDetailWindow(chosenId);
                win2.ShowDialog();
            }
        }
        private void Schedule_Click(object sender, RoutedEventArgs e)
        {
            ScheduleWindow win2 = new ScheduleWindow(this);
            win2.Show();
            this.Hide();
        }
        private void Quit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
