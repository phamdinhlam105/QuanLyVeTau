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

namespace DinhLam_C3_Bai2.Views.Tickets
{
    /// <summary>
    /// Interaction logic for NewTicketWindow.xaml
    /// </summary>
    public partial class NewTicketWindow : Window
    {
        private NewTicketViewModel _newTicketVM;
        public NewTicketWindow()
        {
            InitializeComponent();
            _newTicketVM = new NewTicketViewModel(mainPanel, this);
            _newTicketVM.InitView();
        }
    }
}
