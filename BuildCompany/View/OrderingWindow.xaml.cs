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
    /// Логика взаимодействия для OrderingWindow.xaml
    /// </summary>
    public partial class OrderingWindow : Window
    {
        Services service;
        int equipment1;
        int employee1;
        bool state;
        public OrderingWindow(Services services, int employee)
        {
            InitializeComponent();
            service = services;
            employee1 = employee;
            state = false;
        }
        public OrderingWindow(int employee)
        {
            InitializeComponent();
            equipment1 = employee;
            state = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (state)
            {
                try
                {
                    User user = new User();
                    user.Fio = FioTxt.Text;
                    user.Adres = AddressTxt.Text;
                    user.PassportSeria = SeriaTxt.Text;
                    user.PassportNumber = NumberTxt.Text;
                    user.TelNumber = TelNumberTxt.Text;
                    App.db.User.Add(user);
                    App.db.SaveChanges();
                    EquipmentRent rent = new EquipmentRent();
                    rent.DateStart = DateTime.Now;
                    rent.IdEquipment = equipment1;
                    rent.Statuss = true;
                    rent.IdUser = user.Id;
                    rent.Status = "Арендован";
                    App.db.EquipmentRent.Add(rent);
                    App.db.SaveChanges();
                    MainWindow.action?.Invoke();
                    MessageBox.Show("Вы успешно заказали");
                    this.Close();
                }
                catch
                {
                    MessageBox.Show("Что то пошло не так! Обратитесь к программисту!");
                }
            }
            else
            {
                try
                {
                    User user = new User();
                    user.Fio = FioTxt.Text;
                    user.Adres = AddressTxt.Text;
                    user.PassportSeria = SeriaTxt.Text;
                    user.PassportNumber = NumberTxt.Text;
                    user.TelNumber = TelNumberTxt.Text;
                    App.db.User.Add(user);
                    App.db.SaveChanges();
                    Zakaz zakaz = new Zakaz();
                    zakaz.Date = DateTime.Now;
                    zakaz.IdService = service.Id;
                    zakaz.IdUser = user.Id;
                    zakaz.Status = "В обработке";
                    zakaz.Statuss = false;
                    zakaz.IdEmployee = employee1;
                    zakaz.Accept = true;
                    App.db.Zakaz.Add(zakaz);
                    App.db.SaveChanges();
                    MainWindow.action?.Invoke();
                    MessageBox.Show("Вы успешно заказали");
                    this.Close();
                }
                catch
                {
                    MessageBox.Show("Что то пошло не так! Обратитесь к программисту!");
                }
            }
        }
    }
}
