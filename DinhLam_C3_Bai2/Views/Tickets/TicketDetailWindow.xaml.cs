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
    /// Interaction logic for TicketDetailWindow.xaml
    /// </summary>
    public partial class TicketDetailWindow : Window
    {
        private TicketDetailViewModel _ticketDetailVM;
        public TicketDetailWindow(int chosenId)
        {
            InitializeComponent();
            _ticketDetailVM = new TicketDetailViewModel(mainPanel, chosenId,this);
            _ticketDetailVM.ImportView();
        }
    }
}
