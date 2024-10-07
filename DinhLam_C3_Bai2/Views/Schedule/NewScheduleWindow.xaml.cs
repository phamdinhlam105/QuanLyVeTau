using DinhLam_C3_Bai2.ViewModels;
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
    /// Interaction logic for NewScheduleWindow.xaml
    /// </summary>
    public partial class NewScheduleWindow : Window
    {
        private NewScheduleViewModel _newScheduleVM;
        public NewScheduleWindow()
        {
            InitializeComponent();
            _newScheduleVM = new NewScheduleViewModel(mainPanel, this);
            _newScheduleVM.InitView();
        }
    }
}
