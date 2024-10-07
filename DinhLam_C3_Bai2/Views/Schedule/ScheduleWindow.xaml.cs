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

namespace DinhLam_C3_Bai2.Views.Schedule
{
    /// <summary>
    /// Interaction logic for ScheduleWindow.xaml
    /// </summary>
    public partial class ScheduleWindow : Window
    {
        private TicketWindow _ticketWindow;
        private ScheduleViewModel _scheduleVM;
        public ScheduleWindow(TicketWindow ticketWindow)
        {
            InitializeComponent();
            _ticketWindow = ticketWindow;
            _scheduleVM = new ScheduleViewModel(this, mainPanel);
            _scheduleVM.ImportView();
        }

        private void NewSchedule_Click(object sender, RoutedEventArgs e)
        {
            NewScheduleWindow win2 = new NewScheduleWindow();
            win2.ShowDialog();
            //reset view after add new
            _scheduleVM.ImportView();
        }
        private void ChangeStatus_Click(object sender, RoutedEventArgs e)
        {
            _scheduleVM.ChangeStatus();
            _scheduleVM.ImportView();
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            _ticketWindow.Show();
            this.Close();
        }
    }
}
