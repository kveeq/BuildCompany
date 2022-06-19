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
    /// Логика взаимодействия для AddZakazWindow.xaml
    /// </summary>
    public partial class AddZakazWindow : Window
    {
        public AddZakazWindow()
        {
            InitializeComponent();
            Service.ItemsSource = App.db.Services.ToList();
            User.ItemsSource = App.db.User.ToList();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                Zakaz zakaz = new Zakaz();
                var service = (Services)Service.SelectedItem;
                var user = (User)User.SelectedItem;
                zakaz.User = user;
                zakaz.Services = service;
                zakaz.Date = DateTime.Now;
                zakaz.Status = "В работе";
                App.db.Zakaz.Add(zakaz);
                App.db.SaveChanges();
                MainWindow.action?.Invoke();
                MessageBox.Show("Успешно добавлен!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Что то пошло не так. Обратитесь к программисту!\n" + ex.Message);
            }
        }
    }
}
