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
    public static class UIHelpers
    {
        public static DataGridTextColumn CreateDatagridColumn(string header, string bindingPath)
        {
            return new DataGridTextColumn
            {
                Header = header,
                Binding = new Binding(bindingPath) { Mode=BindingMode.OneWay},
            };
        }
        public static DataGridTextColumn CreateDatagridColumn(string header, string bindingPath, BindingMode bindingMode)
        {
            var column = new DataGridTextColumn
            {
                Header = header,
                Binding = new Binding(bindingPath)
                {
                    Mode = bindingMode
                }
            };

            return column;
        }

        public static DataGrid CreateDataGrid<T>(IEnumerable<T> itemSource, SelectionChangedEventHandler handler)
        {
            DataGrid grid = new DataGrid
            {
                AutoGenerateColumns = false,
                IsReadOnly = true,
                ItemsSource = itemSource,
                Margin = new Thickness(10)
            };
            if (handler!=null)
                grid.SelectionChanged += handler;
            return grid; 
        }

        public static StackPanel CreateInputStackPanel(string stackPanelName, string labelContent)
        {
            StackPanel stackPanel = new StackPanel
            {
                Name = stackPanelName,
                Orientation = Orientation.Horizontal,
                Margin = new Thickness(5)
            };

            Label label = new Label
            {
                Content = labelContent,
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Thickness(0, 0, 5, 0),
                Width = 150,
                FontSize=15
            };

            TextBox textBox = new TextBox
            {
                VerticalAlignment = VerticalAlignment.Center,
                Width = 200,
                Margin = new Thickness(0, 0, 5, 0),
                FontSize = 15
            };

            stackPanel.Children.Add(label);
            stackPanel.Children.Add(textBox);

            return stackPanel;
        }

        public static Button CreateButton(string buttonName, string buttonContent, RoutedEventHandler clickEventHandler)
        {
            Button button = new Button
            {
                Name = buttonName,
                Content = buttonContent,
                Margin = new Thickness(5),
                Padding = new Thickness(10),
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                FontSize = 20,
                FontWeight=FontWeights.Bold
            };

            button.Click += clickEventHandler;

            return button;
        }

        public static StackPanel CreateButtonPanel(string stackPanelName, List<Button> buttons)
        {
            StackPanel stackPanel = new StackPanel
            {
                Name = stackPanelName,
                Orientation = Orientation.Horizontal,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Bottom,
                Margin = new Thickness(5)
            };

            
            foreach (var button in buttons)
            {
                button.Margin = new Thickness(5); 
                stackPanel.Children.Add(button);
            }

            return stackPanel;
        }

        public static string GetInput(StackPanel inputPanel)
        {
            foreach (var item in inputPanel.Children)
                if (item is TextBox text)
                    return text.Text;
            return "";
        }

        public static ComboBox CreateComboBox<T>(
            string comboBoxname, 
            IEnumerable<T> itemsSource,
            string displayMemberPath,
            Action<object, SelectionChangedEventArgs> selectionChangedAction)
        {
            ComboBox comboBox = new ComboBox()
            {
                Name = comboBoxname,
                Width = 100,
                FontSize = 15
            };
            if (itemsSource != null)
            {
                comboBox.ItemsSource = itemsSource;
                comboBox.DisplayMemberPath = displayMemberPath;
                comboBox.Margin = new Thickness(5);
            }
           
            if (selectionChangedAction!=null)
                comboBox.SelectionChanged += (sender, e) => selectionChangedAction(sender, e);
            return comboBox;
        }
        public static StackPanel CreateComboBoxStackPanel(string labelContent, ComboBox comboBox)
        {
            StackPanel stackPanel = new StackPanel();
            stackPanel.Orientation = Orientation.Horizontal;
            Label label = new Label();
            label.Content = labelContent;
            label.FontSize = 15;

            stackPanel.Children.Add(label);
            stackPanel.Children.Add(comboBox);

            return stackPanel;
        }
        
        public static T GetItemFromComboBox<T>(ComboBox comboBox)
        {
            if (comboBox.SelectedItem is T selectedItem)
            {
                return selectedItem;
            }
            return default;
        }

        public static DatePicker CreateDatePicker(string name, DateTime selectedDate)
        {
            DatePicker datePicker = new DatePicker
            {
                Name = name,
                SelectedDate = selectedDate,
                Margin = new Thickness(5, 5, 50, 5),
            };
            return datePicker;
        }

        public static StackPanel CreateDateTimePickerPanel(string panelName, string labelContent, DatePicker datePicker, RoutedEventHandler onChangedHandler)
        {
            StackPanel stackPanel = new StackPanel();
            stackPanel.Orientation = Orientation.Horizontal;
            stackPanel.Margin=new Thickness(10,20,10,10);
            stackPanel.MaxHeight = 50;
            stackPanel.Name = panelName;
            Label label = new Label
            {
                Content = labelContent,
                Width = 100,
                Margin = new Thickness(5),
                FontSize= 15
            };
            stackPanel.Children.Add(label);
            stackPanel.Children.Add(datePicker);

            Label Timelabel = new Label
            {
                Content = "Time(HH:mm): ",
                Width = 100,
                Margin = new Thickness(5),
                FontSize = 15
            };
            TextBox timeTextBox = new TextBox
            {
                Margin = new Thickness(5),
                Width = 100,
                Text = "00:00",
                FontSize = 15
            };

            timeTextBox.TextChanged += (s, e) => onChangedHandler(s, e);
            datePicker.SelectedDateChanged += (s, e) => onChangedHandler(s, e);

            stackPanel.Children.Add(Timelabel);
            stackPanel.Children.Add(timeTextBox);
            return stackPanel;
        }

        public static DateTime GetDateTimeFromPicker(StackPanel stackPanel)
        {
            DateTime getDateTime = new DateTime();
            TimeSpan getTime = new TimeSpan();
            foreach (var item in stackPanel.Children)
            {
                if (item is TextBox timeTextBox)
                    if (!string.IsNullOrWhiteSpace(timeTextBox.Text))
                        if (TimeSpan.TryParseExact(timeTextBox.Text, "h\\:mm", null, out TimeSpan time))
                            getTime = time;
                        else
                            getTime = TimeSpan.Zero;
                if (item is DatePicker datePicker)
                    if (datePicker.SelectedDate != null)
                        getDateTime = (DateTime)datePicker.SelectedDate;
            }
            return getDateTime.Add(getTime);
        }
    }
}
