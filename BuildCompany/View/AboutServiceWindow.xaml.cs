using BuildCompany.db;
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

namespace BuildCompany.View
{
    /// <summary>
    /// Логика взаимодействия для AboutServiceWindow.xaml
    /// </summary>
    public partial class AboutServiceWindow : Window
    {
        List<Timetable> list = App.db.Timetable.ToList();
        List<Employee> lst = new List<Employee>();
        Services service;
        public AboutServiceWindow(Services services)
        {
            InitializeComponent();
            service = services;
            List<Timetable> list = App.db.Timetable.ToList();
            List<Employee> lst = new List<Employee>();
            foreach (var item in list)
            {
                if (item.Services.Id == service.Id)
                {
                    lst.Add(item.Employee);
                }   
            }
            DataContext = service;
            ServiceEmployeeLstView1.ItemsSource = lst;
        }

        private void Zakaz_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Вы точно хотите заказать?", "запрос", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.No || result == MessageBoxResult.Cancel)
                return;
            var id = int.Parse(((Button)sender).CommandParameter.ToString());
            OrderingWindow orderingWindow = new OrderingWindow(service, id);
            orderingWindow.Show();
            orderingWindow.Activate();
            orderingWindow.Topmost = true;
            orderingWindow.Closing += ((s, ce) => this.IsHitTestVisible = true);
            this.Activated += (s, ce) => orderingWindow.Activate();
            this.IsHitTestVisible = false;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
       {
            lst.Clear();
            foreach (var item in list)
            {
                if (item.Services.Id == service.Id)
                {
                    lst.Add(item.Employee);
                }
            }
            if (txtboc.Text == "")
            {
                ServiceEmployeeLstView1.ItemsSource = lst;
            }
            else
            {
               ServiceEmployeeLstView1.ItemsSource = lst.Where(x => x.Fio.Contains(txtboc.Text));
            }
        }
    }
}
