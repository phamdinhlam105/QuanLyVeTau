using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace DinhLam_C3_Bai2
{
    public class TicketViewModel
    {
        StackPanel _stackPanel;
        private List<TicketDto> _ticketList;
        
        private ITicketService _ticketService;
        public TicketViewModel(StackPanel stackPanel)
        {
            _stackPanel = stackPanel;
            _ticketService = new TicketService();
        }

        public void ImportView()
        {
            _stackPanel.Children.Clear();
            _ticketList = _ticketService.GetAllDto().ToList();
            DataGrid dataGrid = new DataGrid
            {
                AutoGenerateColumns = false,
                IsReadOnly = true,
                ItemsSource = _ticketList,
                Margin = new Thickness(10)
            };

            dataGrid.Columns.Add(UIHelpers.CreateDatagridColumn("Id", "Id"));
            dataGrid.Columns.Add(UIHelpers.CreateDatagridColumn("Name", "Name"));
            dataGrid.Columns.Add(UIHelpers.CreateDatagridColumn("Phone", "Phone"));
            dataGrid.Columns.Add(UIHelpers.CreateDatagridColumn("Train", "Train"));
            dataGrid.Columns.Add(UIHelpers.CreateDatagridColumn("Coach", "Coach"));
            dataGrid.Columns.Add(UIHelpers.CreateDatagridColumn("Seat", "Seat"));
            dataGrid.Columns.Add(UIHelpers.CreateDatagridColumn("Departure Time", "departureTime"));
            dataGrid.Columns.Add(UIHelpers.CreateDatagridColumn("Created At", "createdAt"));

            _stackPanel.Children.Add(dataGrid);
        }
        public int GetChosenId()
        {
            if (((DataGrid)_stackPanel.Children[0]).SelectedItem is TicketDto selectTicket)
                return selectTicket.Id;
            return 0;
        }
    }
}
